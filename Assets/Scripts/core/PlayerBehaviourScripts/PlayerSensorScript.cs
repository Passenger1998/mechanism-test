using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class PlayerSensorScript : MonoBehaviour
{
    [SerializeField] UnityEvent BeingAttacked;

    public static event Action BeingTeleported;
    public static event Action MonsterBoxTriggered;

    public AudioSource audiosource;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Warnings();

    }

    void Warnings()
    {
        AudioClip mildwarning = AudioCentreScript._audioCentreScript.player_sound[0];
        AudioClip serioiuswarning = AudioCentreScript._audioCentreScript.player_sound[1];


        if (PlayerGlobalCondition._PlayerGlobalCondition.player_hp <= 5 && PlayerGlobalCondition._PlayerGlobalCondition.player_hp > 0)
        {
            audiosource.mute = false;
            //float timeBetweenShots = 15.0f;

            //audiosource.PlayOneShot(mildwarning, 1.0f);

            float timer = 0.0f;
            timer += Time.deltaTime;

            if (timer < 15.0f)
            {
                audiosource.PlayOneShot(mildwarning, 0.25f);
                timer = 0.0f;
            }
        } else if (PlayerGlobalCondition._PlayerGlobalCondition.player_hp <= 2 && PlayerGlobalCondition._PlayerGlobalCondition.player_hp > 0)
        {
            audiosource.mute = false;
            //float timeBetweenShots = 32.0f;
            //audiosource.PlayOneShot(serioiuswarning, 1.0f);

            float timer = 0.0f;
            timer += Time.deltaTime;

            if (timer > 32.0f)
            {
                audiosource.PlayOneShot(serioiuswarning, 0.25f);
                timer = 0.0f;
            }


        }
        else if (PlayerGlobalCondition._PlayerGlobalCondition.player_hp > 5)
        {
            audiosource.mute = true;
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("Teleport"))
        {
            BeingTeleported?.Invoke();

            AllSceneManager._AllSceneManager.isTeleporting_ = true;

            //Debug.Log("teleport");
        }

        if (col.CompareTag("Enemy"))
        {
            PlayerGlobalCondition._PlayerGlobalCondition.player_hp -= 1;
            BeingAttacked.Invoke();
            Debug.Log("attacked");

        }

        if (col.CompareTag("Energy"))
        {

            AudioClip collectenergy = AudioCentreScript._audioCentreScript.player_sound[5];
            AudioSource.PlayClipAtPoint(collectenergy, GameObject.FindGameObjectWithTag("MainCamera").transform.position, 100.0f);

            PlayerGlobalCondition._PlayerGlobalCondition.player_fuel = PlayerGlobalCondition._PlayerGlobalCondition.player_fuel + 10;
        }

        if (col.CompareTag("MonsterBoxTrigger"))
        {
            MonsterBoxTriggered?.Invoke();
        }
    }

}
