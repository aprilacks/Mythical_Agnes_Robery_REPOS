using UnityEngine;

public class ScriptedSpawn : MonoBehaviour
{
    public GameObject Enemy;
    public float enemySpeed = 5f;
    public float spawnDistance = 10f;
    public float despawnTime = 8f;

    private GameObject clone;
    private bool guardSpawned = true;
    private MovimientoEnemigo movEnemy;

    private void OnEnable()
    {
        // If this script is inside a Room Prefab, it will reset every time 
        // the Room is instantiated by the LevelManager.
        ResetSpawner();
    }

    // Call this if you want to manually reset the encounter
    public void ResetSpawner()
    {
        if (clone != null)
        {
            Destroy(clone);
        }
        guardSpawned = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Only spawn if we haven't spawned this 'life' and it's the Player
        if (guardSpawned && collision.CompareTag("Player"))
        {
            guardSpawned = false;
            SpawnGuard();
        }
    }

    void SpawnGuard()
    {
        clone = Instantiate(Enemy, transform.position, transform.rotation);
        movEnemy = clone.GetComponent<MovimientoEnemigo>();

        if (movEnemy != null)
        {
            // Create target points
            GameObject pA = new GameObject("Scripted_PointA");
            GameObject pB = new GameObject("Scripted_PointB");

            pA.transform.position = transform.position;
            pB.transform.position = new Vector3(transform.position.x - spawnDistance, transform.position.y, transform.position.z);

            movEnemy.pointA = pA.transform;
            movEnemy.pointB = pB.transform;
            movEnemy.speed = enemySpeed;

            // Parent them to the clone so they get destroyed when the clone is destroyed
            pA.transform.SetParent(clone.transform);
            pB.transform.SetParent(clone.transform);
        }

        // Standard cleanup after X seconds
        Destroy(clone, despawnTime);
    }

    private void OnDestroy()
    {
        // Cleanup if the trigger itself is destroyed (room change)
        if (clone != null) Destroy(clone);
    }
}