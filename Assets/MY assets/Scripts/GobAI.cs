using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GobAI : MonoBehaviour
{
    public GameObject Player;
    public GameObject Spawner;
    public float rLerp = .01f;
    public float speed = 3.0f;
    public float gobHP = 10;
    public SpawnGob gobSpawn;
    public MOvment Movement;

    private void Start()
    {
        gobSpawn = Spawner.GetComponent<SpawnGob>();
        Movement = Player.GetComponent<MOvment>();
    }
    private void Update()
    {
        transform.LookAt(Player.transform.position);
        transform.Translate(Vector3.forward * Time.deltaTime * speed * 1);
        if (gobHP < 0)
        {
            gobSpawn.killedGobs++;
            Destroy(gameObject);
        }
        if (Movement.level == Level.BIOME2) Destroy(gameObject);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.Mouse0)) gobHP -= 1;
        }
    }
}
