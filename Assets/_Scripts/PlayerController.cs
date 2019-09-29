using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;
public class PlayerController : MonoBehaviour
{
    public Speed speed;
    public Boundary boundary;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        move();
        CheckBound();
    }
    /// <summary>
    /// This method use to move the player in x axis only
    /// </summary>
    void move ()
    {
        Vector2 newPosition = transform.position;
        if (Input.GetAxis("Horizontal") > 0.0f)
        {
            newPosition += new Vector2(speed.max, 0.0f);
        }
        if (Input.GetAxis("Horizontal") < 0.0f)
        {
            newPosition += new Vector2(speed.min, 0.0f);
        }
        transform.position = newPosition;
    }
    /// <summary>
    /// Restrict player from move outside the scene
    /// by using boundary class
    /// </summary>
    public void CheckBound()
    {
        //Check right boundary
        if (transform.position.x > boundary.Right)
        {
            transform.position = new Vector2(boundary.Right, transform.position.y);
        }
        //Check left boundary
        if (transform.position.x < boundary.Left)
        {
            transform.position = new Vector2(boundary.Left, transform.position.y);
        }
    }
}
