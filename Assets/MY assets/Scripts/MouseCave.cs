using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCave : MonoBehaviour
{
    public Vector2 turn;
    MOvment Movement;
    private void Start()
    {
        Movement = GetComponent<MOvment>();
    }
    private void Update()
    {
        turn.x += Input.GetAxis("Mouse X") * 2;
        if (Movement.level == Level.CAVE || Movement.isOnBGround && !UIManager.instance.freez) transform.localRotation = Quaternion.Euler(0, turn.x, 0);
    }
}
