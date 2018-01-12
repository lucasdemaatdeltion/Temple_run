using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    public int distance;

    void FixedUpdate()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        RaycastHit hit;

        if (Physics.Raycast(transform.position, fwd, out hit, distance) && hit.transform.tag == "AI")
        {
            print("AI");
        }
    }
}
