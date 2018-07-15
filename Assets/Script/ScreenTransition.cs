using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenTransition : MonoBehaviour {

    private enum FadeState { IN, OUT};
    public string nextScreen;
    private bool isFading;
    private float fadeTime;
    private float fadeAlpha;
    private FadeState state;

	// Use this for initialization
	void Start () {
        fadeTime = 3f;
        startFade(FadeState.IN);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnGUI()
    {
        if (isFading)
        {
            Camera camera = GetComponent<Camera>();
            Texture2D texture = new Texture2D(1, 1);
            float alpha = (state == FadeState.IN) ? fadeTime - fadeAlpha : fadeAlpha;
            texture.SetPixel(0, 0, new Color(1, 1, 1, alpha));
            texture.Apply();
            GUI.DrawTexture(new Rect(0, 0, camera.pixelWidth, camera.pixelHeight), texture);
            fadeAlpha += Time.deltaTime * 0.5f;

            if (fadeAlpha >= fadeTime)
            {
                isFading = false;
            }
        }
    }

    private void startFade(FadeState fade)
    {
        isFading = true;
        fadeAlpha = 0f;
        state = fade;
    }

    private void loadScene()
    {
        SceneManager.LoadScene(nextScreen);
    }

    public void startNextScene()
    {
        if (!string.IsNullOrEmpty(nextScreen))
        {
            startFade(FadeState.OUT);
            Invoke("loadScene", fadeTime - 1f);
        }
    }

}
