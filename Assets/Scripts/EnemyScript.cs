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
    public int enemyDamage = 1;
    public float knockBack = 100f;
    Rigidbody rb;
    public EnemyCounter enCount;
    public WaveSpawner wvSpwnr;
    public VictoryScreen vScrn;

    void Start()
    {
        vulnerable = true;
        rb = GetComponent<Rigidbody>();
        enCount.EnemySpawnedOrDestroyed();
    }

    void Update()
    {
        if(HealthPoint<=0)
        {
            StartCoroutine(enemyDead());
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
        //GetComponent<Animator>().SetTrigger("A_Hit");
        hitSound.Play();
        HealthPoint -= damage;
        transform.Translate(Vector3.back * Time.deltaTime * knockBack);
        yield return new WaitForSeconds(iFrame);
        vulnerable = true;
    }

    public IEnumerator enemyDead()
    {
        speed = 0;
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }

    void OnDestroy()
    {
        enCount.EnemySpawnedOrDestroyed();
        vScrn.updateDefEnemy();
        if(wvSpwnr != null)
        {
            wvSpwnr.EnemyDefeated();
        }
    }
}
