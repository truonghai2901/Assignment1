using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("Scene game object")]
    public GameObject meteor;

    public int numberOfMeteor;
    public List<GameObject> meteors;
    // Start is called before the first frame update
    void Start()
    {
        //Create empty container (list) of type GameObject
        meteors = new List<GameObject>();
        for (int i = 0; i < numberOfMeteor; i++)
        {
            meteors.Add(Instantiate(meteor));
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}