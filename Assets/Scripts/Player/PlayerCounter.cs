using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerCounter : MonoBehaviour
{
    private int playerScore = 1;
    [SerializeField] private TextMeshProUGUI playerScoreCounterText;
    [SerializeField] private GameObject PlayerScoreObj;
    private PlayerMovement playerMovement;
    private PlayerAnimator playerAnimator;

    private WallInstance w;
    // Start is called before the first frame update
    void Start()
    {
        UpdatePlayerScoreText();
        playerMovement = GetComponent<PlayerMovement>();
        playerAnimator = GetComponent<PlayerAnimator>();
    }
    public void IncrementScore()
    {
        playerScore++;
        UpdatePlayerScoreText();
    }
    public void DecreaseScore(int amount, WallInstance wall)
    {
        playerScore -= amount;
        if (playerScore >= 1)
        {
            wall.WallPassed();
            playerAnimator.TriggerTackling();
        }
        UpdatePlayerScoreText();
    }
    public void ApplyExpression(string exp)
    {
        if (string.IsNullOrEmpty(exp) || exp.Length < 2)
        {
            Debug.LogWarning("Invalid expression: " + exp);
            return;
        }

        char operation = exp[0];
        string valuePart = exp.Substring(1);

        if (!float.TryParse(valuePart, out float value))
        {
            Debug.LogWarning("Invalid number in expression: " + exp);
            return;
        }

        switch (operation)
        {
            case '+':
                playerScore += Mathf.RoundToInt(value);
                break;
            case '-':
                playerScore -= Mathf.RoundToInt(value);
                break;
            case '*':
                playerScore = Mathf.RoundToInt(playerScore * value);
                break;
            case '/':
                if (value != 0)
                    playerScore = (int)(playerScore / value);
                else
                    Debug.LogWarning("Division by zero in expression: " + exp);
                break;
            default:
                Debug.LogWarning("Unknown operation in expression: " + exp);
                break;
        }
        UpdatePlayerScoreText();

        // Debug.Log("New Score: " + playerScore);
    }
    void UpdatePlayerScoreText()
    {
        if (playerScore < 1)
        {
            playerMovement.TriggerGameOver();
            playerAnimator.TriggerCollapsing();
            return;
        }
        playerScoreCounterText.text = playerScore.ToString();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Burger"))
        {
            // Debug.Log("Picked up a Score!");
            IncrementScore();
            // Destroy(other.gameObject); // remove the coin
            // Add score, sound, etc.
            other.GetComponent<BurgerInstance>().BugerConsumed();
        }
        if (other.CompareTag("Wall"))
        {
            WallCollided(other.GetComponent<WallInstance>());
        }
        if (other.CompareTag("Door"))
        {
            DoorCollided(other.GetComponent<DoorInstance>());
        }

    }

    void WallCollided(WallInstance wall)
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            Handheld.Vibrate();
        }
        if (wall != null)
        {
            WallInstance wallInstance = wall;
            DecreaseScore(wallInstance.ReturnWallPower(), wallInstance);
            // wallInstance.WallPassed();
        }
    }
    void DoorCollided(DoorInstance door)
    {
        if (door != null)
        {
            DoorInstance doorInstance = door;
            ApplyExpression(doorInstance.ReturnDoorExpression());
        }
    }

    public void GameEnded()
    {
        PlayerScoreObj.SetActive(false);
    }
}
