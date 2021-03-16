/*
 * Chris Smith
 * Command
 * Assignment 7
 * An interface for Commands which must be executable and undoable.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Command
{
    void Execute();
    void Undo();
}
