using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class energyCollectScript : MonoBehaviour
{
    // Start is called before the first frame update

    public GameUIScript energyAttributor;
    public bool collected;

    void Start()
    {
        energyAttributor = GameObject.Find("UI").GetComponent<GameUIScript>();
        collected = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            collected = true;
            energyAttributor.EnergyCollectionCount();
            Destroy(this.gameObject);
        }
    }
}
