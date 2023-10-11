using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceCubes : MonoBehaviour
{
    // Just including this class to compare with my cube placement script from Roll A Ball for use in the remix assignment
    [Range(1,16)]public int numberCubes = 6;
    public int numberRings = 1;
    public float ringRadius = 5.0f;
    public GameObject goCubePrefab;
    void Start()
    {
        float startx = transform.position.x;
        float starty = transform.position.y;

        float degBetweenCubes = 360 / numberCubes;
        float radBetweenCubes = Mathf.Deg2Rad * degBetweenCubes;

        for (int i = 0; i < numberCubes; i += 1)
        {
            float x = Mathf.Cos(radBetweenCubes * i) * ringRadius + startx;
            float y = Mathf.Sin(radBetweenCubes * i) * ringRadius + starty;

            Vector3 cubeLoc = new Vector3(x, 1.0f, y);
            GameObject tempCube = Instantiate(goCubePrefab, cubeLoc, Quaternion.identity);
            tempCube.transform.SetParent(this.gameObject.transform);

        }

    }

    private void OnDrawGizmos()
    {
        float startx = transform.position.x;
        float starty = transform.position.y;

        Gizmos.color = new Color32(0, 255, 255, 51);
        Gizmos.DrawSphere(this.transform.position,.3f);

        float degBetweenCubes = 360 / numberCubes;
        float radBetweenCubes = Mathf.Deg2Rad * degBetweenCubes;

        for (int i = 0; i < numberCubes; i += 1)
        {
            float x = Mathf.Cos(radBetweenCubes * i)*ringRadius + startx;
            float y = Mathf.Sin(radBetweenCubes * i) * ringRadius + starty;

            Vector3 cubeLoc = new Vector3(x, 1.0f, y);
            Gizmos.DrawCube(cubeLoc, Vector3.one * 0.5f);
        }


    }
}
