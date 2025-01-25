using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Level", menuName = "Data/Create new LevelData object")]
public class LevelData : ScriptableObject
{
    [SerializeField] string levelName;
    public string LevelName
    {
        get
        {
            return levelName;
        }
    }

    [SerializeField] GameObject prefab;
    public GameObject Prefab
    {
        get
        {
            return prefab;
        }
    }

    [SerializeField] int survivors;
    public int Survivors
    {
        get
        {
            return survivors;
        }
    }

    [SerializeField] int requiredSurvivors;
    public int RequiredSurvivors
    {
        get
        {
            return requiredSurvivors;
        }
    }

    [SerializeField] int shieldLimit;
    public int ShieldLimit
    {
        get
        {
            return shieldLimit;
        }
    }

    [SerializeField] float timeLimit;
    public float TimeLimit
    {
        get
        {
            return timeLimit;
        }
    }

    [SerializeField] float maxScoreTime;
    public float MaxScoreTime
    {
        get
        {
            return maxScoreTime;
        }
    }
}
