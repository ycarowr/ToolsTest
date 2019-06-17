using UnityEngine;

namespace Tools
{
    /// <summary>
    ///     Ref:https://gist.github.com/ftvs/5822103
    ///     Monobehavior used to shake an GameObject through it's Transform. All the variables are set with the Editor.
    ///     If you need global access to this class you can just inherit it from a SingletonMB instead.
    /// </summary>
    public class ShakeAnimation : MonoBehaviour
    {
        //---------------------------------------------------------------------------------------------------------------

        [Tooltip("How big are the width and height of the shake.")]
        [SerializeField] float amplitude = 0;

        [Tooltip("Duration of the shake in seconds")]
        [SerializeField] float duration = 0;

        [Tooltip("How often the shake happens during its own duration. Value has to be smaller than the duration.")]
        [SerializeField] float frequency = 0;

        [Tooltip("Whether the transform is shaking or not.")]
        [SerializeField] bool isShaking = false;

        [Tooltip("Transform that has to be shaken")]
        [SerializeField] Transform cachedTransform;

        //---------------------------------------------------------------------------------------------------------------

        Vector3 initialPosition;
        float CounterFrequency { get; set; }
        float CounterDuration { get; set; }

        private void Awake()
        {
            cachedTransform = transform;
        }

        /// <summary>
        ///     Method which starts the shake movement.
        /// </summary>
        [Button]
        public void Shake()
        {
            if (isShaking)
                return;

            initialPosition = cachedTransform.position;
            isShaking = true;
        }

        /// <summary>
        ///     Clear all the shake counters.
        /// </summary>
        private void ResetCounters()
        {
            CounterDuration = 0;
            CounterFrequency = 0;
        }

        /// <summary>
        ///     Clear the shake instantly.
        /// </summary>
        [Button]
        public void Stop()
        {
            isShaking = false;
            cachedTransform.localPosition = initialPosition;
            ResetCounters();
        }

        /// <summary>
        ///     Shake only works during play mode
        /// </summary>
        private void Update()
        {
            if (!isShaking) return;

            var deltaTime = Time.deltaTime;

            //increment duration
            CounterDuration += deltaTime;
            if (CounterDuration >= duration)
            {
                Stop();
            }
            else
            {
                //increment frequency
                if (CounterFrequency < frequency)
                {
                    CounterFrequency += deltaTime;
                }
                else
                {
                    //move the object somewhere inside the amplitude
                    cachedTransform.localPosition = initialPosition + Random.insideUnitSphere * amplitude;

                    //reset frequency
                    CounterFrequency = 0;
                }
            }
        }
    }
}