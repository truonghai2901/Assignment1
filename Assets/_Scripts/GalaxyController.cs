using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalaxyController : MonoBehaviour
{
    public float verticalSpeed = 0.1f;
    public float resetPoint = -6.2f;
    public float resetPosition = 6.2f;

    // Start is called before the first frame update
    void Start()
    {
        //Reset();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Check();
    }
    /// <summary>
    /// This method moves the galaxy by verticalSpeed
    /// </summary>
    void Move()
    {
        Vector2 newPosition = new Vector2(0.0f, verticalSpeed);
        Vector2 currentPosition = transform.position;

        currentPosition -= newPosition;
        transform.position = currentPosition;
    }
    /// <summary>
    /// This method reset the galaxy to the resetPosition
    /// </summary>
    void Reset()
    {
        transform.position = new Vector2(0.0f, resetPosition);
    }
    /// <summary>
    /// This method check the condition(resetPoint) if it reach the resetpoint
    /// it Reset
    /// </summary>
    void Check()
    {
        if (transform.position.y <= resetPoint)
        {
            Reset();
        }
    }
}
