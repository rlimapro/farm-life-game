using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public Rigidbody2D rigidBody;
    public float moveSpeed;
    public InputActionReference moveInput, actionInput;
    public Animator anim;

    private void OnEnable()
    {
        moveInput.action.Enable();
        actionInput.action.Enable();
    }

    private void OnDisable()
    {
        moveInput.action.Disable();
        actionInput.action.Disable();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rigidBody.linearVelocity = moveInput.action.ReadValue<Vector2>().normalized * moveSpeed;

        // virar o player
        if(rigidBody.linearVelocity.x < 0f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if(rigidBody.linearVelocity.x > 0f)
        {
            transform.localScale = Vector3.one;
        }

        if (actionInput.action.WasPressedThisFrame())
        {
            UseTool();
        }

        anim.SetFloat("speed", rigidBody.linearVelocity.magnitude);
    }

    void UseTool()
    {
        GrowBlock block = null;

        block = FindAnyObjectByType<GrowBlock>();

        block.PloughSoil();
    }
}
