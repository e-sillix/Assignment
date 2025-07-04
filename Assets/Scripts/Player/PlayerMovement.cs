using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private bool shouldMove = false;
    private bool finishLineReached = false, gameOver = false;

    [SerializeField] private float forwardSpeed = 5f;
    [SerializeField] private float strafeSpeed = 5f;              // smoothness of sideways motion
    [SerializeField] private float swipeSensitivity = 0.01f;      // drag sensitivity
    [SerializeField] private float horizontalLimit = 3f;          // clamp edges

    private Rigidbody rb;
    private float targetX;           // the desired X position from touch
    private Vector2 touchStartPos;
    private GameStateHandler gameState;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        targetX = transform.position.x; // initialize to current position
        gameState = FindObjectOfType<GameStateHandler>();
    }

    public void StartMoving() // call this from UI button or space key
    {
        shouldMove = true;
    }

    void Update()
    {
        if (!finishLineReached && !gameOver)
        {
            if (Input.touchCount > 0)
            { 
                StartMoving(); // Start moving when the first touch is detected
            }
            if (Input.GetKeyDown(KeyCode.Space) && !shouldMove)
            {
                StartMoving();
            }

            if (shouldMove)
            {
                HandleTouchInput();
            }
        }
    }

    void FixedUpdate()
    {
        if (!finishLineReached && shouldMove && !gameOver)
        {
            // Smooth horizontal slide toward targetX
            float smoothX = Mathf.Lerp(rb.position.x, targetX, strafeSpeed * Time.fixedDeltaTime);

            // Constant forward movement
            Vector3 forwardMove = Vector3.forward * forwardSpeed * Time.fixedDeltaTime;

            // Final movement position
            Vector3 newPosition = new Vector3(smoothX, rb.position.y, rb.position.z) + forwardMove;
            rb.MovePosition(newPosition);
            return;
        }
        if (!finishLineReached && !gameOver)
        {
            HandleTouchInput();
            // Smooth horizontal slide toward targetX
            float smoothX = Mathf.Lerp(rb.position.x, targetX, strafeSpeed * Time.fixedDeltaTime);
            Vector3 newPosition = new Vector3(smoothX, rb.position.y, rb.position.z);
            rb.MovePosition(newPosition);
        }
    }

    void HandleTouchInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                float deltaX = touch.deltaPosition.x * swipeSensitivity;

                targetX += deltaX;

                // Clamp to stay within wall bounds
                targetX = Mathf.Clamp(targetX, -horizontalLimit, horizontalLimit);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            finishLineReached = true;
            gameState.GameWon();
            Debug.Log("Finish Line Reached!");
        }
    }
    public void TriggerGameOver()
    {
        gameOver = true;
        gameState.GameOver();
    }
}
