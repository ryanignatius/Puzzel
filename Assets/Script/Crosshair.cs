using UnityEngine;
using System.Collections;
using TMPro;

public class Crosshair : MonoBehaviour
{

    private TextMeshPro m_textMeshPro;

    private const string label = "+";

    void Start()
    {
        // Add new TextMesh Pro Component
        m_textMeshPro = gameObject.AddComponent<TextMeshPro>();

        m_textMeshPro.autoSizeTextContainer = true;

        // Load the Font Asset to be used.
        //m_FontAsset = Resources.Load("Fonts & Materials/LiberationSans SDF", typeof(TMP_FontAsset)) as TMP_FontAsset;
        //m_textMeshPro.font = m_FontAsset;

        // Assign Material to TextMesh Pro Component
        //m_textMeshPro.fontSharedMaterial = Resources.Load("Fonts & Materials/LiberationSans SDF - Bevel", typeof(Material)) as Material;
        //m_textMeshPro.fontSharedMaterial.EnableKeyword("BEVEL_ON");

        // Set various font settings.
        m_textMeshPro.fontSize = 2;

        m_textMeshPro.alignment = TextAlignmentOptions.Center;

        //m_textMeshPro.anchorDampening = true; // Has been deprecated but under consideration for re-implementation.
        //m_textMeshPro.enableAutoSizing = true;

        //m_textMeshPro.characterSpacing = 0.2f;
        //m_textMeshPro.wordSpacing = 0.1f;

        //m_textMeshPro.enableCulling = true;
        m_textMeshPro.enableWordWrapping = false;

        //textMeshPro.fontColor = new Color32(255, 255, 255, 255);
        m_textMeshPro.SetText(label);
    }
}
