﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public delegate void BallHitObjectEvent(string tag);
    public event BallHitObjectEvent BallHitObject;

    private Rigidbody rb;

    [SerializeField] private float bounceMultiplier = default;
    [SerializeField] private Vector3 startVelocity = default;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(startVelocity, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        var impulse = collision.impulse;
        rb.AddForce(impulse * bounceMultiplier, ForceMode.Impulse);

        BallHitObject?.Invoke(tag);
    }
}