using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName ="PreviousLevelData", menuName ="ScriptableObject/Level", order = 1)]
public class LevelLoadScriptableObject : ScriptableObject {
    [Header("Name of the previous scene")]
    public string previousLevelName = "";
}
