using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Constants", menuName = "Data/Create new Constants object")]
public class Constants : ScriptableObject
{
    public float maxShieldDuration = 30f;
    public int maxDeployedShields = 5;
    [SerializeField] LevelData[] levels;

    public LevelData[] Levels
    {
        get
        {
            return levels;
        }
    }

    [SerializeField] GradingCriteria[] grades;

    public GradingCriteria[] Grades
    {
        get
        {
            return grades;
        }
    }

    public LayerMask deployableLayers;
    public LayerMask navMeshLayers;
}

[System.Serializable]
public class GradingCriteria
{
    public string grade = "C";
    [Range(0f, 1f)]
    public float upperBound;
    [Range(0f, 1f)]
    public float lowerBound;
}
