using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] Transform nextGoal;
    bool triggered;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Survivor"))
        {
            Survivor survivor = other.GetComponent<Survivor>();
            if (survivor.goal != nextGoal)
                survivor.goal = nextGoal;
        }
    }
}
