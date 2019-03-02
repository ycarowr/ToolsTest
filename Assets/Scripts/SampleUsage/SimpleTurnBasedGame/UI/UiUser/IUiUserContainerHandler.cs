using System.Collections.Generic;
using Extensions;
using Patterns;
using UnityEngine;
using UnityEngine.UI;

namespace SimpleTurnBasedGame
{
    /// <summary>
    /// This interface enforces the client to return a UiUserContainer
    /// </summary>
    public interface IUiUserContainerHandler 
    {
        UiUserContainer Container { get; }
    }
}