using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlugCluckAIClimb : MonoBehaviour
{
    public GameObject Player;
    public GameObject Butt;
    public GameObject SludgeBomb;
    public GameObject PowerUp1;
    public GameObject PowerUp2;
    public GameObject HpIncreaseParticles;
    public GameObject WinScreen;
    public int activeRow = 1;
    public float rowMove = 0f;
    public float BossHP = 100;
    public int r;

    private void Start()
    {
        StartCoroutine("MoveCollumn");
        StartCoroutine("DropSludgeBomb");
        StartCoroutine("SpawnPowerUp");
        StartCoroutine("HpIncrease");
    }

    public void Update()
    {
        transform.Translate(Vector3.forward * 0.05f);
        gameObject.transform.position += Vector3.right * rowMove;
        CheckIfReachedDestinationRow(r);
        if(BossHP < 0)
        {
            UIManager.instance.ChangeUIByGO(WinScreen);
            UIManager.instance.Freeze(true);
            Destroy(gameObject);
        }
    }
    
    public void SwitchCollumn()
    {
        r = Random.Range(1,3);
        if (r == 1) r = activeRow - 1;
        else r = activeRow + 1;

        if (activeRow == 0)
        {
            if (r == 1) rowMove = 0.1f;
        }
        if (activeRow == 1)
        {
            if (r == 2) rowMove = 0.1f;
            if (r == 0) rowMove = -0.1f;
        }
        if (activeRow == 2)
        {
            if (r == 1) rowMove = -0.1f;
        }
    }

    public void CheckIfReachedDestinationRow(int destination)
    {
        if(rowMove != 0)
        {
            if (destination == 0 && gameObject.transform.position.x < 300)
            {
                rowMove = 0;
                activeRow = destination;
            }
            if (destination == 1 && gameObject.transform.position.x < 305.5 && rowMove < 0) 
            { 
                rowMove = 0;
                activeRow = destination;
            }
            if (destination == 1 && gameObject.transform.position.x > 304.5 && rowMove > 0)
            {
                rowMove = 0;
                activeRow = destination;
            }
            if (destination == 2 && gameObject.transform.position.x > 311.8)
            {
                rowMove = 0;
                activeRow = destination;
            }
        }
    }

    IEnumerator MoveCollumn()
    {
        yield return new WaitForSeconds(Random.Range(2, 5));
        SwitchCollumn();
        StartCoroutine("MoveCollumn");
    }

    IEnumerator DropSludgeBomb()
    {
        yield return new WaitForSeconds(Random.Range(1, 4));
        Instantiate(SludgeBomb, Butt.transform.position, gameObject.transform.rotation);
        StartCoroutine("DropSludgeBomb");
    }

    IEnumerator SpawnPowerUp()
    {
        yield return new WaitForSeconds(Random.Range(5, 13));
        int r = Random.Range(1, 2);
        GameObject PowerUp  = r == 1 ? PowerUp1 : PowerUp2;
        Instantiate(PowerUp, Butt.transform.position, gameObject.transform.rotation);
        StartCoroutine("SpawnPowerUp");
    }

    IEnumerator HpIncrease()
    {
        yield return new WaitForSeconds(Random.Range(10, 25));
        BossHP += 50;
        Instantiate(HpIncreaseParticles, gameObject.transform.position, gameObject.transform.rotation);
        StartCoroutine("HpIncrease");
    }
}
