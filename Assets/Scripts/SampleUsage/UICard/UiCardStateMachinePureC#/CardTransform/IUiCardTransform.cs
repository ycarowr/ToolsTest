﻿using UnityEngine;

namespace Tools.UI.Card
{
    public interface IUiCardTransform
    {
        void MoveTo(Vector3 position, float speed);
        void RotateTo(Vector3 euler, float speed);
        void ScaleTo(Vector3 scale, float speed);
    }
}