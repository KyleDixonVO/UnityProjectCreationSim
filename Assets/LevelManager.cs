using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public enum UI_States 
    { 
        mainMenu,
        gameover,
        win,
        credits,
        gameplay,
        options,
        pause
    }

    public float pausedScale = 0.0f;
    public float resumedScale = 1.0f;

    public UI_States state;
    public UI_States previousState;
    public UI_States returnFromOptions;

    public UI_Manager ui_Manager;
    public Gameplay gameplay;

    public InputManager inputManager;

    private void Awake()
    {
        ui_Manager = GameObject.Find("UI_Manager").GetComponent<UI_Manager>();
        inputManager = GameObject.Find("InputManager").GetComponent<InputManager>();
        gameplay = GameObject.Find("GameplayManager").GetComponent<Gameplay>();
        state = UI_States.mainMenu;
        Time.timeScale = resumedScale;
    }

    // Start is called before the first frame update
    void Start()
    {
        SwitchMainMenu();
    }

    // Update is called once per frame
    void Update()
    { 
        if (state == UI_States.gameplay && inputManager.EscapePressed)
        {
            previousState = state;
            state = UI_States.pause;
        }
        else if(state == UI_States.pause && !inputManager.EscapePressed)
        {
            state = previousState;
        }

        if (state == UI_States.gameplay && inputManager.Win)
        {
            state = UI_States.win;
        }

        if (state == UI_States.gameplay && inputManager.Lose)
        {
            state = UI_States.gameover;
        }

        if (state == UI_States.gameplay && gameplay.winGame)
        {
            state = UI_States.win;
        }

        EvaluateSwitch();
    }

    public void SwitchGameplay()
    {
        state = UI_States.gameplay;
        inputManager.EscapePressed = false;
    }

    public void SwitchOptions()
    {
        returnFromOptions = state;
        state = UI_States.options;
    }

    public void ReturnFromOptions()
    {
        state = returnFromOptions;
    }

    public void SwitchMainMenu()
    {
        state = UI_States.mainMenu;
        gameplay.Reset();
    }

    public void SwitchCredits()
    {
        state = UI_States.credits;
    }

    public void EvaluateSwitch()
    {
        switch (state)
        {
            case UI_States.mainMenu:
                ui_Manager.MainMenu();
                Time.timeScale = resumedScale;
                break;

            case UI_States.gameover:
                ui_Manager.Gameover();
                Time.timeScale = resumedScale;
                break;

            case UI_States.win:
                ui_Manager.Win();
                Time.timeScale = resumedScale;
                break;

            case UI_States.credits:
                ui_Manager.Credits();
                Time.timeScale = resumedScale;
                break;

            case UI_States.options:
                ui_Manager.Options();
                Time.timeScale = pausedScale;
                break;

            case UI_States.gameplay:
                ui_Manager.Gameplay();
                Time.timeScale = resumedScale;
                break;

            case UI_States.pause:
                ui_Manager.Pause();
                Time.timeScale = pausedScale;
                break;
        }
    }
}
