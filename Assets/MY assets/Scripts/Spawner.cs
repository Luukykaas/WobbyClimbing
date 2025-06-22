using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Spawner : MonoBehaviour
{
    public GameObject ObjectPrefab;
    public GameObject clone;
    public GameObject Player;
    public double timer = 0;
    public float Launce = 10f;
    public Vector3 Spawn;
    public bool fliped;
    public double Frames;
    public MOvment Movement;

    private void Start()
    {
        Movement = Player.GetComponent<MOvment>();
    }
    private void Update()
    {
        if (Movement.level == Level.BIOME2) 
        { 
            timer += 0.01;
            if (timer > 0.2)
            {
                timer = 0;
                Spawn = new Vector3(gameObject.transform.position.x, Random.Range(0f, 35f), gameObject.transform.position.z);
                clone = Instantiate(ObjectPrefab, Spawn, gameObject.transform.rotation);
                Launce = Random.Range(5f, 20f);
                if (fliped)
                {
                    clone.GetComponent<Rigidbody>().AddForce(Launce, Launce, 0, ForceMode.Impulse);
                }
                else clone.GetComponent<Rigidbody>().AddForce(-Launce, Launce, 0, ForceMode.Impulse);
            }
        }
    }
}
