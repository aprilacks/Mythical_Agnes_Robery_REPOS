using UnityEngine;

public class Mov_Structure_Temp : MonoBehaviour
{
    [Header("Mov Structure For Following Camera")]
    [Tooltip("Object Speed")]
    public float speed = 50.0f;

    [Tooltip("Camera Game Object for Reference")]
    public GameObject cameraRef = null;

    void Update()
    {
        /***************
         
         CHANGE FOR FINAL DESSGINED MOVEMENT SETTING
        
        ***************/

        int movementX = 0;
        int movementY = 0;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            movementX = -1;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            movementX = 1;
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            movementY = 1;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            movementY = -1;
        }

        transform.position = transform.position + new Vector3(movementX, movementY, 0) * speed * Time.deltaTime;

        /***************

        CHANGE FOR FINAL DESSGINED MOVEMENT SETTING

        ***************/

    }

    /***************

    CAMERA LOGIC STRUCTURE
    ADD TO FINAL DESIGNED MOVEMENT SCRIPT

    ***************/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If collition is detected and This object has a Camera Reference Game Object
        if (collision != null && cameraRef != null)
        {
            // If Game Object Tag is equal to the Bg Tag
            if (collision.gameObject.tag == "ChangeCamera")
            {
                // CameraController Script item, Gets "cameraRef" from CameraController Script
                Camera_Controller_Structure_Temp controller = cameraRef.GetComponent<Camera_Controller_Structure_Temp>();
                if (controller != null)
                { // If it has a Controller Componenet Asigned
                    controller.target = collision.gameObject;
                } // Script Reference for target equals to Collided Object Tagged by "Change Camera"
            }
        }
    }
}
