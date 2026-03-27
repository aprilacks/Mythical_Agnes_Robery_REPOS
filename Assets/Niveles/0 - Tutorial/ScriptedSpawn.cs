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

    private void OnTriggerEnter2D(Collider2D collision)
    {
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
            GameObject pA = new GameObject("Scripted_PointA");
            GameObject pB = new GameObject("Scripted_PointB");

            pA.transform.position = transform.position;
            pB.transform.position = new Vector3(transform.position.x - spawnDistance, transform.position.y, transform.position.z);

            movEnemy.pointA = pA.transform;
            movEnemy.pointB = pB.transform;
            movEnemy.speed = enemySpeed;

            pA.transform.SetParent(clone.transform);
            pB.transform.SetParent(clone.transform);
        }

        Destroy(clone, despawnTime);
    }
}