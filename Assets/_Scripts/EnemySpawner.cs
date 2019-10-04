using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float min_X = 2.3f, max_X = 2.3f;
    public GameObject[] Meteor_Prefabs;
    public float timer = 2f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Spawn", timer);
    }
    void Spawn()
    {
        float position_X = Random.Range(min_X, max_X);
        Vector2 temp = transform.position;
        temp.x = position_X;
        if (Random.Range(0, 2) > 0)
        {
            Instantiate(Meteor_Prefabs[Random.Range(0, Meteor_Prefabs.Length)],
                temp, Quaternion.identity);
        }
        Invoke("Spawn", timer);
    }
}
