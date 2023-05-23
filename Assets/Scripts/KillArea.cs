using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player")){
            other.gameObject.GetComponent<PlayerScript>().TakeDamage(99);
        }
        if(other.gameObject.CompareTag("Enemy_Hard")){
            StartCoroutine(other.gameObject.GetComponent<EnemyScript>().iFrameCD(99));
        }

        if(other.gameObject.CompareTag("Enemy_Soft")){
            StartCoroutine(other.gameObject.GetComponent<EnemyScript>().iFrameCD(99));
        }
    }
}
