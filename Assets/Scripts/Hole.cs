﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    bool fallIn;
    public string activeTag;


    public bool IsFallIn()
    {
        return fallIn;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag==activeTag)
        {
            fallIn = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == activeTag)
        {
            fallIn = false;
        }
    }
    // Start is called before the first frame update
    void OnTriggerStay (Collider other)
    {
        Rigidbody r = other.gameObject.GetComponent<Rigidbody>();

        Vector3 direction = transform.position - other.gameObject.transform.position;
        direction.Normalize();

        if(other.gameObject.tag==activeTag)
        {
            r.velocity *= 0.9f;

            r.AddForce(direction * r.mass * 20.0f);
        }
        else
        {
            r.AddForce(-direction * r.mass * 80.0f);
        }
    }
}
