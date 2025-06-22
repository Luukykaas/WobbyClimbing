using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtSomething : MonoBehaviour
{
    public GameObject Focus;
    void Update()
    {
        transform.LookAt(Focus.transform.position);
    }
}
