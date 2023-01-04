using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AllSceneManager;

public class AudioCentreScript : MonoBehaviour
{

    public static AudioCentreScript _audioCentreScript;
    // Start is called before the first frame update

    public AudioClip[] player_sound;
    public AudioClip[] monster_sound;

    public void OnEnable()
    {
        if (_audioCentreScript != null && _audioCentreScript != this)
        {
            Destroy(this);
        }
        else
        {
            _audioCentreScript = this;
        }

    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
