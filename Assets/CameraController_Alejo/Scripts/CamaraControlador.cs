using UnityEngine;

public class CamaraControlador : MonoBehaviour
{
    public GameObject CameraTarget = null;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 CameratargetV = new Vector3 (CameraTarget.transform.position.x, CameraTarget.transform.position.y, transform.position.z);

        if (CameraTarget != null)
        {
            transform.position = CameratargetV;
        }


    }
}
