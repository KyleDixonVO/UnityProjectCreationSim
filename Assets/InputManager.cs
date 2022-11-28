using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public bool EscapePressed;
    public bool Win;
    public bool Lose;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            EscapePressed = !EscapePressed;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            Win = true;
        }
        else
        {
            Win = false;
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            Lose = true;
        }
        else
        {
            Lose = false;
        }
    }
}
