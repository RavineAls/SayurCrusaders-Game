using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WeaponCollision : MonoBehaviour
{
    public SwordControl swrd;
    string[] enemyTags = {"Enemy_Hard", "Enemy_Soft"};

    private void OnTriggerEnter(Collider other)
    {
        if(Array.IndexOf(enemyTags, other.tag) != -1 && swrd.isAttacking && other.GetComponent<EnemyScript>().vulnerable){
            StartCoroutine(other.GetComponent<EnemyScript>().iFrameCD(swrd.damage));
        }
    }
}
