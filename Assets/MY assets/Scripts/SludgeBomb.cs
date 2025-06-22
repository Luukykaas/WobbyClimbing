using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SludgeBomb : MonoBehaviour
{
    public GameObject Explosion;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "BottomGround")
        {
            Instantiate(Explosion, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
        }
    }
}
