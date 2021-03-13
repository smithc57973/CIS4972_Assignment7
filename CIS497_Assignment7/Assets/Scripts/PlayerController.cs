using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Moveable m;
    private Command moveLeft;
    private Command moveRight;
    private Command moveUp;
    private Command moveDown;

    public Stack<Command> history;
    public int movesUsed;

    void Awake()
    {
        moveLeft = new MoveLeft(m);
        moveRight = new MoveRight(m);
        moveUp = new MoveUp(m);
        moveDown = new MoveDown(m);
        history = new Stack<Command>();
        m = GetComponent<Moveable>();
        movesUsed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            moveLeft.Execute();
            history.Push(moveLeft);
        }

        if (Input.GetKey(KeyCode.D))
        {
            moveRight.Execute();
            history.Push(moveRight);
        }

        if (Input.GetKey(KeyCode.W))
        {
            moveUp.Execute();
            history.Push(moveLeft);
        }

        if (Input.GetKey(KeyCode.S))
        {
            moveDown.Execute();
            history.Push(moveRight);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            if (history.Count != 0)
            {
                Command last = history.Pop();
                last.Undo();
            }
        }
    }
}
