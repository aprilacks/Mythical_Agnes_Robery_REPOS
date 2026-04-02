using System.Collections;
using UnityEngine;

public class WaterMagic : MonoBehaviour
{
    [SerializeField] private ScriptableStats _stats;
    private Movement plymov;
    public Rigidbody2D agnes;
    public bool DashUsed = false;

    // Set this to 40 in the Inspector
    public float dashPower = 40f;

    void Start()
    {
        plymov = GetComponent<Movement>();
    }

    void Update()
    {
        WaterDash();
        if (plymov.isGrounded()) DashUsed = false;
    }

    void WaterDash()
    {
        if (Input.GetKeyDown(KeyCode.V) && !DashUsed)
        {
            DashUsed = true;
            plymov.usingWaterMagic = true;
            plymov.usingFireMagic = false;

            // Calculate direction and apply force
            float dir = plymov.ReturnDirection();
            Vector2 force = new Vector2(dashPower * dir, 0);

            agnes.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
            plymov.SetFrameVelocity(force);

            _stats.MaxFallSpeed = 40;
            _stats.FallAcceleration = 80;

            StartCoroutine(DashRoutine(dir));
        }
    }

    IEnumerator DashRoutine(float direction)
    {
        yield return new WaitForSecondsRealtime(0.2f);

        // Apply a small counter-force to stop the dash momentum
        plymov.SetFrameVelocity(new Vector2(-(dashPower / 3) * direction, 0));

        agnes.constraints = RigidbodyConstraints2D.FreezeRotation;
        plymov.usingWaterMagic = false;
    }
}