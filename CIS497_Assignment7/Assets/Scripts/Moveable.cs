using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveable : MonoBehaviour
{
    public float moveDist;

    // Start is called before the first frame update
    void Start()
    {
        moveDist = 5f;
    }

    public Vector3 GetPosition()
    {
        return gameObject.transform.position;
    }

    public void MoveUp()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * moveDist);
    }
    public void MoveLeft()
    {
        transform.Translate(Vector3.left * Time.deltaTime * moveDist);
    }
    public void MoveRight()
    {
        transform.Translate(Vector3.right * Time.deltaTime * moveDist);
    }
    public void MoveDown()
    {
        transform.Translate(Vector3.back * Time.deltaTime * moveDist);
    }
}
