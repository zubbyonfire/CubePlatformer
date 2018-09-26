using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CurrentPlayerObject", menuName = "ScriptableObject/Player", order = 1)]
public class PlayerObjectScrtipableObject : ScriptableObject {
    [Header("Reference to current Player Object")]
    public GameObject playerObject = null;
}
