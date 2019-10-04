using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 0.5f;
    public float deactivateTimer = 3f;

    public GameController gameController;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DeactivateGameObject", deactivateTimer);
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }
    //move the bullet 
    void move ()
    {
        Vector2 newPosition = new Vector2(0.0f, speed);
        Vector2 currentPosition = transform.position;

        currentPosition += newPosition;
        transform.position = currentPosition;
    }
    //delete the bullets which can create problems when having too much bullets at once
    void DeactivateGameObject()
    {
        gameObject.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Bullet" || target.tag == "Enemy")
        {
            gameObject.SetActive(false);
        }
        gameController.Score += 100;
    }
}
