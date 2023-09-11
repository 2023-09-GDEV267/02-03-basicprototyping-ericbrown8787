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
/*        for (int i = 0; i < 10; i++)
        {
            Instantiate(cubePrefab, new Vector3(0f, 0f, (float)i),Quaternion.identity);
        }
*/
        //Exercise 2
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j< 8; j++)
            {
                Instantiate(cubePrefab, new Vector3((float)i, 0f, (float)j), Quaternion.identity);
            }
            
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
