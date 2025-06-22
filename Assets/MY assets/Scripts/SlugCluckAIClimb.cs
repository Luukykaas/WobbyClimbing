using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlugCluckAIClimb : MonoBehaviour
{
    public GameObject Player;
    public GameObject SludgeBomb;
    public int activeRow = 1;
    public float rowMove = 0f;
    public int r;

    private void Start()
    {
        StartCoroutine("MoveCollumn");
        StartCoroutine("DropSludgeBomb");
    }

    public void Update()
    {
        if (Player.transform.position.y > (gameObject.transform.position.y - 25)) {
            gameObject.transform.position += Vector3.up * 0.1f;
        }
        gameObject.transform.position += Vector3.right * rowMove;
        CheckIfReachedDestinationRow(r);
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
        yield return new WaitForSeconds(Random.Range(3, 8));
        SwitchCollumn();
        StartCoroutine("MoveCollumn");
    }

    IEnumerator DropSludgeBomb()
    {
        yield return new WaitForSeconds(Random.Range(0, 4));
        Instantiate(SludgeBomb, gameObject.transform.position, gameObject.transform.rotation);
        StartCoroutine("DropSludgeBomb");
    }
}
