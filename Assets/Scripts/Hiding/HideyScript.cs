using UnityEngine;

public class HideyScript : MonoBehaviour
{
    [SerializeField] private Movement _move;
    public Rigidbody2D agnes; // Player RB
    public Rigidbody2D hidespot; // Hiding Spot RB

    private bool playerInRange = false;
    private CapsuleCollider2D disableCollision;

    private void Start()
    {
        // Auto-find player in the new room instance
        if (agnes == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null) agnes = playerObj.GetComponent<Rigidbody2D>();
        }

        if (agnes != null)
        {
            disableCollision = agnes.GetComponent<CapsuleCollider2D>();
            _move = agnes.GetComponent<Movement>();
        }
    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.H))
        {
            if (!_move.isHiding) Hide();
            else Unhide();
        }

        if (_move != null && _move.isHiding && playerInRange)
        {
            agnes.transform.position = hidespot.transform.position;
            agnes.constraints = RigidbodyConstraints2D.FreezePosition | RigidbodyConstraints2D.FreezeRotation;
        }
    }

    private void Hide()
    {
        _move.isHiding = true;
        if (disableCollision != null) disableCollision.isTrigger = true;
    }

    private void Unhide()
    {
        _move.isHiding = false;
        if (disableCollision != null) disableCollision.isTrigger = false;
        agnes.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) playerInRange = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (_move.isHiding) Unhide();
            playerInRange = false;
        }
    }
}