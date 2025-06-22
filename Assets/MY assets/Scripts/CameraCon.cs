using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraCon : MonoBehaviour
{
    public Transform camTarget;
    public float pLerp = .02f;
    public float rLerp = .01f;
    public bool shop = false;
    public bool disabled = false;
    private void Start()
    {
        disabled = false;
    }
    void Update()
    {
        if (!disabled)
        {
            transform.position = Vector3.Lerp(transform.position, camTarget.position, pLerp);
            transform.rotation = Quaternion.Lerp(transform.rotation, camTarget.rotation, rLerp);
        }
    }
    public void Shop ()
    {
        shop = true;
    }
    public void QuitShop ()
    {
        shop = false;
    }
}


