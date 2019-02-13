using System.Collections;
using System.Collections.Generic;
using Patterns;
using UnityEngine;

namespace Tools
{
    /// <summary>
    /// Ref:https://gist.github.com/ftvs/5822103
    /// Monobehavior used to shake an GameObject throught it's Transform. All the variables are set with the Editor.
    /// If you need global access to this class you can just inherit it from a SingletonMB instead.
    /// </summary>
    public class ShakeAnimation : MonoBehaviour
    {
        [Tooltip("Transform that has to be shaken")]
        [SerializeField] private Transform cachedTransform;
        
        //initial position
        private Vector3 originalPosition;

        [Tooltip("whether the object is shaking or not.")]
        public bool isShaking;

        [Tooltip("How big are the width and height of the shake.")]
        [SerializeField] private float amplitude;

        [Tooltip("How often the shake happens during its own duration. Value has to be smaller than the duration.")]
        [SerializeField] private float frequency;

        [Tooltip("Duration of the shake in seconds")]
        [SerializeField] private float duration;

        private float CounterFrequency { get; set; }
        private float CounterDuration { get; set; }

        private void Awake()
        {
            cachedTransform = transform;
        }

        /// <summary>
        /// Method which starts the shake movement.
        /// </summary>
        public void Shake()
        {
            if (isShaking)
                return;

            originalPosition = cachedTransform.position;
            isShaking = true;
        }

        /// <summary>
        /// Reset all the shake counters.
        /// </summary>
        private void ResetCounters()
        {
            CounterDuration = 0;
            CounterFrequency = 0;
        }

        /// <summary>
        /// Reset the shake instantly.
        /// </summary>
        public void StopShaking()
        {
            isShaking = false;
            cachedTransform.localPosition = originalPosition;
            ResetCounters();
        }

        /// <summary>
        /// Shake only works during play mode
        /// </summary>
        private void Update()
        {
            if (isShaking)
            {
                var deltaTime = Time.deltaTime;
                
                //increment duration
                CounterDuration += deltaTime;
                if (CounterDuration >= duration)
                    StopShaking();
                else
                {
                    //increment frequency
                    if (CounterFrequency < frequency)
                        CounterFrequency += deltaTime;
                    else
                    {
                        //move the object somewhere inside the amplitude
                        cachedTransform.localPosition = originalPosition + Random.insideUnitSphere * amplitude;

                        //reset frequency
                        CounterFrequency = 0;
                    }
                }
            }
        }
    }
}