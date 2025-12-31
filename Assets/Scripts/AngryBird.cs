using System;
using Unity.VisualScripting;
using UnityEngine;

public class AngryBird : MonoBehaviour
{
    private Rigidbody2D _rb;
    private CircleCollider2D _circleCollider;

    private bool _hasBeenLaunched;
    private bool _shouldFaceVelDirection;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _circleCollider = GetComponent<CircleCollider2D>();
    }

    private void Start()
    {
        _rb.isKinematic = true;
        _circleCollider.enabled = false;
    }

    private void FixedUpdate()
    {
        if (_hasBeenLaunched && _shouldFaceVelDirection)
            transform.right = _rb.linearVelocity;
    }

    public void LaunchBird(Vector2 direction, float force)
    {
        _rb.isKinematic = false;
        _circleCollider.enabled = true;
        
        _rb.AddForce(direction * force, ForceMode2D.Impulse);
        
        _hasBeenLaunched = true;
        _shouldFaceVelDirection = true;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        _shouldFaceVelDirection = false;
    }
}
