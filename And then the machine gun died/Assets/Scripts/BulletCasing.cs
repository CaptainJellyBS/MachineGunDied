using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCasing : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyC());
    }

    IEnumerator DestroyC()
    {
        yield return new WaitForSeconds(3.0f);
        Destroy(gameObject);
    }
}
