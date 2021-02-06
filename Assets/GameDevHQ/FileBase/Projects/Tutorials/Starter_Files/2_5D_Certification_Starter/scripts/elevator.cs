using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevator : MonoBehaviour
{
    [SerializeField]
    private int speed = 3;
    [SerializeField]
    private Transform origin, target;
    private bool change = false;

    private IEnumerator waiting;

    //public Transform[] floor;
    //private bool movedown = true;
    //private bool moveup = false;

    public void FixedUpdate()
    {
        {
           
            if (transform.position == target.position)
            {
                waiting = Wait(5);
                StartCoroutine(waiting);
                change = true;
               
            }
            if (transform.position == origin.position)
            {
                waiting = Wait(5);
                StartCoroutine(waiting);
                change = false;
            }

           
            if (change)
            {
                transform.position = Vector3.MoveTowards(transform.position, origin.position, speed*Time.deltaTime);
                
            }
            else
            {
                
                transform.position = Vector3.MoveTowards(transform.position, target.position, speed*Time.deltaTime);
              
            }

            //if(movedown==true)
            //{
            //   MoveDown();
            //}

            //if(moveup==true)
            //{
            //    MoveUp();
            //}
        }
    }
        
       


    IEnumerator Wait(float time)
    {
        while (true)
        {
            yield return new WaitForSeconds(time);
        }
    }


    }



    //public void MoveDown()
    //{
    //    movedown = false;
    //    for (int i = 0; i <= (floor.Length-1); i++)
    //    {


    //        if (i == (floor.Length-1))
    //        {
    //            moveup = true;
    //            Debug.Log("its working");
    //            return;
    //        }

    //        else
    //        {
    //            transform.position = Vector3.MoveTowards(transform.position, floor[i + 1].position, speed * Time.deltaTime);
    //            if (transform.position == floor[i + 1].position)
    //            {
    //                Debug.Log("working" + i);
    //                StartCoroutine(Elevatortime());
    //            }
    //        }


    //    }
        
    //}


    //public void MoveUp()
    //{
    //    moveup = false;
    //    for (int i = floor.Length; i >= 0; i--)
    //    {


    //        if (i == 0)
    //        {
    //            movedown = true;
    //        }

    //        else
    //        {
    //            transform.position = Vector3.MoveTowards(transform.position, floor[i - 1].position, speed * Time.deltaTime);
    //            if (transform.position == floor[i - 1].position)
    //            {
    //                StartCoroutine(Elevatortime());
    //            }
    //        }


    //    }
    //}

    //public void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "Player")
    //    {
    //        other.transform.parent = this.transform;
    //    }

        
    //}

    //public void OnTriggerExit(Collider other)
    //{
    //    if (other.tag == "Player")
    //    {
    //        other.transform.parent = null;
    //    }
    //}

    

    

  
    

    

