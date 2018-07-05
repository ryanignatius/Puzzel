using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DummyMenu : MonoBehaviour
{

    private FirstPersonCamera firstPersonCamera;
    private Password password;
    private bool isStart;

    void Start()
    {
        firstPersonCamera = GameObject.Find("Main Camera").GetComponent<FirstPersonCamera>();
        if (firstPersonCamera != null)
        {
            firstPersonCamera.enabled = false;
        }
        password = GameObject.Find("Password").GetComponent<Password>();
        isStart = false;
    }

    void OnGUI()
    {
        if (!isStart)
        {
            GUI.Box(new Rect(0, 0, 320, 25), "Chose Level:");

            if (GUI.Button(new Rect(5, 35, 310, 100), "Easy"))
            {
                Password.SetPasswordWithHint("214", "#chair\n#skull\n#barrel");
                if (password != null)
                {
                    password.SetNormalFont();
                    password.ShowPassword();
                }
                StartGame();
            }

            if (GUI.Button(new Rect(5, 140, 310, 100), "Medium"))
            {
                Password.SetPasswordWithHint("0209140715", "01. Approach the door and enter the password below\n02. BINGO\n03. Congratulations! The door will open");
                if (password != null)
                {
                    password.SetNormalFont();
                    password.ShowPassword();
                }
                StartGame();
            }

            if (GUI.Button(new Rect(5, 245, 310, 100), "Hard"))
            {
                // WNNEESES
                // 53311818
                string pass = "";
                pass += "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$\n";
                pass += "$ +-+-+-+-+-+                     $\n";
                pass += "$ | |O|O|O| |   Y : your position $\n";
                pass += "$ +-+-+-+-+-+   D : door position $\n";
                pass += "$ | |O| |O|O|   O : safe position $\n";
                pass += "$ +-+-+-+-+-+                     $\n";
                pass += "$ |O|O|Y| |D|          N          $\n";
                pass += "$ +-+-+-+-+-+          ^          $\n";
                pass += "$ |O| |O|O| |       W < > E       $\n";
                pass += "$ +-+-+-+-+-+          v          $\n";
                pass += "$ |O| | |O|O|          S          $\n";
                pass += "$ +-+-+-+-+-+                     $\n";
                pass += "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$\n";

                Password.SetPasswordWithHint("53311818", pass);
                if (password != null)
                {
                    password.SetMonospaceFont();
                    password.ShowPassword();
                }
                StartGame();
            }

            GUI.Box(new Rect(0, 350, 320, 25), "Press H to open hint");
        }
    }

    private void StartGame() {
        isStart = true;
        if (firstPersonCamera != null)
        {
            firstPersonCamera.enabled = true;
        }
        else
        {
            //TODO investigate dark screen after change scene
            SceneManager.LoadScene("Puzzle1");
        }
    }
}
