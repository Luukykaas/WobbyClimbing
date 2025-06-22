using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SludgeAI : MonoBehaviour
{
    public float wait = 5;
    public void Start()
    {
        if (gameObject.name == "PoolEmitter (1)") wait = 5;
        if (gameObject.name == "PoolEmitter (1) Variant") wait = 2;
        StartCoroutine(Die());
    }
    IEnumerator Die()
    {
        yield return new WaitForSeconds(wait);
        Destroy(gameObject);
    }
}
