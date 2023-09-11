using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exercises : MonoBehaviour
{
    public GameObject cubePrefab;
    // Start is called before the first frame update
    void Start()
    {
        // Exercise 1
        for (int i = 0; i < 10; i++)
        {
            Instantiate(cubePrefab, new Vector3(0f, 0f, (float)i),Quaternion.identity);
        }

        //Exercise 2
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
