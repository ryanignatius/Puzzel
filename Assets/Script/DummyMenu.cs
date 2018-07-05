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
                StartGame();
            }

            if (GUI.Button(new Rect(5, 140, 310, 100), "Medium"))
            {
                // not implemented yet
                //Password.SetPasswordWithHint("214", "#chair\n#skull\n#barrel");
                //StartGame();
            }

            if (GUI.Button(new Rect(5, 245, 310, 100), "Hard"))
            {
                // not implemented yet
                //Password.SetPasswordWithHint("214", "#chair\n#skull\n#barrel");
                //StartGame();
            }
        }
    }

    private void StartGame() {
        isStart = true;
        if (password != null)
        {
            password.ShowPassword();
        }
        if (firstPersonCamera != null)
        {
            firstPersonCamera.enabled = true;
        }
        //TODO investigate dark screen after change scene
        //SceneManager.LoadScene("Puzzle1");
    }
}
