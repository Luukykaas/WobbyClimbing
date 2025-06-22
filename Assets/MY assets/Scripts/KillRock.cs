using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillRock : MonoBehaviour
{
    MOvment Movement;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("KillRock"))
        {
            if (gameObject.CompareTag("Player"))
            {
                Movement = gameObject.GetComponent<MOvment>();
                Movement.PlayerDied();
            }
            else Destroy(gameObject);

        }
    }
}
