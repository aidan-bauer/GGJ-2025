using System.Collections;
using System.Collections.Generic;
using Events;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using Unity.AI.Navigation;

public class LevelManager : MonoBehaviour
{
    //TODO: review how this is set up in Mythren
    //public static LevelManager inst;

    [SerializeField] float timeLimit;
    float timer;
    int survivorsRemaining;
    int survivorsSaved = 0;
    int deployedShields;

    [HideInInspector] public Player player;

    SceneHandler handler;
    [SerializeField] LevelData currLevel;

    [Header("UI")]
    [HideInInspector] GameObject gameOverScreen;
    [HideInInspector] GameObject levelCompleteScreen;
    public TMP_Text remainingTime;
    public TMP_Text remainingSurvivors;
    public TMP_Text shields;

    /*[SerializeField] Constants constants;
    public Constants Constants
    {
        get
        {
            return constants;
        }
    }*/

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        GetComponent<PauseManager>().player = player;

        //surface = GetComponentInChildren<NavMeshSurface>();
    }

    private void OnEnable()
    {
        /*if (inst == null)
        {
            inst = this;
        }*/

        handler = FindObjectOfType(typeof(SceneHandler)) as SceneHandler;
        if (handler != null)
        {
            for (int i = 0; i < DontDestroy.inst.Constants.Levels.Length; i++)
            {
                if (DontDestroy.inst.Constants.Levels[i].LevelName == handler.CurrScene)
                {
                    currLevel = DontDestroy.inst.Constants.Levels[i];
                    //TODO: instantiate level prefab
                    //build navmesh after instantiation
                }
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (timeLimit > 0f)
        {
            timeLimit -= Time.fixedDeltaTime;
        } else
        {
            timeLimit = 0f;
        }

        remainingTime.text = timeLimit.ToString("00.0");
    }

    public void ShieldDeployed()
    {
        deployedShields++;

        shields.text = "Shields: " + deployedShields + " / " + currLevel.ShieldLimit;
    }

    public void SurvivorSaved()
    {

    }

    public void SurvivorDeath()
    {
        survivorsRemaining--;

        remainingSurvivors.text = "Remaining: " + survivorsRemaining.ToString() + " Saved: " + survivorsSaved.ToString() + " Died: ";

        if (survivorsRemaining <= currLevel.RequiredSurvivors)
        {
            GameOver();
        }
    }

    public void CalculateScore()
    {
        
    }

    public void GameOver()
    {

    }
}
