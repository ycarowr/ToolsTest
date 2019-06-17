﻿using System.Collections;
using UnityEngine;

namespace Tools
{
    public class FreezeFrame : MonoBehaviour
    {
        [SerializeField] [Tooltip("Duration in frames of the freeze.")] float totalFramesFrozen;
        [SerializeField] [Tooltip("Whether the game is frozen or not.")] bool isFrozen;
        [SerializeField] [Tooltip("Fix the framerate when the game starts.")] bool fixFrameRate = true;
        [SerializeField] [Tooltip("Target of the fixed framerate.")] uint fixedFrameRate = 60;
        [SerializeField] int frozenCount;
        [SerializeField] float initialTimeScale;

        void Start()
        {
            if (fixFrameRate)
                Application.targetFrameRate = (int)fixedFrameRate;
        }

        //------------------------------------------------------------------------------------------------------

        /// <summary>
        ///     Freeze the TimeScale for an amount of seconds.
        /// </summary>
        /// <param name="time"></param>
        /// <param name="delay"></param>
        public void Freeze(float time, float delay)
        {
            if (isFrozen)
                return;
            
            totalFramesFrozen = time * Application.targetFrameRate;
            initialTimeScale = Time.timeScale;
             
            if (delay == 0)
                Freeze();
            else
                StartCoroutine(FreezeRoutine(delay));
        }
        
        /// <summary>
        ///     Unfreeze the time scale.
        /// </summary>
        [Button]
        public void Unfreeze()
        {
            frozenCount = 0;
            Time.timeScale = initialTimeScale;
            isFrozen = false;
        }


        void Update()
        {
            if (!isFrozen)
                return;

            frozenCount++;

            if (frozenCount >= totalFramesFrozen)
                Unfreeze();
        }

        IEnumerator FreezeRoutine(float delay)
        {
            yield return new WaitForSeconds(delay);
            Freeze();
        }

        void Freeze()
        {
            initialTimeScale = Time.timeScale;
            Time.timeScale = 0;
            isFrozen = true;
        }

        //------------------------------------------------------------------------------------------------------

        [Header("Test")]
        [SerializeField] float time;
        [SerializeField] float delay;
        [Button]
        void TestFreeze()
        {
            Freeze(time, delay);
        }
    }
}
