using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{

    private void Awake()
    {
        if (DontDestroy.inst.Constants.maxShieldDuration > 0f)
            Destroy(gameObject, DontDestroy.inst.Constants.maxShieldDuration);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDisable()
    {
        
    }
}
