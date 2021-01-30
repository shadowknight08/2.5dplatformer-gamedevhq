using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LedgeChecker : MonoBehaviour
{
    [SerializeField]
    private Transform standpos;
    [SerializeField]
    private Transform handpos;

    public void OnTriggerEnter(Collider other)
    {
        
        if(other.CompareTag("Ledgechecker"))
        {
            var player = other.transform.parent.GetComponent<Player>();


            if (player != null)
            {
                player.LedgeGrab(handpos.position,this);
            }
        }
    }

    public Vector3 GetStandpos()
    {
        return standpos.position;
    }
}