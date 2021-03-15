using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveable : MonoBehaviour
{
    public float moveDist;
    public LayerMask wall;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        moveDist = 25f;
        rb = GetComponent<Rigidbody>();
    }

    public Vector3 GetPosition()
    {
        return gameObject.transform.position;
    }

    public void MoveUp()
    {
        if (!Physics2D.OverlapCircle(transform.position + new Vector3(Input.GetAxisRaw("Vertical"), 0f, 0f), .2f, wall))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * moveDist);
        }

        //transform.Translate(Vector3.forward * /*Time.deltaTime */ moveDist);

        //rb.MovePosition(transform.position + Vector3.forward * Time.deltaTime * moveDist);
    }
    public void MoveLeft()
    {
        //transform.Translate(Vector3.left * /*Time.deltaTime */ moveDist);
        rb.MovePosition(transform.position + Vector3.left * Time.deltaTime * moveDist);
    }
    public void MoveRight()
    {
        //transform.Translate(Vector3.right * /*Time.deltaTime */ moveDist);
        rb.MovePosition(transform.position + Vector3.right * Time.deltaTime * moveDist);
    }
    public void MoveDown()
    {
        //transform.Translate(Vector3.back * /*Time.deltaTime */ moveDist);
        rb.MovePosition(transform.position + Vector3.back * Time.deltaTime * moveDist);
    }
}
