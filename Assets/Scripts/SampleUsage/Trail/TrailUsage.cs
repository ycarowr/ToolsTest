using System.Collections;
using System.Collections.Generic;
using Tools;
using UnityEngine;

public class TrailUsage : MonoBehaviour
{
    void Start()
    {
        var renderer = GetComponent<SpriteRenderer>();
        var trail = GetComponentInChildren<TrailParticles>();
        trail.PlayFromRender(renderer);
    }
}
