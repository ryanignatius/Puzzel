using UnityEngine;
using System.Collections;
using TMPro;

public class Password : MonoBehaviour
{
    private static string PASSWORD = "123";
    private static string HINT = "123";

    public static void SetPasswordWithHint(string newPassword, string newHint)
    {
        PASSWORD = newPassword;
        HINT = newHint;
    }

    public static bool CheckPassword(string pass)
    {
        return PASSWORD == pass;
    }

    private TextMeshPro m_textMeshPro;
    private TMP_FontAsset m_FontAsset;
    private const string label = "Password:\n";
    private Camera passwordCamera;

    void Start()
    {
        passwordCamera = transform.parent.GetComponent<Camera>();
        if (passwordCamera != null)
        {
            passwordCamera.enabled = false;
        }

        // Add new TextMesh Pro Component
        m_textMeshPro = gameObject.AddComponent<TextMeshPro>();

        m_textMeshPro.autoSizeTextContainer = true;

        // Load the Font Asset to be used.
        //m_FontAsset = Resources.Load("Fonts & Materials/Electronic Highway Sign SDF", typeof(TMP_FontAsset)) as TMP_FontAsset;
        //m_textMeshPro.font = m_FontAsset;

        // Assign Material to TextMesh Pro Component
        //m_textMeshPro.fontSharedMaterial = Resources.Load("Fonts & Materials/LiberationSans SDF - Bevel", typeof(Material)) as Material;
        //m_textMeshPro.fontSharedMaterial.EnableKeyword("BEVEL_ON");

        // Set various font settings.
        m_textMeshPro.fontSize = 8;

        m_textMeshPro.alignment = TextAlignmentOptions.Center;

        //m_textMeshPro.anchorDampening = true; // Has been deprecated but under consideration for re-implementation.
        //m_textMeshPro.enableAutoSizing = true;

        //m_textMeshPro.characterSpacing = 0.2f;
        //m_textMeshPro.wordSpacing = 0.1f;

        //m_textMeshPro.enableCulling = true;
        m_textMeshPro.enableWordWrapping = false;

        //textMeshPro.fontColor = new Color32(255, 255, 255, 255);
        m_textMeshPro.SetText("");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (passwordCamera != null)
            {
                passwordCamera.enabled = !passwordCamera.enabled;
            }
        }
    }

    public void ShowPassword()
    {
        m_textMeshPro.SetText(label + HINT);
    }

    public void SetNormalFont()
    {
        m_FontAsset = Resources.Load("Fonts & Materials/Bangers SDF", typeof(TMP_FontAsset)) as TMP_FontAsset;
        m_textMeshPro.font = m_FontAsset;
    }

    public void SetMonospaceFont()
    {
        m_textMeshPro.fontSize = 6;
        m_FontAsset = Resources.Load("Fonts & Materials/Electronic Highway Sign SDF", typeof(TMP_FontAsset)) as TMP_FontAsset;
        m_textMeshPro.font = m_FontAsset;
    }
}
