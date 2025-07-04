using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsInstance : MonoBehaviour
{
    public float speed = 1f;               // Movement speed
    public float travelDistance ;     // Total distance to travel
    private Vector3 startPosition;

     void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float offset = Mathf.PingPong(Time.time * speed, travelDistance);
        transform.position = startPosition + Vector3.left * offset;
    }
}


