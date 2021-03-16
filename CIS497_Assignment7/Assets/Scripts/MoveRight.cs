/*
 * Chris Smith
 * MoveRight
 * Assignment 7
 * A Command that executes Moveable right and stores that movement in a stack, this can be undone.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRight : Command
{
    Moveable move;

    Stack<Vector3> history;

    public MoveRight(Moveable m)
    {
        this.move = m;
        history = new Stack<Vector3>();
    }

    public void Execute()
    {
        history.Push(move.GetPosition());
        move.MoveRight();

    }

    public void Undo()
    {
        if (history.Count != 0)
        {
            move.gameObject.transform.position = history.Pop();
        }

    }
}
