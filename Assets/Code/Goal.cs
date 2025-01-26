using System.Collections;
using System.Collections.Generic;
using Events;
using UnityEngine;

public class Goal : MonoBehaviour
{

    [SerializeField] GameEvent survivorSaved;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Survivor"))
        {
            survivorSaved.Raise();
        }
    }
}
