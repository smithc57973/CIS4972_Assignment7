using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : Command
{
    Moveable move;

    Stack<Vector3> history;

    public MoveDown(Moveable m)
    {
        this.move = m;
        history = new Stack<Vector3>();
    }

    public void Execute()
    {
        history.Push(move.GetPosition());

        move.MoveDown();

    }

    public void Undo()
    {
        if (history.Count != 0)
        {
            move.gameObject.transform.position = history.Pop();
        }

    }
}
