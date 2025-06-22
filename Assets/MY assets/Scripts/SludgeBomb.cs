using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SludgeBomb : MonoBehaviour
{
    public GameObject Explosion;
    public Rigidbody rigid;

    public void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision other)
    {
        if(rigid.velocity.y < -10)
        {
            Instantiate(Explosion, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
        }
    }
}
