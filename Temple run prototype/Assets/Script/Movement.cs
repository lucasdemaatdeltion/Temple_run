using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float movementSpeed = 8;
    public float runSpeed;
    private float i;
    private float f;
    public Rigidbody rb;
    private Animator anim;
    private bool slide;
    private bool jumping;
    public float jumpPower;
    private bool grounded;
    private RaycastHit hit;

    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Waypoint")
        {
            if (f == -1)
            {
                i = -1;
            }

            else if (f == 1)
            {
                i = 1;
            }

        }

    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Waypoint")
        {
            if (i == -1)
            {
                StartCoroutine(Rotate(Vector3.up, -90, 0.3f));
            }
            if (i == 1)
            {
                StartCoroutine(Rotate(Vector3.up, 90, 0.3f));
            }
            i = 0;
        }
    }


    public void FixedUpdate()
    {
        f = Input.GetAxisRaw("LeftRight");

        //Hiermee kun je heen en weer lopen.
        //rb.transform.Translate(new Vector3(Input.GetAxisRaw("AD") * Time.deltaTime, 0, 0) * movementSpeed, Space.Self);

        //Dit is het zelfde als rb.MovePosition alleen dit is minder schoon.
        //rb.transform.position += transform.forward * Time.deltaTime * movementSpeed;

        //Met deze lijkt het alsof je over ijs rent en je accelereert.
        //rb.AddForce(transform.forward * runSpeed * Time.deltaTime, ForceMode.Force);

        //Dit is de makkelijkste en beste manier van rennen.
        rb.MovePosition(transform.position + transform.forward * movementSpeed * Time.deltaTime);

        //Dit werkt ook maar is moeilijk om goed te gebruiken en heeft een drag achter zich aan.
        //rb.velocity += transform.forward * movementSpeed * Time.deltaTime;

        if(Physics.Raycast(transform.position,Vector3.down,out hit, 0.15f))
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }

        if (Input.GetButton("Shift") && grounded == true)
        {
            slide = true;
            anim.SetBool("sliding", slide);
        }
        else
        {
            slide = false;
            anim.SetBool("sliding", slide);
        }
        if (Input.GetButtonDown("Jump") && grounded == true)
        {
            rb.AddForce(Vector3.up * jumpPower);
            jumping = true;
            anim.SetBool("jumping", jumping);
        }
        else
        {
            jumping = false;
            anim.SetBool("jumping", jumping);
        }
        
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        slide = false;
        jumping = false;
    }

    

    IEnumerator Rotate(Vector3 axis, float angle, float duration = 1.0f)
    {
        Quaternion from = rb.transform.rotation;
        Quaternion to = rb.transform.rotation;
        to *= Quaternion.Euler(axis * angle);

        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            rb.transform.rotation = Quaternion.Slerp(from, to, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.rotation = to;
    }
}