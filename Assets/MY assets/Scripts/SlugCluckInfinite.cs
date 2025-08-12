using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlugCluckInfinite : MonoBehaviour
{
    public GameObject Player;
    void Update()
    {
        if(Player.transform.position.y > gameObject.transform.position.y + 58)
        {
            transform.Translate(Vector3.up * 194);
        }
    }
}
