using System;
using Extensions;
using TMPro;
using UnityEngine;

public class UiText : MonoBehaviour
{
    [Tooltip("Color of the text.")] [SerializeField]
    protected Color color = Color.black;

    [Tooltip("TMPro Component assigned by the Editor or Automatically on Awake.")]
    protected TextMeshProUGUI TmProText;

    [SerializeField] private string defaultText = string.Empty;

    protected virtual void Awake()
    {
        if (TmProText == null)
            TmProText = gameObject.GetOrAddComponent<TextMeshProUGUI>();

        TmProText.color = color;
        SetText(defaultText);
    }

    public virtual void SetText(string text)
    {
        TmProText.text = text;
    }
}
