using UnityEngine;

public class ScriptedSpawn : MovimientoEnemigo
{
    public GameObject Enemy;
    private GameObject clone;
    private float timer;
    private bool guardSpawned = true;
    private MovimientoEnemigo movEnemy;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (guardSpawned)
        {
            clone = Instantiate(Enemy, this.transform.position, this.transform.rotation);
            movEnemy = clone.GetComponent<MovimientoEnemigo>();
            movEnemy.leftLimit = transform.position .x - 100f;
            movEnemy.rightLimit = transform.position.x;
            Destroy(clone, 10f);
            guardSpawned = false;
        }
    }
}
