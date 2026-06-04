using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public Rigidbody2D rigidBody;
    public float moveSpeed;
    public InputActionReference moveInput, actionInput;
    public Animator anim;

    public enum ToolType
    {
        plough,
        wateringCan,
        seeds,
        basket
    }

    public ToolType currentTool;

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

        bool hasSwitchedTool = false;

        // mudar ferramenta
        if (Keyboard.current.tabKey.wasPressedThisFrame)
        {
            currentTool++;

            if((int) currentTool >= 4)
            {
                currentTool = ToolType.plough;
            }

            hasSwitchedTool = true;
        }
        if (Keyboard.current.digit1Key.wasPressedThisFrame)
        {
            currentTool = ToolType.plough;
            hasSwitchedTool = true;
        }
        if (Keyboard.current.digit2Key.wasPressedThisFrame)
        {
            currentTool = ToolType.wateringCan;
            hasSwitchedTool = true;
        }
        if (Keyboard.current.digit3Key.wasPressedThisFrame)
        {
            currentTool = ToolType.seeds;
            hasSwitchedTool = true;
        }
        if (Keyboard.current.digit4Key.wasPressedThisFrame)
        {
            currentTool = ToolType.basket;
            hasSwitchedTool = true;
        }

        if (actionInput.action.WasPressedThisFrame())
        {
            UseTool();
            hasSwitchedTool = true;
        }

        if(hasSwitchedTool == true)
        {
            UIController.instance.SwitchTool((int) currentTool);
        }

        anim.SetFloat("speed", rigidBody.linearVelocity.magnitude);
    }

    void UseTool()
    {
        GrowBlock block = null;

        block = FindAnyObjectByType<GrowBlock>();

        if(block != null)
        {
            switch (currentTool)
            {
                case ToolType.plough:
                    block.PloughSoil();
                    break;

                case ToolType.wateringCan:

                break;

                case ToolType.seeds:

                break;

                case ToolType.basket:

                break;
            }
        }
    }
}
