using System;
using SimpleTurnBasedGame.AI;
using UnityEngine;

namespace SimpleTurnBasedGame
{
    [CreateAssetMenu(menuName = "Configurations")]
    public class Configurations : ScriptableObject
    {
        //----------------------------------------------------------------------------------------------------------

        #region Properties

        public bool AreLogsEnabled => areLogsEnabled;

        public float TimeStartTurn => PlayerTurn.TimeStartTurn;
        public float TimeOutTurn => PlayerTurn.TimeOutTurn;

        public float PreGameEvent => GameStart.PreGameEvent;
        public float StartGameEvent => GameStart.StartGameEvent;
        public float FirstPlayer => GameStart.FirstPlayer;
        public float TotalStartGame => StartGameEvent + PreGameEvent + FirstPlayer;

        public AiArchetype TopAiArchetype => Ai.TopPlayer.Archetype;
        public AiArchetype BottomAiArchetype => Ai.BottomPlayer.Archetype;
        public bool TopIsAi => Ai.TopPlayer.IsAi;
        public bool BottomIsAi => Ai.BottomPlayer.IsAi;
        public float AiDoTurnDelay => Ai.AiDoTurnDelay;
        public float AiFinishTurnDelay => Ai.AiFinishTurnDelay;

        public int HealthTopPlayer => HealthPlayers.healthTopPlayer;
        public int HealthBottomPlayer=> HealthPlayers.healthBottomPlayer;

        #endregion

        //----------------------------------------------------------------------------------------------------------

        #region Game Start

        [Header("Game Start Events")]
        public GameStartEvents GameStart = new GameStartEvents();

        [Serializable]
        public class GameStartEvents
        {
            [Range(0.01f, 0.5f)]
            [Tooltip("Time between Load and Pregame Event")]
            public float PreGameEvent;

            [Tooltip("Time between Pregame event and Start Game Event")]
            [Range(0.01f, 0.5f)]
            public float StartGameEvent;

            [Tooltip("Time between start game to first player turn")]
            [Range(3f, 6f)]
            public float FirstPlayer;
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------

        #region PlayerHandler Turn

        [Header("PlayerTurn Events")]
        public PlayerTurnEvents PlayerTurn = new PlayerTurnEvents();

        [Serializable]
        public class PlayerTurnEvents
        {
            [Range(6f, 12f)]
            [Tooltip("Time between Load and Pregame Event")]
            public float TimeOutTurn;

            [Range(0.01f, 2f)]
            [Tooltip("Time until player starts the turn effectively.")]
            public float TimeStartTurn;
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------

        #region AI

        [Header("AI")]
        public AiConfigs Ai = new AiConfigs();

        [Serializable]
        public class AiConfigs
        {
            [Range(0.01f, 4)] [Tooltip("Time until ai do it's turn.")]
            public float AiDoTurnDelay = 2.5f;

            [Range(0.01f, 4)] [Tooltip("Time maximum for AI turns.")]
            public float AiFinishTurnDelay = 3.5f;

            [Tooltip("Configurations for Top PlayerHandler")]
            public Player TopPlayer = new Player()
            {
                IsAi = true
            };

            [Tooltip("Configurations for Bottom PlayerHandler")]
            public Player BottomPlayer = new Player()
            {
                IsAi = false
            };


            [Serializable]
            public class Player
            {
                public bool IsAi;
                public AiArchetype Archetype;
            }
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------

        #region DamagePlayers

        [Header("Damage Amounts")]
        public DamagePlayers Damage = new DamagePlayers();

        [Serializable]
        public class DamagePlayers
        {
            [Range(1, 10)]
            public int MaxDamage = 4;

            [Range(1, 10)]
            public int MinDamage = 1;
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------

        #region HealPlayers

        [Header("Heal Amounts")]
        public HealPlayers Heal = new HealPlayers();

        [Serializable]
        public class HealPlayers
        {
            [Range(1, 10)]
            public int MaxHeal = 4;

            [Range(1, 10)]
            public int MinHeal = 1;
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------

        #region Health

        [Header("Health Amounts")]
        public Health HealthPlayers = new Health();

        [Serializable]
        public class Health
        {
            [Range(1, 15)] public int healthTopPlayer = 6;
            [Range(1, 15)] public int healthBottomPlayer = 6;

            public int GetHealth(PlayerSeat seat)
            {
                return seat == PlayerSeat.Bottom ? healthBottomPlayer : healthTopPlayer;
            }
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------

        #region Bonus Random

        [Header("Bonus Random")] public BonusRandom Bonus = new BonusRandom();

        [Serializable]
        public class BonusRandom
        {
            [Range(1, 5)] public int Value = 2;
        }

        #endregion

        //----------------------------------------------------------------------------------------------------------

        #region Extra

        [SerializeField] [Header("Extra")] private bool areLogsEnabled;

        #endregion

        //----------------------------------------------------------------------------------------------------------
    }
}
