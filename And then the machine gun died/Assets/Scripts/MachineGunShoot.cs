using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGunShoot : MonoBehaviour
{
    public AudioSource[] audioSources;
    public GameObject bulletPrefab, tracerPrefab, casingPrefab;
    public Transform bulletSpawn, casingSpawn;
    public int ammo = 600;
    public int tracerRatio = 6; //Amount of bullets shot per tracer bullet
    public float ejectForce;

    int audioIndex;
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetInteger("Ammo", ammo);
    }

    private void Update()
    {
        animator.SetBool("MousePressed", Input.GetMouseButton(0));
    }

    public void Shoot()
    {
        ammo--;
        animator.SetInteger("Ammo", ammo);

        GameObject actualBullet;
        if(ammo % tracerRatio == 0 || ammo < 20)
        {
            actualBullet = tracerPrefab;
        }
        else
        {
            actualBullet = bulletPrefab;
        }

        Instantiate(actualBullet, bulletSpawn.position, bulletSpawn.rotation);
    }


    public void PlayGunAudio()
    {
        audioIndex++; audioIndex %= audioSources.Length;
        audioSources[audioIndex].Play();
    }

    public void EjectCasing()
    {
        Rigidbody casebody = Instantiate(casingPrefab, casingSpawn.position, bulletSpawn.rotation).GetComponent<Rigidbody>();
        casebody.AddForce(casingSpawn.forward * ejectForce * Random.Range(0.8f,1.2f), ForceMode.Impulse);
    }
}
