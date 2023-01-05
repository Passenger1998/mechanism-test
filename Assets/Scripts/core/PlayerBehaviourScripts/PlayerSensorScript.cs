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

    public GameObject attackcollision_particle;

    bool mildwarning_emit = false;
    bool seriouswarning_emit = false;

    // Start is called before the first frame update
    void Start()
    {
        mildwarning_emit = false;
        seriouswarning_emit = false;
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


        if (PlayerGlobalCondition._PlayerGlobalCondition.player_hp <= 5 && PlayerGlobalCondition._PlayerGlobalCondition.player_hp > 0 && !mildwarning_emit)
        {
            mildwarning_emit = true;
            audiosource.mute = false;
            AudioSource.PlayClipAtPoint(mildwarning, this.gameObject.transform.position, 1.0f);

            //float timeBetweenShots = 15.0f;

            //audiosource.PlayOneShot(mildwarning, 1.0f);

            //float timer = 0.0f;
            //timer += Time.deltaTime;

            //if (timer < 15.0f)
            //{
            //    audiosource.PlayOneShot(mildwarning, 0.25f);
            //    timer = 0.0f;
            //}
            
        } else if (PlayerGlobalCondition._PlayerGlobalCondition.player_hp <= 2 && PlayerGlobalCondition._PlayerGlobalCondition.player_hp > 0 && !seriouswarning_emit)
        {
            seriouswarning_emit = true;
            audiosource.mute = false;
            AudioSource.PlayClipAtPoint(serioiuswarning, this.gameObject.transform.position, 1.0f);
            //float timeBetweenShots = 32.0f;
            //audiosource.PlayOneShot(serioiuswarning, 1.0f);

            //float timer = 0.0f;
            //timer += Time.deltaTime;

            //if (timer > 32.0f)
            //{
            //    audiosource.PlayOneShot(serioiuswarning, 0.25f);
            //    timer = 0.0f;
            //}



        }
        else if (PlayerGlobalCondition._PlayerGlobalCondition.player_hp > 5)
        {
            mildwarning_emit = false;
            seriouswarning_emit = false;
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
            Instantiate(attackcollision_particle, this.gameObject.transform.position, Quaternion.identity);
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
