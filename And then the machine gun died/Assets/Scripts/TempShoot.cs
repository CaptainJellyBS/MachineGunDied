using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempShoot : MonoBehaviour
{
    public GameObject tracerBullet, bullet;
    public Transform leftSpawn, rightSpawn;
    public AudioSource[] leftSource, rightSource;

    private void Start()
    {
        StartCoroutine(ShootC());
    }

    IEnumerator ShootC()
    {
        int bar = 0;
        while(true)
        {
            Instantiate(tracerBullet, leftSpawn.position, leftSpawn.rotation);
            Instantiate(tracerBullet, rightSpawn.position, rightSpawn.rotation);
            leftSource[bar].Play(); rightSource[bar].Play(); bar++; bar %= leftSource.Length;

            yield return new WaitForSeconds(0.1f);

            for (int i = 0; i < 5; i++)
            {
                Instantiate(bullet, leftSpawn.position, leftSpawn.rotation);
                Instantiate(bullet, rightSpawn.position, rightSpawn.rotation);
                leftSource[bar].Play(); rightSource[bar].Play(); bar++; bar %= leftSource.Length;

                yield return new WaitForSeconds(0.1f);
            }
        }
    }
}
