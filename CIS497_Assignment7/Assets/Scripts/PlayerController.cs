/*
 * Chris Smith
 * PlayerController
 * Assignment 7
 * A script to manage player inputs.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Moveable m;
    private Command moveLeft;
    private Command moveRight;
    private Command moveUp;
    private Command moveDown;
    public Stack<Command> history;

    public int movesUsed;
    public int maxMoves;
    public bool gameOver;
    public UIManager ui;

    void Awake()
    {
        moveLeft = new MoveLeft(m);
        moveRight = new MoveRight(m);
        moveUp = new MoveUp(m);
        moveDown = new MoveDown(m);
        history = new Stack<Command>();
        m = GetComponent<Moveable>();
        movesUsed = 0;
        maxMoves = 2500;
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (movesUsed >= maxMoves)
        {
            gameOver = true;
            ui.text.text = "Game Over! Press R to restart.";
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (!gameOver)
        {
            if (Input.GetKey(KeyCode.A))
            {
                moveLeft.Execute();
                history.Push(moveLeft);
                movesUsed++;
            }

            if (Input.GetKey(KeyCode.D))
            {
                moveRight.Execute();
                history.Push(moveRight);
                movesUsed++;
            }

            if (Input.GetKey(KeyCode.W))
            {
                moveUp.Execute();
                history.Push(moveLeft);
                movesUsed++;
            }

            if (Input.GetKey(KeyCode.S))
            {
                moveDown.Execute();
                history.Push(moveRight);
                movesUsed++;
            }

            if (Input.GetKey(KeyCode.Q))
            {
                if (history.Count != 0)
                {
                    Command last = history.Pop();
                    last.Undo();
                    movesUsed--;
                }
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Goal"))
        {
            gameOver = true;
            ui.text.text = "You Win! Press R to restart.";
        }
    }
}
