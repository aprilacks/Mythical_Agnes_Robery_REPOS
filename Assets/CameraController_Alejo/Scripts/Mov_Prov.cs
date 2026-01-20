using UnityEngine;
using UnityEngine.InputSystem;

public class Mov_Prov : MonoBehaviour
{
    public int Speed = 0;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Dir = Vector3.zero;

        if (Keyboard.current.aKey.IsPressed())
        {
            Dir.x = -1;
        }
        if (Keyboard.current.dKey.IsPressed())
        {
            Dir.x = 1;
        }
        if (Keyboard.current.wKey.IsPressed())
        {
            Dir.y = 1;
        }
        if (Keyboard.current.sKey.IsPressed())
        {
            Dir.y = -1;
        }

        transform.position += Dir*Speed*Time.deltaTime;

    }
}
