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
    public bool canMove;
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
        maxMoves = 10;
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (movesUsed == maxMoves)
        {
            canMove = false;
            ui.text.text = "Game Over! Press R to restart.";
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (canMove)
        {
            if (Input.GetKey(KeyCode.A) && checkWall(Vector3.left))
            {
                moveLeft.Execute();
                history.Push(moveLeft);
                movesUsed++;
                canMove = false;
                StartCoroutine(Cooldown());
            }

            if (Input.GetKey(KeyCode.D) && checkWall(Vector3.right))
            {
                moveRight.Execute();
                history.Push(moveRight);
                movesUsed++;
                canMove = false;
                StartCoroutine(Cooldown());
            }

            if (Input.GetKey(KeyCode.W) && checkWall(Vector3.forward))
            {
                moveUp.Execute();
                history.Push(moveLeft);
                movesUsed++;
                canMove = false;
                StartCoroutine(Cooldown());
            }

            if (Input.GetKey(KeyCode.S) && checkWall(Vector3.back))
            {
                moveDown.Execute();
                history.Push(moveRight);
                movesUsed++;
                canMove = false;
                StartCoroutine(Cooldown());
            }

            if (Input.GetKey(KeyCode.Q))
            {
                if (history.Count != 0)
                {
                    Command last = history.Pop();
                    last.Undo();
                    movesUsed--;
                    canMove = false;
                    StartCoroutine(Cooldown());
                }
            }
        }
    }

    public IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(1f);
        canMove = true;
        yield return new WaitForSeconds(1f);
    }

    public bool checkWall(Vector3 direction)
    {
        Ray r = new Ray(transform.position + new Vector3(0, 0.25f, 0), direction);
        RaycastHit h;

        if (Physics.Raycast(r, out h))
        {
            if (h.collider.tag == "Wall")
            {
                return false;
            }
        }
        return true;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Goal"))
        {
            canMove = false;
            ui.text.text = "You Win! Press R to restart.";
        }
    }
}
