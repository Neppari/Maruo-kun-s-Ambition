using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public delegate void BallHitObjectEvent(GameObject other);
    public event BallHitObjectEvent BallHitObject;

    private Rigidbody rb;

    [SerializeField] private float bounceMultiplier = default;
    [SerializeField] private Vector3 startVelocity = default;
    [SerializeField] private ParticleSystem dustParticles = default;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(startVelocity, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        var impulse = collision.impulse;
        rb.AddForce(impulse * bounceMultiplier, ForceMode.Impulse);

        dustParticles.Play();

        BallHitObject?.Invoke(collision.gameObject);
    }
}
