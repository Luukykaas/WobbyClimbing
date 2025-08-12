using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossGobAI : MonoBehaviour
{
    public GameObject Player;
    public GameObject Spawner;
    public GameObject IceBullet;
    public float rLerp = .01f;
    public float Bossspeed = 2.0f;
    public float BossgobHP = 200;
    public SpawnGob gobSpawn;
    MOvment Movement;

    private void Start()
    {
        gobSpawn = Spawner.GetComponent<SpawnGob>();
        Movement = Player.GetComponent<MOvment>();
        if (gameObject.name == "BossIceGob(Clone)") StartCoroutine("IceGobShoot");
    }
    private void Update()
    {
        if (gameObject.name == "BossIceGob")
        {

        }
        else
        {
            if (gameObject.name != "Gob1")
            {
                if (gameObject.name == "BossIceGob(Clone)")
                {
                    //speed *= 0.3f;
                    BossgobHP = 300;
                    transform.LookAt(Player.transform.position);
                    transform.Translate(Vector3.forward * Time.deltaTime * Bossspeed);
                }
                else
                {
                    transform.LookAt(Player.transform.position);
                    transform.Translate(Vector3.forward * Time.deltaTime * Bossspeed * 1);
                }
            }
        }
        if (BossgobHP < 0)
        {
            gobSpawn.killedBoss = true;
            Movement.key = true;
            Destroy(gameObject);
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
            for (int i = 0; i < 2; i++)
            {
                GameObject bullet = Instantiate(IceBullet, launcePos, Quaternion.identity);
                bullet.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * 9 * bullet.GetComponent<Rigidbody>().mass, ForceMode.Impulse);
                bullet.GetComponent<Transform>().rotation = new Quaternion(0, 90, 0, 0);
            }
        }
        else
        {
            GameObject bullet = Instantiate(IceBullet, launcePos, Quaternion.identity);
            bullet.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * 9 * bullet.GetComponent<Rigidbody>().mass, ForceMode.Impulse);
            bullet.GetComponent<Transform>().rotation = new Quaternion(0, 90, 0, 0);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                BossgobHP -= 1;
                Movement.hpP += 0.02;
            }
        }
    }

    IEnumerator IceGobShoot()
    {
        yield return new WaitForSeconds(Random.Range(1, 5));
        ShootIce(Random.Range(1, 2));
        StartCoroutine("IceGobShoot");
    }
}
