using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    //+add shoot sound here

    public GameObject bullet;
    public Transform bulletPos;


    public void _Shoot()
    {

        AudioClip lasershoot = AudioCentreScript._audioCentreScript.player_sound[2];
        AudioSource.PlayClipAtPoint(lasershoot, GameObject.FindGameObjectWithTag("Player").transform.position, 1.0f);

        GameObject bulletSpawn = Instantiate(bullet, bulletPos.position, Quaternion.LookRotation(bulletPos.transform.right, Vector3.up));
        bulletSpawn.GetComponent<Rigidbody>().velocity = new Vector2(bulletPos.transform.right.x * PlayerGlobalCondition._PlayerGlobalCondition.bullet_speed, bulletPos.transform.right.y * PlayerGlobalCondition._PlayerGlobalCondition.bullet_speed);
        PlayerGlobalCondition._PlayerGlobalCondition.player_bullet--;
    }

}
