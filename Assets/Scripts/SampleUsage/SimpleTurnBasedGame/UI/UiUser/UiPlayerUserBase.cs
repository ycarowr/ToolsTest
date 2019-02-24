using System.Collections.Generic;
using Extensions;
using Patterns;
using UnityEngine;
using UnityEngine.UI;

namespace SimpleTurnBasedGame
{
    public abstract class UiPlayerUserBase 
    {
        protected UiPlayerUserContainer Handler { get; }
        
        protected UiPlayerUserBase(UiPlayerUserContainer handler)
        {
            Handler = handler;
        }
    }
}