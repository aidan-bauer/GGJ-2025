using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{

    public static DontDestroy inst
    {
        get;
        private set;
    }

    [SerializeField] Constants constants;
    public Constants Constants
    {
        get
        {
            return constants;
        }
    }

    private void Awake()
    {
        if (inst != null && inst != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            inst = this;
            DontDestroyOnLoad(this.gameObject);
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
}
