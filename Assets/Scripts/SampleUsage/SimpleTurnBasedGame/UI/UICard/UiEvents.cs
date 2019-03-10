using Tools.UI.Card;
using UnityEngine;

public class UiEvents : MonoBehaviour
{
    [SerializeField] private UiCardSelector CardSelector;

    private void Awake()
    {
        CardSelector.OnHandChanged += OnHandChanged;
    }

    private void OnHandChanged(UiCardHand[] cards)
    {
    }

    public void SetHoverHeight(float height)
    {
        foreach (var card in CardSelector.Cards)
        {
            var hoverState = card.GetComponent<UiCardHover>();
            hoverState.SetYOffset(height);
        }
    }

    public void SetKeepRotation(bool keepRotation)
    {
        foreach (var card in CardSelector.Cards)
        {
            var hoverState = card.GetComponent<UiCardHover>();
            hoverState.SetKeepRotation(keepRotation);
        }
    }

    public void SetScalePercent(float percent)
    {
        foreach (var card in CardSelector.Cards)
        {
            var hoverState = card.GetComponent<UiCardHover>();
            hoverState.SetHoverScale(percent);
        }
    }

    public void SetDisableAlpha(float alpha)
    {
        foreach (var card in CardSelector.Cards)
        {
            var disableState = card.GetComponent<UiCardDisable>();
            disableState.SetDisabledAlpha(alpha);
        }
    }
}