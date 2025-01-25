using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] bool deploying;

    Vector3 deployPos;

    PlayerInputs inputs;

    public PlayerInputs Inputs
    {
        get
        {
            return inputs;
        }
    }

    ShieldDeployer shieldDeployer;

    public Vector2 cursorPos;
    public Vector3 cursorWorldPos;
    Ray cursorCast;

    private void Awake()
    {
        inputs = new PlayerInputs();
        inputs.Game.Enable();

        shieldDeployer = GetComponent<ShieldDeployer>();
    }

    private void OnEnable()
    {
        //inputs.Game.Pan.
        inputs.Game.Deploy.performed += DeployBubblePreview;
        inputs.Game.Deploy.canceled += DeployBubble;
        inputs.Game.Pause.performed += Pause;
        inputs.Game.Cancel.performed += CancelShield;
    }

    private void OnDisable()
    {
        inputs.Game.Deploy.performed -= DeployBubblePreview;
        inputs.Game.Deploy.canceled -= DeployBubble;
        inputs.Game.Pause.performed -= Pause;
        inputs.Game.Cancel.performed -= CancelShield;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cursorPos = inputs.Game.Pan.ReadValue<Vector2>();

        if (deploying)
        {
            cursorWorldPos = Camera.main.ScreenToWorldPoint(new Vector3(cursorPos.x, cursorPos.y, 0));
            cursorCast = Camera.main.ScreenPointToRay(new Vector3(cursorPos.x, cursorPos.y, 0));

            RaycastHit hit;
            if (Physics.Raycast(cursorCast, out hit, Camera.main.transform.position.y + 1f))
            {
                deployPos = hit.point;
                shieldDeployer.MovePreview(deployPos);
            }
        }
    }

    public void DeployBubblePreview(InputAction.CallbackContext context)
    {
        //Debug.Log("preparing for shield deployment!");
        deploying = true;
        shieldDeployer.SpawnPreview();
    }

    public void DeployBubble(InputAction.CallbackContext context)
    {
        if (deploying)
        {
            //Debug.Log("deploy the shields at " + cursorWorldPos + "!");
            deploying = false;
            shieldDeployer.DestroyPreview();
            shieldDeployer.DeployShield(deployPos);
        }
    }

    public void CancelShield(InputAction.CallbackContext context)
    {
        if (deploying)
        {
            deploying = false;
            shieldDeployer.DestroyPreview();
        }
    }

    public void Pause(InputAction.CallbackContext context)
    {
        //Debug.Log("timeout");
        PauseManager.inst.SetPause();
    }
}
