﻿using UnityEngine;
using System.Collections;

public class Keypad : MonoBehaviour
{
    private string input;
    private bool doorOpen;
    private bool keypadScreen;
    private bool isShow;
    private Collider door;

    void Start()
    {
        doorOpen = false;
        keypadScreen = false;
        input = "";
        isShow = false;
    }

    void OnGUI()
    {
        if (!doorOpen)
        {
            if (keypadScreen)
            {
                GUI.Box(new Rect(0, 0, 200, 25), "Password:");

                GUI.Box(new Rect(0, 0, 320, 455), "");
                GUI.Box(new Rect(5, 5, 310, 25), input);

                if (GUI.Button(new Rect(5, 35, 100, 100), "1"))
                {
                    input = input + "1";
                }

                if (GUI.Button(new Rect(110, 35, 100, 100), "2"))
                {
                    input = input + "2";
                }

                if (GUI.Button(new Rect(215, 35, 100, 100), "3"))
                {
                    input = input + "3";
                }

                if (GUI.Button(new Rect(5, 140, 100, 100), "4"))
                {
                    input = input + "4";
                }

                if (GUI.Button(new Rect(110, 140, 100, 100), "5"))
                {
                    input = input + "5";
                }

                if (GUI.Button(new Rect(215, 140, 100, 100), "6"))
                {
                    input = input + "6";
                }

                if (GUI.Button(new Rect(5, 245, 100, 100), "7"))
                {
                    input = input + "7";
                }

                if (GUI.Button(new Rect(110, 245, 100, 100), "8"))
                {
                    input = input + "8";
                }

                if (GUI.Button(new Rect(215, 245, 100, 100), "9"))
                {
                    input = input + "9";
                }

                if (GUI.Button(new Rect(110, 350, 100, 100), "0"))
                {
                    input = input + "0";
                }

                if (GUI.Button(new Rect(5, 350, 100, 100), "Clear"))
                {
                    input = "";
                }

                if (GUI.Button(new Rect(215, 350, 100, 100), "Submit"))
                {
                    if (Password.CheckPassword(input))
                    {
                        doorOpen = true;
                        if (door != null)
                        {
                            door.GetComponent<Animator>().SetTrigger("DoorATrigger");
                        }
                    }
                    else
                    {
                        input = "";
                    }
                }
            }
        }
    }

    public void Reset()
    {
        keypadScreen = false;
        input = "";
        isShow = false;
    }

    public void Show(Collider _door)
    {
        if (!isShow)
        {
            isShow = true;
            door = _door;
            keypadScreen = true;
            input = "";
        }
    }
}
