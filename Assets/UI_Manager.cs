using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Manager : MonoBehaviour
{
    public Canvas mainMenu;
    public Canvas pause;
    public Canvas options;
    public Canvas win;
    public Canvas gameover;
    public Canvas gameplay;
    public Canvas credits;
    public Slider slider;
    public TMP_Text loadTimeText;

    // Start is called before the first frame update

    private void Awake()
    {
        mainMenu = GameObject.Find("MainMenuCanvas").GetComponent<Canvas>();
        pause = GameObject.Find("PauseCanvas").GetComponent<Canvas>();
        options = GameObject.Find("OptionsCanvas").GetComponent<Canvas>();
        win = GameObject.Find("WinCanvas").GetComponent<Canvas>();
        gameover = GameObject.Find("GameoverCanvas").GetComponent<Canvas>();
        gameplay = GameObject.Find("GameplayCanvas").GetComponent<Canvas>();
        credits = GameObject.Find("CreditsCanvas").GetComponent<Canvas>();
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        loadTimeText.text = slider.value.ToString();
    }

    public void MainMenu()
    {
        mainMenu.enabled = true;
        pause.enabled = false;
        options.enabled = false;
        win.enabled = false;
        gameover.enabled = false;
        credits.enabled = false;
        gameplay.enabled = false;
    }

    public void Pause()
    {
        mainMenu.enabled = false;
        pause.enabled = true;
        options.enabled = false;
        win.enabled = false;
        gameover.enabled = false;
        credits.enabled = false;
        gameplay.enabled = true;
    }

    public void Options()
    {
        mainMenu.enabled = false;
        pause.enabled = false;
        options.enabled = true;
        win.enabled = false;
        gameover.enabled = false;
        credits.enabled = false;
        gameplay.enabled = false;
    }

    public void Credits()
    {
        mainMenu.enabled = false;
        pause.enabled = false;
        options.enabled = false;
        win.enabled = false;
        gameover.enabled = false;
        credits.enabled = true;
        gameplay.enabled = false;
    }

    public void Gameplay()
    {
        mainMenu.enabled = false;
        pause.enabled = false;
        options.enabled = false;
        win.enabled = false;
        gameover.enabled = false;
        credits.enabled = false;
        gameplay.enabled = true;
    }

    public void Win()
    {
        mainMenu.enabled = false;
        pause.enabled = false;
        options.enabled = false;
        win.enabled = true;
        gameover.enabled = false;
        credits.enabled = false;
        gameplay.enabled = false;
    }

    public void Gameover()
    {
        mainMenu.enabled = false;
        pause.enabled = false;
        options.enabled = false;
        win.enabled = false;
        gameover.enabled = true;
        credits.enabled = false;
        gameplay.enabled = false;
    }


}
