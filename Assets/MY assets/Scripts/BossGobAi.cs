using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossGobAI : MonoBehaviour
{
    public GameObject Player;
    public GameObject Spawner;
    public float rLerp = .01f;
    public float Bossspeed = 2.0f;
    public float BossgobHP = 200;
    public SpawnGob gobSpawn;
    MOvment Movement;

    private void Start()
    {
        gobSpawn = Spawner.GetComponent<SpawnGob>();
        Movement = Player.GetComponent<MOvment>();
    }
    private void Update()
    {
        transform.LookAt(Player.transform.position);
        transform.Translate(Vector3.forward * Time.deltaTime * Bossspeed * 1);
        if (BossgobHP < 0)
        {
            gobSpawn.killedGobs++;
            Movement.key = true;
            Destroy(gameObject);
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
}
