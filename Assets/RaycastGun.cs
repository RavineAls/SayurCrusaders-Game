using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
[RequireComponent(typeof(LineRenderer))]
public class RaycastGun : MonoBehaviour
{
    public AudioSource Swing;
    public Camera playerCamera;
    public Transform laserOrigin;
    public float gunRange = 5f;
    public float fireRate = 0.1f;
    public float laserDuration = 0.05f;

    LineRenderer laserLine;
    float fireTimer;
 
    void Awake()
    {
        laserLine = GetComponent<LineRenderer>();
    }
    void Update()
    {
        fireTimer += Time.deltaTime;
        if(Input.GetButton("Fire1") && fireTimer > fireRate)
        {
            fireTimer = 0;
            laserLine.SetPosition(0, laserOrigin.position);
            Vector3 rayOrigin = playerCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;
            if(Physics.Raycast(rayOrigin, playerCamera.transform.forward, out hit, gunRange) && hit.transform.tag != "Immortal")
            {
                laserLine.SetPosition(1, hit.point);
                Destroy(hit.transform.gameObject);
            }
            else
            {
                laserLine.SetPosition(1, rayOrigin + (playerCamera.transform.forward * gunRange));
            }
            StartCoroutine(ShootLaser());
        }
    }
 
    IEnumerator ShootLaser()
    {
        laserLine.enabled = true;
        Swing.Play();
        yield return new WaitForSeconds(laserDuration);
        laserLine.enabled = false;
    }
}
