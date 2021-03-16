/*
 * Chris Smith
 * UIManager
 * Assignment 7
 * A script to manage UI elements.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text text;
    public GameObject tutorial;
    public PlayerController pc;

    // Start is called before the first frame update
    void Start()
    {
        tutorial.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (!pc.gameOver)
        {
            text.text = "Moves: " + pc.movesUsed + " / " + pc.maxMoves;
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            tutorial.SetActive(false);
        }
    }
}
