using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spwa : MonoBehaviour
{
    public GameObject spawner;
    public void Spwa(GameObject Sobject)
    {
        Instantiate(Sobject, spawner.transform.position, gameObject.transform.rotation);
    }
}
