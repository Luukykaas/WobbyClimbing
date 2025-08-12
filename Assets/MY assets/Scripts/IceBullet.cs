using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBullet : MonoBehaviour
{
    void Start()
    {
        StartCoroutine("Die");
    }

    IEnumerator Die()
    {
        yield return new WaitForSeconds(7);
        Destroy(gameObject);
    }
}
