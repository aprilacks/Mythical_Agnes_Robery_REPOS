using UnityEngine;
using UnityEngine.InputSystem;

public class NewMovementScriptç : MonoBehaviour
{

    [Header("Movement Cons")]

    private Rigidbody2D rb;

    public float RunVelocity = 0;
    public float JumpForce = 0;

    [Tooltip("Booleans")]
    private bool CanJump = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            // KEY PRESSING || USES UNITY PHYSICS SYSTEM WITH RIGIDBODY 2D
        if(Keyboard.current.dKey.IsPressed())
        {       // RIGIDBODY VELOCITY ALTERED BY UNITYT PHYSICS SYSTEM
            rb.linearVelocity = new Vector3 (RunVelocity, rb.linearVelocity.y);
        }
        else if (Keyboard.current.aKey.IsPressed())
        {      
            rb.linearVelocity = new Vector3(-RunVelocity, rb.linearVelocity.y);
        }
        else if (Keyboard.current.spaceKey.IsPressed() && CanJump)
        {       // JUMPS USING ADDFORCE | ADDFOCRE USES UNITY PHYSICS SYSTEM
            Jump();
        }




    }



    private void Jump()
    {
        
    }



}

