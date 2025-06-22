using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class IceCube : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine("Death");
    }

    IEnumerator Death()
    {
        yield return new WaitForSeconds(5);
        Debug.Log("Melt");
        Destroy(gameObject);
    }
}

