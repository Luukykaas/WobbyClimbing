using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBreaker : MonoBehaviour
{
    public GameObject clone;
    public GameObject IceCube;
    public Vector3 RRotation;
    public int blocks1 = 1;
    public int blocks2 = 15;

    private void Update()
    {
        RRotation = new Vector3(UnityEngine.Random.Range(0f, 360f), UnityEngine.Random.Range(0f, 360f), UnityEngine.Random.Range(0f, 360f));
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ice"))
        {
            int c;
            int total = UnityEngine.Random.Range(blocks1, blocks2);
            for (c=0; c<total; c++)
            {
                clone = Instantiate(IceCube, gameObject.transform.position, gameObject.transform.rotation);
            }
            Destroy(gameObject);
        }
    }
}
