using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnRock : MonoBehaviour
{
    public GameObject Rock;
    public GameObject LevelManager;
    public double rock;
    public GameObject Player;
    public Vector3 Spawn;
    public float pGameMode;
    startButton buttons;
    public float rS;
    public MOvment Movement;
    private void Start()
    {
        buttons = LevelManager.GetComponent<startButton>();
        Movement = Player.GetComponent<MOvment>();
        rS = Random.Range(0f, 15f);
    }
    private void Update()
    {
        if (Movement.level == Level.BIOME1)
        {
            pGameMode = buttons.gameMode;
            rS = Random.Range(-9f, 9f);
            Spawn = new Vector3(rS, Player.transform.position.y + 40, 6);
            rock += 0.01;
            if (rock > buttons.gameMode)
            {
                rock = 0;
                Instantiate(Rock, Spawn, Quaternion.identity);
            }
        }
    }
}
