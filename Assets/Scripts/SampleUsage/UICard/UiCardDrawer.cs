using Extensions;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Tools.UI.Card
{
    [RequireComponent(typeof(UiCardSelector))]
    public class UiCardDrawer : MonoBehaviour
    {
        //--------------------------------------------------------------------------------------------------------------
        
        #region Fields
        
        [SerializeField] [Tooltip("Prefab of the Card C#")]
        private GameObject cardPrefabCs;

        [SerializeField] [Tooltip("Prefab of the Card MB")]
        private GameObject cardPrefabSystemMb;

        private UiCardSelector CardSelector { get; set; }
        
        #endregion
        
        //--------------------------------------------------------------------------------------------------------------

        #region Unitycallbacks
        
        private void Awake()
        {
            CardSelector = GetComponent<UiCardSelector>();
        }

        private void Start()
        {
            //starting cards
            for (var i = 0; i < 6; i++)
                DrawCard();
        }
        
        #endregion
        
        //--------------------------------------------------------------------------------------------------------------
        
        #region Operations

        [Button]
        public void DrawCard()
        {
            //TODO: Consider replace Instantiate by an Object Pool Pattern
            var cardGo = Instantiate(cardPrefabCs, transform);
            cardGo.transform.localRotation = Quaternion.Euler(-90, 180, 0);
            var card = cardGo.GetComponent<IUiCard>();
            CardSelector.AddCard(card);
        }

        [Button]
        public void PlayCard()
        {
            if (CardSelector.Cards.Count > 0)
            {
                var randomCard = CardSelector.Cards.RandomItem();
                CardSelector.PlayCard(randomCard);
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Tab)) DrawCard();
            if (Input.GetKeyDown(KeyCode.Space)) PlayCard();
            if (Input.GetKeyDown(KeyCode.Escape)) Restart();
        }

        public void Restart()
        {
            SceneManager.LoadScene(0);
        }
        
        #endregion
        
        //--------------------------------------------------------------------------------------------------------------
    }
}