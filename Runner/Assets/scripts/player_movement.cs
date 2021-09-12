using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    //[SerializeField]
   //private Player_controller controller;
    [SerializeField]
    private player_data data;
    public KeyCode moveL;
    public KeyCode moveR;
    public KeyCode moveS;
    public KeyCode moveJ;

    private int forwardSpeed;
    public float horizSpeed = 5;

    public float jump_force = 10;

    public int laneNum = 2;
    public float new_lane_pos = 0;
    public float lane_horizGap = 2.5f;

    public bool controlBlocked;

    private Animator anim;
    public Collider full;
    public Collider half;

    private bool isGrounded = false;
    private bool changing_lane = false;
    public bool Run = false;

    private void Awake()
    {
        anim =transform.GetChild(0).GetComponent<Animator>();
    }

    void Start()
    {
        forwardSpeed = data.speed;
        half.enabled = false;
        full.enabled = true;
        run();
    }
    
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag.Equals("ground"))
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag.Equals("ground"))
        {
            isGrounded = false;
        }
    }

    public void run()
    {
        if (!Run)
        {
            Run = true;
            anim.SetTrigger("run");
            controlBlocked = false;
            GetComponent<Rigidbody>().useGravity = true;
        }
    }

    private void change_lane()
    {
        if (Mathf.Abs(transform.position.x - new_lane_pos) > .1f)
        {
            transform.position = new Vector3(Mathf.Lerp(transform.position.x, new_lane_pos, Time.deltaTime * horizSpeed), transform.position.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(new_lane_pos, transform.position.y, transform.position.z);
            changing_lane = false;
        }
    }

    public void turn_left()
    {
        if ((laneNum > 1) && (controlBlocked == false))
        {
            StartCoroutine(stopSlide(new_lane_pos - lane_horizGap));
            laneNum -= 1;
            controlBlocked = true;
            anim.SetTrigger("move left");
        }
    }

    public void turn_right()
    {
        if ((laneNum < 3) && (controlBlocked == false))
        {
            StartCoroutine(stopSlide(new_lane_pos + lane_horizGap));
            laneNum += 1;
            controlBlocked = true;
            anim.SetTrigger("move right");
        }
    }

    public void slide()
    {
        if (controlBlocked == false)
        {
            StartCoroutine(stopSlide(new_lane_pos));
            controlBlocked = true;
            full.enabled = false;
            half.enabled = true;
            anim.SetTrigger("slide");
        }
    }

    public void jump()
    {
        if (controlBlocked == false && isGrounded)
        {
            StartCoroutine(stopSlide(new_lane_pos));
            controlBlocked = true;
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * jump_force, ForceMode.VelocityChange);
            anim.SetTrigger("jump");
        }
    }

    public void hit()
    {
        controlBlocked = true;
        Run = false;
        anim.SetTrigger("fall");
    }

    

    // Update is called once per frame
    private void Update()
    {
        Debug.Log(controlBlocked);
        if(Run)
            transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);
        if (changing_lane)
        {
            change_lane();   
        }

        if (Input.GetKeyDown(moveL))
        {
            turn_left();
        }

        if (Input.GetKeyDown(moveR) && (laneNum < 3) && (controlBlocked == false))
        {
            turn_right();
        }

        if (Input.GetKeyDown(moveS) && (controlBlocked == false))
        {
            slide();
        }

        if (Input.GetKeyDown(moveJ) && (controlBlocked == false))
        {
            jump();
        }
    }

    

    IEnumerator stopSlide(float new_pos)
    {
        yield return new WaitForSeconds(.2f);
        new_lane_pos = new_pos;
        changing_lane = true;
        if(half.enabled)
            yield return new WaitForSeconds(.8f);
        else
            yield return new WaitForSeconds(.3f);
            
        changing_lane = false;
        half.enabled = false;
        full.enabled = true;
        controlBlocked = false;
    }
}
