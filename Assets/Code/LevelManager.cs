using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager inst;

    [SerializeField] Constants constants;
    [SerializeField] float timeLimit;
    float timer;
    int survivorsRemaining;

    [HideInInspector] public Player player;

    public Constants Constants
    {
        get
        {
            return constants;
        }
    }

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        GetComponent<PauseManager>().player = player;

    }

    private void OnEnable()
    {
        if (inst == null)
        {
            inst = this;
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
        
    }
}
