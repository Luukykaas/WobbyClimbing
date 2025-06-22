using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EggAi : MonoBehaviour
{
    public GameObject Slug;
    public GameObject Player;
    public float eggHP = 2;
    public MOvment Movement;

    private void Start()
    {
        StartCoroutine(Spawn());
        Movement = Player.GetComponent<MOvment>();
    }

    public void Update()
    {
        if (eggHP < 0)
        {
            Destroy(gameObject);
        }
        if (Movement.level == Level.BOSS1) gameObject.SetActive(true);
        else gameObject.SetActive(false);
    }
    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(Random.Range(1, 10));
        //int r = Mathf.Round(Random.Range(0, 10));
        for (int i = 0; i < 5; i++)
        {
            Instantiate(Slug, new Vector3(Random.Range(gameObject.transform.position.x - 20, gameObject.transform.position.x + 20), 0, Random.Range(gameObject.transform.position.z - 20, gameObject.transform.position.z + 20)), new Quaternion(0, 0, 0, 0));
            if(gameObject.name != "SlugEgg")
            {
                Destroy(gameObject);
            }

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.Mouse0)) eggHP -= 1;
        }
    }
}
