using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    public GameObject Boss1;
    public GameObject Boss1SpawnPos;

    void Update()
    {
        if(MOvment.instanceMov.level == Level.BOSS1CLIMB)
        {
            Instantiate(Boss1, Boss1SpawnPos.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
