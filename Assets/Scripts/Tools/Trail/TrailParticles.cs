﻿using UnityEngine;

namespace Tools
{
    [RequireComponent(typeof(ParticleSystem))]
    public class TrailParticles : MonoBehaviour
    {
        [SerializeField] private bool autoPlay;
        [SerializeField] private ParticleSystem trail;
        [SerializeField] private Material trailMaterial;

        private void Start()
        {
            if (autoPlay)
                Play();
        }

        [Button]
        public void Play()
        {
            trail.Play();
        }

        [Button]
        public void StopTrail()
        {
            trail.Stop();
        }

        public void PlayFromRender(SpriteRenderer render)
        {
            trailMaterial.mainTexture = render.sprite.texture;
            var positionInTexture = trailMaterial.mainTextureOffset;
            positionInTexture.x = render.sprite.rect.position.x / render.sprite.rect.width;
            positionInTexture.y = render.sprite.rect.position.y / render.sprite.rect.height;

            var offset = new Vector2
            {
                x = positionInTexture.x * (render.sprite.rect.width / render.sprite.texture.width),
                y = positionInTexture.y * (render.sprite.rect.height / render.sprite.texture.height)
            };

            trailMaterial.mainTextureOffset = offset;
            Play();
        }
    }
}