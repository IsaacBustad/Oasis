using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private Camera fpCam;
    [SerializeField] private float range = 100f;
    [SerializeField] private ParticleSystem muzzleFlash;
    [SerializeField] private GameObject hitEffect;
    public float gunDamage = 50f;
    

    // on awake grab parrent camera
    private void Awake()
    {
        this.fpCam = this.transform.GetComponentInParent<Camera>();       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        PlayMuzzleFlash();
        ProcessRayCast();

    }

    private void ProcessRayCast()
    {
        RaycastHit hit;
        if (Physics.Raycast(this.fpCam.transform.position, this.fpCam.transform.forward, out hit, this.range))
        {
            Debug.Log("I hit " + hit.transform.name);
            Health target = hit.transform.GetComponent<Health>();
            GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impact, 1);
            if (target == null) return;
            target.ReduceHealth(this.gunDamage);
        }

        else
        {
            return;
        }
    }

    private void PlayMuzzleFlash()
    {
        this.muzzleFlash.Play();
    }


}
