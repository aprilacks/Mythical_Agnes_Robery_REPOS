using UnityEngine;

public class Camera_Controller_Structure_Temp : MonoBehaviour
{
    [Header("Camera Movement Structure")]
    [Tooltip("Target Game Object, It becomes a Collider [[ See Mov_Structure ]]")]
    public GameObject target = null;
    
    [Tooltip("Lerp Transition Speed")]
    public float speed = 1.0f;

    [Tooltip("Sets an Offset in Camera's Position if needed")]
    public Vector3 offset = Vector3.zero;

    [Tooltip("Camera's initial Position")]
    private Vector3 baseCamPosition = Vector3.zero;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // If target has an asigned Game object
        if (target != null)
        { 
            baseCamPosition = target.transform.position;
            transform.position = baseCamPosition;
        }// Camera Initial Position = Target position
    }

    // Update is called once per frame
    void Update()
    {
        if(target != null)
        { // If target has an asigned Game object
            baseCamPosition = Vector3.Lerp(baseCamPosition, target.transform.position, speed * Time.deltaTime);
            transform.position = baseCamPosition + offset;
        } // Makes a transition to the next Collided Object tagged by ChangeCamera [[ See Mov_Structure ]]
    }
}
