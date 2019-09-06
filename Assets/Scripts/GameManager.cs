using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState {
    menu,
    inGame,
    gameOver
}

public class GameManager : MonoBehaviour
{
    // Sigleton patter, class can be instantiated only once
    public static GameManager sharedInstance;

    private void Awake()
    {
        sharedInstance = this;
    }
    // Gets the game current state, in menu by default
    public GameState currentState = GameState.menu;

    public void StartGame() {
        setGamestate(GameState.inGame);
    }

    public void GameOver() {
        setGamestate(GameState.gameOver);
    }

    public void BackToMenu() {
        setGamestate(GameState.menu);

    }

    public void Start()
    {
        BackToMenu();
    }

    public void Update()
    {
        if (Input.GetButtonDown("Start")) {
            StartGame();
        }
        if (Input.GetButtonDown("Pause"))
        {
            BackToMenu();
        }
    }

    void setGamestate(GameState state) {

        if (state == GameState.menu)
        {
            // Set menu logic here
        }
        else if (state == GameState.inGame)
        {
            // Set inGame logic here
        }
        else if (state == GameState.gameOver) {
            // Set gameover here
        }

        this.currentState = state;
    }
}
