using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement01 : MonoBehaviour
{
    public Rigidbody rb;
    public float movementSpeed = 8;
    public float addForceSpeed;
    private Vector3 direction;
    private bool grounded;
    private RaycastHit hit;
    private Vector3 movement;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void FixedUpdate()
    {

        if (Physics.Raycast(transform.position, Vector3.down, out hit, 0.15f))
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }

        if (grounded == true)
        {
            //rb.transform.Translate(new Vector3(Input.GetAxisRaw("AD") * Time.deltaTime, 0, 0) * movementSpeed);
            float moveHorizontal = Input.GetAxis("AD");

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f);

            rb.AddRelativeForce(movement.normalized * addForceSpeed);
        }

    }
}
