using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

public class MeteorScript : MonoBehaviour
{
    [Header("Speed Values")]
    [SerializeField]
    public Speed horizontalSpeedRange;

    [SerializeField]
    public Speed verticalSpeedRange;

    public float verticalSpeed;
    public float horizontalSpeed;

    [SerializeField]
    public Boundary boundary;

    private Animator anim;
    public float rotateSpeed = 50f;
    public bool canRotate;
    public  bool canMove;

    
    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        Reset();
        //randomly rotate the meteor direction
        if (canRotate)
        {
            if(Random.Range(0, 2) > 0)
            {
                rotateSpeed = Random.Range(rotateSpeed, rotateSpeed + 20f);
                rotateSpeed *= -1f;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        Move();
        CheckBounds();
        RotateMeteor();
    }
    /// <summary>
    /// This method moves the Meteor down the screen by verticalSpeed
    /// </summary>
    void Move()
    {
        if (canMove)
        {
            Vector2 newPosition = new Vector2(horizontalSpeed, verticalSpeed);
            Vector2 currentPosition = transform.position;

            currentPosition -= newPosition;
            transform.position = currentPosition;
        }
    }
    /// <summary>
    /// This method resets the Meteor to the resetPosition
    /// </summary>
    void Reset()
    {
        horizontalSpeed = Random.Range(horizontalSpeedRange.min, horizontalSpeedRange.max);
        verticalSpeed = Random.Range(verticalSpeedRange.min, verticalSpeedRange.max);
        float randomXPosition = Random.Range(boundary.Left, boundary.Right);
        transform.position = new Vector2(randomXPosition, Random.Range(boundary.Top, boundary.Top + 2.0f));
    }
    /// <summary>
    /// This method checks if the Meteor reaches the lower boundary
    /// and then it Resets it
    /// </summary>
    void CheckBounds()
    {
        if (transform.position.y <= boundary.Bottom)
        {
            Reset();
        }
    }
    /// <summary>
    /// this method rotate the meteor around itself
    /// </summary>
    void RotateMeteor()
    {
        if (canRotate)
        {
            transform.Rotate(new Vector3(0f, 0f, rotateSpeed * Time.deltaTime), Space.World);
        }
    }

    void TurnOffGameObject()
    {
        gameObject.SetActive(false);
    }
    //Deactivate moving method when got hit and trigger "Destroy" anim
    void OnTriggerEnter2D(Collider2D target)
    {
       if(target.tag == "Bullet")
        {
            canMove = false;
        }
        Invoke("TurnOffGameObject", 3f);

        anim.Play("Destroy");
        
    }
}

