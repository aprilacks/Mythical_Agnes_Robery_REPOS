using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class WaterMagic : MonoBehaviour
{
    private PlayerInput _input;
    private Movement plymov;

    [Header("Dash Settings")]
    public float dashPower = 40f;
    public bool DashUsed = false;

    void Start()
    {
        plymov = GetComponent<Movement>();
        _input = GetComponent<PlayerInput>();
    }

    void Update()
    {
        // Dash triggers if button pressed AND (on ground OR hasn't used air dash yet)
        if (_input.actions["Water"].WasPressedThisFrame() && !DashUsed)
        {
            DashUsed = true;
            plymov.PlayDashSound(); // Triggers the Movement script sound
            StartCoroutine(DashRoutine());
        }

        // Reset dash when touching ground
        if (plymov.isGrounded()) DashUsed = false;
    }

    IEnumerator DashRoutine()
    {
        float dir = plymov.ReturnDirection();
        plymov.usingWaterMagic = true;

        // Freeze Y to make the dash "tight"
        plymov._rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
        plymov.SetFrameVelocity(new Vector2(dashPower * dir, 0));

        yield return new WaitForSeconds(0.2f);

        plymov._rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        plymov.usingWaterMagic = false;
    }
}