using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordControl : MonoBehaviour
{
    public float swingRate = 0.5f;
    public GameObject Sword;
    public AudioSource SwingSound;
    public bool CanAttack = true;
    public bool isAttacking = false;
    float swingTimer;
    // Start is called before the first frame update
    void Start()
    {
        Animator SWG = Sword.GetComponent<Animator>();
        SWG.Play("Idle");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1") && CanAttack)
        {
            isAttacking = true;
            CanAttack=false;
            Animator SWG = Sword.GetComponent<Animator>();
            SWG.SetTrigger("Attack");
            SwingSound.Play();
            StartCoroutine(SwingCD());
        }
    }
    IEnumerator SwingCD()
    {
        yield return new WaitForSeconds(swingRate);
        isAttacking = false;
        CanAttack = true;
    }
}
