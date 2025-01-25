using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{

    private void Awake()
    {
        if (LevelManager.inst.Constants.maxShieldDuration > 0f)
            Destroy(gameObject, LevelManager.inst.Constants.maxShieldDuration);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
