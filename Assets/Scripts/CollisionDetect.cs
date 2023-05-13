using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetect : MonoBehaviour
{
    public SwordControl swrd;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy_Hard" && swrd.isAttacking && other.GetComponent<EnemyScript>().vulnerable){
            StartCoroutine(other.GetComponent<EnemyScript>().iFrameCD(swrd.damage));
        }

        if(other.tag == "Enemy_Soft" && swrd.isAttacking && other.GetComponent<EnemyScript>().vulnerable){
            StartCoroutine(other.GetComponent<EnemyScript>().iFrameCD(swrd.damage));
        }
    }
}
