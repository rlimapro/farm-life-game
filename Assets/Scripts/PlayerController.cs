using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    private void Awake() 
    {
    
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);    
        } else
        {
            Destroy(gameObject);
        }

    }

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
    public float toolWaitTime = .5f;
    private float toolWaitCounter;
    public Transform toolIndicator;
    public float toolRange = 3f;

    private void OnEnable()
    {
        if (instance != null && instance != this) return;
        moveInput.action.Enable();
        actionInput.action.Enable();
    }

    private void OnDisable()
    {
        if (instance != this) return;
        moveInput.action.Disable();
        actionInput.action.Disable();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UIController.instance.SwitchTool((int) currentTool);
    }

    // Update is called once per frame
    void Update()
    {

        if(toolWaitCounter > 0)
        {
            toolWaitCounter -= Time.deltaTime;
            rigidBody.linearVelocity = Vector2.zero;
        }
        else
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

        toolIndicator.position = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        toolIndicator.position = new Vector3(toolIndicator.position.x, toolIndicator.position.y, 0f);
    
        if(Vector3.Distance(toolIndicator.position, transform.position) > toolRange)
        {
            Vector2 direction = toolIndicator.position - transform.position;
            direction = direction.normalized * toolRange;
            toolIndicator.position = transform.position + new Vector3(direction.x, direction.y, 0f);
        }

        toolIndicator.position = new Vector3(
            Mathf.FloorToInt(toolIndicator.position.x) + .5f,
            Mathf.FloorToInt(toolIndicator.position.y) + .5f,
            0f    
        );
    }

    void UseTool()
    {
        GrowBlock block = null;

        block = GridController.instance.GetBlock(
            toolIndicator.position.x - .5f, 
            toolIndicator.position.y - .5f
        );

        toolWaitCounter = toolWaitTime;


        if(block != null)
        {
            switch (currentTool)
            {
                case ToolType.plough:
                    block.PloughSoil();
                    anim.SetTrigger("usePlough");
                    break;

                case ToolType.wateringCan:
                    block.WaterSoil();
                    anim.SetTrigger("useWateringCan");
                    break;

                case ToolType.seeds:
                    block.PlantCrop();
                    break;

                case ToolType.basket:
                    block.HarvestCrop();
                    break;
            }
        }
    }
}
