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
    public float timer = 4;
    public bool gobdMode = false;
    public int killedGobs = 0;
    const int GOBSFORBOSS = 20;
    MOvment Movement;
    private void Start()
    {
        rS = Random.Range(105f, 77f);
        rS2 = Random.Range(-6f, 33f);
        Movement = Player.GetComponent<MOvment>();
    }
    private void Update()
    {
        rS = Random.Range(105f, 77f);
        rS2 = Random.Range(-6f, 33f);
        Spawn = new Vector3(rS, 2.5f, rS2);
        rock += 0.1;
        if( (rock > timer) && (Movement.level == Level.CAVE) )
        {
            rock = 0;
            if(timer > 0) timer -= 0.03f;
            Instantiate(Gob, Spawn, Quaternion.identity);
        }

        if(gobdMode) Instantiate(Gob, Spawn, Quaternion.identity);

        if (killedGobs == GOBSFORBOSS)
        {
            Instantiate(BossGob, Spawn, Quaternion.identity);
            killedGobs = 0;
        }
    }
}
