using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapArrayOneWay : MonoBehaviour
{
    static public mapArrayOneWay Instance;

    public GameObject[] blockPrefabArray;

    public int orderOfBlock;

    private void OnEnable()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
