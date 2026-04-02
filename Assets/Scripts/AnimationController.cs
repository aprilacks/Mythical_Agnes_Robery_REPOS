using UnityEngine;

public class AnimationController : MonoBehaviour // Changed from Movement to MonoBehaviour
{
    private Animator _anim;
    private Movement _plymov;
    private Rigidbody2D _rb;

    void Start()
    {
        _anim = GetComponent<Animator>();
        _plymov = GetComponent<Movement>();
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (_plymov == null) return;

        // Sync booleans from the actual Movement script
        _anim.SetBool("Ground", _plymov.isGrounded());
        _anim.SetBool("Water", _plymov.usingWaterMagic);
        _anim.SetBool("Wind", _plymov.usingWindMagic);
        _anim.SetBool("Fire", _plymov.usingFireMagic);

        if (_plymov.isGrounded())
        {
            // Reset jump state when hitting floor
            _anim.SetBool("Jump", false);

            // Check horizontal velocity for walk animation
            bool isWalking = Mathf.Abs(_rb.linearVelocity.x) > 0.1f;
            _anim.SetBool("Walk", isWalking);
        }
        else
        {
            // Only trigger Jump animation if moving upwards
            _anim.SetBool("Jump", _rb.linearVelocity.y > 0.1f);
            _anim.SetBool("Walk", false);
        }
    }
}