using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class GobAI : MonoBehaviour
{
    public GameObject Player;
    public GameObject Spawner;
    public GameObject IceBullet;
    public float rLerp = .01f;
    public float speed = 3.0f;
    public float gobHP = 10;
    public float shootSpeed = 5;
    public SpawnGob gobSpawn;
    public MOvment Movement;

    private void Start()
    {
        gobSpawn = Spawner.GetComponent<SpawnGob>();
        Movement = Player.GetComponent<MOvment>();
        if (gameObject.name == "IceGob(Clone)") StartCoroutine("IceGobShoot");
    }
    private void Update()
    {
        if(gameObject.name == "IceGob")
        {

        }
        else
        {
            if (gameObject.name != "Gob1")
            {
                if (gameObject.name == "IceGob(Clone)")
                {
                    //speed *= 0.3f;
                    gobHP = 15;
                    transform.LookAt(Player.transform.position);
                    transform.Translate(Vector3.forward * Time.deltaTime * speed);
                    if (gobHP < 0)
                    {
                        gobSpawn.killedGobs++;
                        Destroy(gameObject);
                    }
                    //if (Movement.level != Level.ICECAVE /*|| gobSpawn.killedBoss*/) Destroy(gameObject);
                }
                else
                {
                    transform.LookAt(Player.transform.position);
                    transform.Translate(Vector3.forward * Time.deltaTime * speed * 1);
                    if (gobHP < 0)
                    {
                        gobSpawn.killedGobs++;
                        Destroy(gameObject);
                    }
                    if (Movement.level != Level.CAVE || gobSpawn.killedBoss) Destroy(gameObject);
                }
            }
        }
        
    }

    public void ShootIce(int amountChance)
    {
        bool doubleShot = false;
        if (amountChance == 1)
        {
            doubleShot = true;
        }

        Vector3 launcePos = gameObject.transform.position;
        launcePos.y++;


        if (doubleShot)
        {
            for(int i = 0; i < 2; i++)
            {
                GameObject bullet = Instantiate(IceBullet, launcePos, Quaternion.identity);
                bullet.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * shootSpeed * bullet.GetComponent<Rigidbody>().mass, ForceMode.Impulse);
                bullet.GetComponent<Transform>().rotation = new Quaternion(0, 90, 0, 0);
            }
        }
        else
        {
            GameObject bullet = Instantiate(IceBullet, launcePos, Quaternion.identity);
            bullet.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * shootSpeed * bullet.GetComponent<Rigidbody>().mass, ForceMode.Impulse);
            bullet.GetComponent<Transform>().rotation = new Quaternion(0, 90, 0, 0);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.Mouse0)) gobHP -= 1;
        }
    }

    IEnumerator IceGobShoot()
    {
        yield return new WaitForSeconds(Random.Range(3, 8));
        ShootIce(Random.Range(1, 8));
        StartCoroutine("IceGobShoot");
    }
}
