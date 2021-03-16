/*
 * Chris Smith
 * Moveable
 * Assignment 7
 * A script for objects that can be moved. 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveable : MonoBehaviour
{
    public float moveDist;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        moveDist = 30f;
        rb = GetComponent<Rigidbody>();
    }

    public Vector3 GetPosition()
    {
        return gameObject.transform.position;
    }

    public void MoveUp()
    {
        rb.MovePosition(transform.position + Vector3.forward * Time.deltaTime * moveDist);
    }
    public void MoveLeft()
    {rb.MovePosition(transform.position + Vector3.left * Time.deltaTime * moveDist);
    }
    public void MoveRight()
    {rb.MovePosition(transform.position + Vector3.right * Time.deltaTime * moveDist);
    }
    public void MoveDown()
    {
        rb.MovePosition(transform.position + Vector3.back * Time.deltaTime * moveDist);
    }
}
