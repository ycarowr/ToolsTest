using Extensions;
using TMPro;
using UnityEngine;

public class UiTextMeshProText : MonoBehaviour
{
    [Tooltip("Color of the text.")]
    [SerializeField] protected Color color = Color.black;
    [Tooltip("TMPro Component assigned by the Editor or Automatically on Awake.")]
    protected TextMeshProUGUI TmProText;

    protected void Awake()
    {
        if (TmProText == null)
            TmProText = gameObject.GetOrAddComponent<TextMeshProUGUI>();
         
        TmProText.color = color;
    }

    public virtual void AddText(string text)
    {
        SetText(TmProText.text + text);
    }

    public virtual void SetText(string text)
    {
        TmProText.text = text;
    }
}
