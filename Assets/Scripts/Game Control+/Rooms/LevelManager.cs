using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    [Header("Room List")]
    public GameObject[] roomPrefabs;

    private GameObject currentRoomInstance;
    private int currentRoomIndex = 0;

    private void Awake()
    {
        // Singleton pattern to ensure only one LevelManager exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (roomPrefabs.Length > 0)
        {
            LoadRoom(0);
        }
        else
        {
            Debug.LogError("No room prefabs assigned to LevelManager!");
        }
    }

    public void LoadNextRoom()
    {
        currentRoomIndex++;
        if (currentRoomIndex < roomPrefabs.Length)
        {
            LoadRoom(currentRoomIndex);
        }
        else
        {
            Debug.Log("End of Game reached!");
        }
    }

    public void ResetCurrentRoom()
    {
        Debug.Log("Resetting Room Index: " + currentRoomIndex);
        LoadRoom(currentRoomIndex);
    }

    private void LoadRoom(int index)
    {
        // 1. Clean up the old room
        if (currentRoomInstance != null)
        {
            Destroy(currentRoomInstance);
        }

        // 2. Spawn the new room prefab at origin
        currentRoomInstance = Instantiate(roomPrefabs[index], Vector3.zero, Quaternion.identity);

        // 3. Teleport Player to the SpawnPoint inside the NEW room
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            // Reset player physics so they don't carry momentum into the new room
            Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
            if (rb != null) rb.linearVelocity = Vector2.zero;

            // Find the spawn point object inside the instantiated room
            Transform spawnPoint = currentRoomInstance.transform.Find("EntranceSpawnPoint");
            if (spawnPoint != null)
            {
                player.transform.position = spawnPoint.position;
            }
            else
            {
                Debug.LogWarning("EntranceSpawnPoint not found in " + roomPrefabs[index].name);
            }
        }

        // 4. Update the Camera
        RoomController rc = currentRoomInstance.GetComponent<RoomController>();
        if (rc != null)
        {
            rc.ActivateRoom();
        }
    }
}