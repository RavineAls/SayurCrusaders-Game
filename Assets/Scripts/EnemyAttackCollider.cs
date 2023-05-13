using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackCollider : MonoBehaviour
{
    public EnemyScript enScr;
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && other.GetComponent<PlayerScript>().vulnerable)
        {
            other.GetComponent<PlayerScript>().TakeDamage(enScr.enemyDamage);
        }
    }

}
