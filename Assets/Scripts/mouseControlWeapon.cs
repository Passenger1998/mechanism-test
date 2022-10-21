using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Experimental.AI;

public class mouseControlWeapon : MonoBehaviour
{
    public Transform Cannon;
    public float cannonSpeed;

    private void Update()
    {
        RotateCannon();
    }

    void RotateCannon()
    {

        //what direction should we point in?
        //Input.mousePosition (but imn world space) minus the position of this ccharacter
        //noirmalise thzat
        ///Cannon.rotation.SetLookRotation(TerrainHeightmapSyncControl duirectrion);

        //float ZaxisRotation = Input.GetAxis("Mouse Z") * cannonSpeed;
        //transform
    }
}
