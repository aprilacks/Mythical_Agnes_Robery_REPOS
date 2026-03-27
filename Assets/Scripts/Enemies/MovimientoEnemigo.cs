using UnityEngine;

public class MovimientoEnemigo : MonoBehaviour
{
    #region Public Variables
    public float speed;
    public float waitTime = 1.0f;
    public Transform pointA;
    public Transform pointB;
    #endregion

    #region Private Variables
    private Transform currentTarget;
    private SpriteRenderer spriteRenderer;
    private EnemyScript enemyScript;
    private float waitTimer;
    private bool isWaiting = false;
    #endregion

    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        enemyScript = GetComponent<EnemyScript>();

        currentTarget = pointB;
        UpdateFacing();
    }

    void Update()
    {
        if (currentTarget == null) return;

        if (isWaiting)
        {
            HandleWait();
        }
        else
        {
            Move();
        }
    }

    void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, currentTarget.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, currentTarget.position) < 0.1f)
        {
            isWaiting = true;
            waitTimer = waitTime;
        }
    }

    void HandleWait()
    {
        waitTimer -= Time.deltaTime;

        if (waitTimer <= 0)
        {
            isWaiting = false;
            currentTarget = (currentTarget == pointB) ? pointA : pointB;
            UpdateFacing();
        }
    }

    public void UpdateFacing()
    {
        // If currentTarget.x is greater than my x, I am going RIGHT
        bool goingRight = currentTarget.position.x > transform.position.x;

        // Flip the sprite (assuming your sprite faces right by default)
        spriteRenderer.flipX = !goingRight;

        if (enemyScript != null)
        {
            // 90 is Right, 270 is Left
            enemyScript.fovRotation = goingRight ? 90f : 270f;
        }
    }

    private void OnDrawGizmos()
    {
        if (pointA != null && pointB != null)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(pointA.position, pointB.position);
            Gizmos.DrawSphere(pointA.position, 0.1f);
            Gizmos.DrawSphere(pointB.position, 0.1f);
        }
    }
}