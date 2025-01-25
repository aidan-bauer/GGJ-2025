using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Levels", menuName = "Data/Create new Levels object")]
public class Levels : ScriptableObject
{
    [SerializeField] LevelData[] levels;
}
