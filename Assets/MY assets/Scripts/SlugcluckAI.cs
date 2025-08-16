using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlugcluckAI : MonoBehaviour
{
    public GameObject Player;
    public GameObject Sludge;
    public GameObject Egg;
    public GameObject SpitPrefab;
    public GameObject MouthPos;
    public GameObject NewPos;
    public MOvment Movement;
    public float speed = 3;
    public float spitSpeed = 1;
    public bool superSpit;
    public bool delay = false;
    public float HP = 200;
    public Vector3 eggSpawn;

    public void Update()
    {
        if (superSpit) Spit();
        if (Movement.level == Level.BOSS1) gameObject.SetActive(true);
        else gameObject.SetActive(false);
        if(HP < 0)
        {
            MOvment.instanceMov.level = Level.BOSS1CLIMB;
            MOvment.instanceMov.gameObject.transform.position = NewPos.transform.position;
        }
    }
    private void Start()
    {
        Movement = Player.GetComponent<MOvment>();
        StartCoroutine(SludgeCreate());
        StartCoroutine(EggCreate());
        StartCoroutine(SpitTime());
    }

    IEnumerator SludgeCreate()
    {
        yield return new WaitForSeconds(2);
        Instantiate(Sludge, gameObject.transform.position, gameObject.transform.rotation);
        StartCoroutine(SludgeCreate());
    }
    IEnumerator EggCreate()
    {
        yield return new WaitForSeconds(Random.Range(1, 10));
        eggSpawn.Set(Random.Range(gameObject.transform.position.x - 20, gameObject.transform.position.x + 20), 0, Random.Range(gameObject.transform.position.z - 20, gameObject.transform.position.z + 20));
        Instantiate(Egg, eggSpawn, new Quaternion(0, 0, 0, 0));
        StartCoroutine(EggCreate());
    }
    IEnumerator SpitTime()
    {
        yield return new WaitForSeconds(Random.Range(1, 2));
        Spit();
        StartCoroutine(SpitTime());
    }

    public void Spit ()
    {
        GameObject bullet = Instantiate(SpitPrefab, MouthPos.transform.position, MouthPos.transform.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(MouthPos.transform.forward * spitSpeed * bullet.GetComponent<Rigidbody>().mass, ForceMode.Impulse);
    }

    IEnumerator Damage()
    {
        yield return new WaitForSeconds(2);
        delay = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && Input.GetKey(KeyCode.Mouse0))
        {
            if(!delay)
            {
                HP -= 20;
                delay = true;
                StartCoroutine("Damage");
                other.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.back * 5, ForceMode.Impulse);
            }
        }
    }

}
