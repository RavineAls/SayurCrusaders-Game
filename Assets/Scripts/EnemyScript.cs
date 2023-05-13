using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyScript : MonoBehaviour
{
    public float iFrame = 0.3f;
    public bool vulnerable = true;
    public Transform playerTransform;
    public AudioSource hitSound;
    public float speed = 3;
    public float minDistance = 1.5f;
    string[] avoidTags = {"Enemy_Hard", "Enemy_Soft", "Player"};
    public int HealthPoint = 5;

    void Start()
    {
        vulnerable = true;
    }

    void Update()
    {
        if(HealthPoint<=0)
        {
            Destroy(gameObject);
        }
        Vector3 direction = (playerTransform.position - transform.position).normalized;
        direction.y = 0;
        Quaternion targetRotation = Quaternion.LookRotation(direction);

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);
        transform.Translate(direction * speed * Time.deltaTime, Space.World);

        Collider[] nearbyEnemies = Physics.OverlapSphere(transform.position, minDistance);
        foreach (Collider enemyCollider in nearbyEnemies)
        {
            if (enemyCollider != this.GetComponent<Collider>() && Array.IndexOf(avoidTags, enemyCollider.tag) != -1)
            {
                Vector3 avoidDirection = (transform.position - enemyCollider.transform.position).normalized;
                avoidDirection.y = 0;
                transform.Translate(avoidDirection * speed * Time.deltaTime, Space.World);
            }
        }
    }

    public IEnumerator iFrameCD(int damage)
    {
        vulnerable = false;
        HealthPoint -= damage;
        //GetComponent<Animator>().SetTrigger("A_Hit");
        hitSound.Play();
        transform.Translate(Vector3.back * Time.deltaTime * 100);
        yield return new WaitForSeconds(iFrame);
        vulnerable = true;
    }
}
