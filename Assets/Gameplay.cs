using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Gameplay : MonoBehaviour
{
    public bool unityOpen;
    private bool unityStartTimeCaptured;
    public bool winGame;
    public GameObject packageManager;
    public float timeElapsed;
    public float unityStartTime;
    public float endTime;
    private float minLoadTime = 20.0f;
    private float maxLoadTime = 180.0f;
    private int minutes;
    private int seconds;
    public int random;
    public TMP_Text tooltip;
    public TMP_Text progressTimer;
    public Slider packageManagerSlider;
    public Slider loadTimeSlider;
    public LevelManager levelManager;

    public string[] tooltips = new string[]
    {
        "Making a coffee", 
        "Learning to knit", 
        "Reconnecting with your loved ones", 
        "Complaining about NFTs", 
        "Hacking the mainframe",
        "Experiencing intrusive thoughts",
        "Thinking about birds",
        "Loading project files",
        "Re-serializing assets",
        "Doing karate kicks",
        "Taking a break",
        "Holding back a sneeze",
        "Procrastinating",
        "Giving out red flags",
        "Loading a different project",
        "Building a family",
        "Tracking your location",
        "Meeting your parents"
    };

    // Start is called before the first frame update
    void Start()
    {
        //packageManager = GameObject.Find("PackageManager");
        //tooltip = GameObject.Find("Tooltip").GetComponent<TMP_Text>();
        //progressTimer = GameObject.Find("Progress Timer").GetComponent<TMP_Text>();
        //packageManagerSlider = GameObject.Find("packageManagerSlider").GetComponent<Slider>();
        endTime = minLoadTime;
        unityOpen = false;
        unityStartTimeCaptured = false;
        winGame = false;
        packageManager.SetActive(false);
    }

    public void Reset()
    {
        endTime = minLoadTime;
        unityOpen = false;
        unityStartTimeCaptured = false;
        winGame = false;
        packageManager.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (levelManager.state == LevelManager.UI_States.pause) return;

        endTime = loadTimeSlider.value;

        if (unityOpen == false) return;
        random = Random.Range(0, 500);
        if (random == 1)
        {
            Debug.Log(random);
            tooltip.text = tooltips[Random.Range(0, tooltips.Length - 1)];
        }


        if (unityOpen == true)
        {
            timeElapsed = (Time.fixedTime - unityStartTime);
        }
        seconds = (int)timeElapsed;
        minutes = (int)timeElapsed / 60;

        if (minutes != 0)
        {
            seconds = (int)timeElapsed - (minutes * 60);
        }

        if (minutes != 0)
        {
            if (seconds < 10)
            {
                progressTimer.text = tooltip.text + " (busy for " + minutes + ":" + 0.ToString() + seconds + ")";
            }
            else
            {
                progressTimer.text = tooltip.text + " (busy for " + minutes + ":" + seconds + ")";
            }
        }
        else
        {
            progressTimer.text = tooltip.text + " (busy for " + seconds + "s)";
        }

        if (timeElapsed >= endTime)
        {
            winGame = true;
        }
        else
        {
            packageManagerSlider.value = timeElapsed / endTime;
        }
    }

    public void OpenUnity()
    {
        if (unityOpen == false)
        {
            packageManager.SetActive(true);
            unityOpen = true;

            if (unityStartTimeCaptured == false)
            {
                unityStartTime = Time.time;
                unityStartTimeCaptured = true;
            }
        }
    }
}
