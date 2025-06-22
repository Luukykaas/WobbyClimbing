using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class SlugAI : MonoBehaviour
{
    public GameObject Sludge;
    public GameObject Player;
    public float slugHP = 5;
    public bool onGround = false;
    public MOvment Movement;
    private void Start()
    {
        StartCoroutine(SludgeCreate());
        Movement = Player.GetComponent<MOvment>();
    }
    private void Update()
    {
        if (slugHP < 0)
        {
            Destroy(gameObject);
        }
        if (Movement.level == Level.BOSS1) gameObject.SetActive(true);
        else gameObject.SetActive(false);
    }

    IEnumerator SludgeCreate()
    {
        yield return new WaitForSeconds(0.3f);
        Instantiate(Sludge, gameObject.transform.position, gameObject.transform.rotation);
        StartCoroutine(SludgeCreate());
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.Mouse0)) slugHP -= 1;
        }
    }
}
