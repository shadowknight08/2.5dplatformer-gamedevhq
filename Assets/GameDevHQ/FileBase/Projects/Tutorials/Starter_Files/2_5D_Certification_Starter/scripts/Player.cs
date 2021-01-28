using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController controller;
    private Animator anim;
    private Vector3 direction;
    [SerializeField]
    private float gravity = 1.0f;
    [SerializeField]
    private float jumphight = 10.0f;
    [SerializeField]
    private float speed = 5.0f;
    private bool jumping = false;
    private bool onledge;
    private LedgeChecker activeledge;


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (onledge == true)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                anim.SetTrigger("climbup");
            }
        }
        CalculateMovement();
    }

   void CalculateMovement()
    {

        if (controller.isGrounded == true)
        {
            if (jumping)
            {
                jumping = false;
                anim.SetBool("jump", jumping);
            }
            float h = Input.GetAxis("Horizontal");
            direction = new Vector3(0, 0, h) * speed;

            if (h != 0)
            {
                Vector3 facing = transform.localEulerAngles;
                facing.y = direction.z > 0 ? 0 : 180;
                transform.localEulerAngles = facing;

            }

            anim.SetFloat("speed", Mathf.Abs(h));
            if (Input.GetKeyDown(KeyCode.Space))
            {
                direction.y += jumphight;
                jumping = true;
                anim.SetBool("jump", jumping);
            }
        }
        if(controller.enabled==true)
        {
            direction.y -= gravity * Time.deltaTime;
            controller.Move(direction * Time.deltaTime);
        }
      
    }

     public void LedgeGrab(Vector3 handpos,LedgeChecker currentledge)
    {
        controller.enabled = false;
        anim.SetBool("Ledgegrab", true);
        anim.SetFloat("speed", 0.0f);
        anim.SetBool("jump", false);
        onledge = true;
        activeledge = currentledge;
        transform.position = handpos; 
    }

    public void ClimbComplete()
    {
        transform.position = activeledge.GetStandpos();
        anim.SetBool("Ledgegrab", false);
        controller.enabled = true;
    }
}
