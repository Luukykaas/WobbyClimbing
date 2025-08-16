using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnGob : MonoBehaviour
{
    public GameObject Gob;
    public GameObject BossGob;
    public GameObject Player;
    public double rock = 0;
    public Vector3 Spawn;
    public float rS;
    public float rS2;
    public float timer = 5;
    public bool gobdMode = false;
    public int killedGobs = 0;
    public bool killedBoss = false;
    public int GobsForBoss = 20;
    MOvment Movement;
    private void Start()
    {
        rS = Random.Range(105f, 77f);
        rS2 = Random.Range(-6f, 33f);
        Movement = Player.GetComponent<MOvment>();
        StartCoroutine(SpawnGobTime());

    }
    private void Update()
    {
        if(gameObject.name == "IceGobSpawner")
        {
            rS = Random.Range(215f, 190f);
            rS2 = Random.Range(45f, 20f);
            Spawn = new Vector3(rS, 1.3f, rS2);

            if (killedGobs == GobsForBoss)
            {
                Instantiate(BossGob, Spawn, Quaternion.identity);
                killedGobs = 0;
            }
        }
        else
        { 
            rS = Random.Range(105f, 77f);
            rS2 = Random.Range(-6f, 33f);
            Spawn = new Vector3(rS, 2.5f, rS2);

            if (killedGobs == GobsForBoss)
            {
                Instantiate(BossGob, Spawn, Quaternion.identity);
                killedGobs = 0;
            }
        }
    }
    IEnumerator SpawnGobTime()
    {
        if (gobdMode) Instantiate(Gob, Spawn, Quaternion.identity);
        else
        {
            yield return new WaitForSeconds(timer);
            if (timer > 1) timer -= 0.1f;
            Instantiate(Gob, Spawn, Quaternion.identity);
        }
        StartCoroutine(SpawnGobTime());
    }
}
