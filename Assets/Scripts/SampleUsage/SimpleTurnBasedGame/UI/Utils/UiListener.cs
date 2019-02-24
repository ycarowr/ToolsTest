using Patterns;
using SimpleTurnBasedGame;
using UnityEngine;

public class UiListener : MonoBehaviour, IListener
{
    protected virtual void Start()
    {
        GameEvents.Instance.AddListener(this);
    }

    protected virtual void OnDestroy()
    {
        if(GameEvents.Instance)
            GameEvents.Instance.RemoveListener(this);
    }
}