using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LedgeChecker : MonoBehaviour
{
    [SerializeField]
    private Vector3 handpos,standpos;

    public void OnTriggerEnter(Collider other)
    {
        
        if(other.CompareTag("Ledgechecker"))
        {
            var player = other.transform.parent.GetComponent<Player>();


            if (player != null)
            {
                player.LedgeGrab(handpos,this);
            }
        }
    }

    public Vector3 GetStandpos()
    {
        return standpos;
    }
}