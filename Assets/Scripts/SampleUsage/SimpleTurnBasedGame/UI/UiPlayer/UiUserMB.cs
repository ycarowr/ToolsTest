using UnityEngine;
using UnityEngine.UI;

namespace SimpleTurnBasedGame
{
    public class UiUserMB : UiPlayerMB
    {
        protected override void Awake()
        {
            UiPlayer = new UiPlayerUser(this);
        }
    }
}