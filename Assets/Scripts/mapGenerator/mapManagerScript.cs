using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapManagerScript : MonoBehaviour
{

    public GameObject[] mapPrefab;

    public float xGenerate;
    public float mapLength;

    public int numberOfMap;

    public Transform playerTransform;


    // Start is called before the first frame update
    void Start()
    {
        GenerateMap(0);

        //for (int i = 0; i < numberOfMap; i++)
        //{
        //    if (i == 0)
        //        GenerateMap(0);
        //    else
        //        GenerateMap(Random.Range(1, mapPrefab.Length));
        //}
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.x > xGenerate - (numberOfMap * mapLength))
        {
                    GenerateMap(Random.Range(1, mapPrefab.Length));
        }


    }

    public void GenerateMap (int index)
    {
        Instantiate(mapPrefab[index], transform.right * xGenerate, Quaternion.Euler(new Vector3(-90, 0, 0)));
        xGenerate += mapLength;
    }


}
