using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{

    public static PauseManager inst;

    [SerializeField] bool paused;
    [SerializeField] GameObject pauseMenu;
    [HideInInspector] public Player player;

    public bool IsPaused
    {
        get
        {
            return paused;
        }
    }

    private void OnEnable()
    {
        if (inst == null)
        {
            inst = this;
        }

        player.Inputs.UI.Unpause.performed += Unpause;
    }

    private void OnDisable()
    {
        player.Inputs.UI.Unpause.performed -= Unpause;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Unpause(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        SetPause();
    }

    public void SetPause()
    {
        paused = !paused;
        Time.timeScale = paused ? 0f : 1f;
        pauseMenu.SetActive(paused);

        if (!paused)
        {
            player.Inputs.UI.Disable();
            player.Inputs.Game.Enable();
        } else
        {
            player.Inputs.Game.Disable();
            player.Inputs.UI.Enable();
        }
    }
}
