using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SludgeBombExplosion : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine("Kill");
    }

    IEnumerator Kill()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
