using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Tools
{
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(Collider2D))]
    public class Button3D : MonoBehaviour,
        IPointerClickHandler,
        IPointerDownHandler,
        IPointerEnterHandler,
        IPointerUpHandler,
        IPointerExitHandler
    {
        public virtual void OnPointerClick(PointerEventData eventData)
        {
        }

        public virtual void OnPointerDown(PointerEventData eventData)
        {
        }

        public virtual void OnPointerEnter(PointerEventData eventData)
        {
        }

        public virtual void OnPointerExit(PointerEventData eventData)
        {
        }

        public virtual void OnPointerUp(PointerEventData eventData)
        {
        }

        private void Awake()
        {
            CheckEngineDependencies();
        }

        #region Unity Dependencies

        private class Button3DException : Exception
        {
            public Button3DException(string message) : base(message)
            {
            }
        }

        private static void CheckEngineDependencies()
        {
            CheckPhysicsRayCaster();
            CheckEventSystem();
            CheckStandaloneInputModule();
        }

        private static void CheckPhysicsRayCaster()
        {
            var physicsRayCaster = FindObjectOfType<Physics2DRaycaster>();
            if (physicsRayCaster == null)
                throw new Button3DException("3D Buttons only work with a " + typeof(Physics2DRaycaster));
        }

        private static void CheckEventSystem()
        {
            var eventSystem = FindObjectOfType<EventSystem>();
            if (eventSystem == null)
                throw new Button3DException("3D Buttons only work with a " + typeof(EventSystem));
        }

        private static void CheckStandaloneInputModule()
        {
            var standaloneInputModule = FindObjectOfType<StandaloneInputModule>();
            if (standaloneInputModule == null)
                throw new Button3DException("3D Buttons only work with a " + typeof(StandaloneInputModule));
        }

        #endregion
    }
}