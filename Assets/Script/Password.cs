using UnityEngine;
using System.Collections;
using TMPro;

public class Password : MonoBehaviour
{
    private static string PASSWORD = "123";
    private static string HINT = "123";
    private static int LEVEL = 0;

    public static void SetLevel(int newLevel)
    {
        LEVEL = newLevel;
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
        m_textMeshPro.enableWordWrapping = true;

        //textMeshPro.fontColor = new Color32(255, 255, 255, 255);
        m_textMeshPro.SetText("");
        GeneratePassword();
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

    private void SetNormalFont()
    {
        m_FontAsset = Resources.Load("Fonts & Materials/Bangers SDF", typeof(TMP_FontAsset)) as TMP_FontAsset;
        m_textMeshPro.font = m_FontAsset;
    }

    private void SetMonospaceFont()
    {
        m_textMeshPro.fontSize = 6;
        m_FontAsset = Resources.Load("Fonts & Materials/Electronic Highway Sign SDF", typeof(TMP_FontAsset)) as TMP_FontAsset;
        m_textMeshPro.font = m_FontAsset;
    }

    private void GeneratePassword()
    {
        switch (LEVEL)
        {
            case 1:
                PASSWORD = "214";
                HINT = "#chair\n#skull\n#barrel";
                SetNormalFont();
                break;
            case 2:
                PASSWORD = "0209140715";
                HINT = "01. Approach the door and enter the password below\n02. BINGO\n03. Congratulations! The door will open";
                SetNormalFont();
                break;
            case 3:
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

                PASSWORD = "53311818";
                HINT = pass;
                SetMonospaceFont();
                break;
            default:
                // do nothing
                break;
        }
        m_textMeshPro.SetText(label + HINT);
    }
}
