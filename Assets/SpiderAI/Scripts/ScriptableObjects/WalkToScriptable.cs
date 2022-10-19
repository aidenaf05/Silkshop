using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewWalkToData", menuName = "ScriptableObjects/WalkTo", order = 1)]
public class WalkToScriptable : ScriptableObject
{
    public float speed = 1;
    public float randomness = 0;

    public float endRange = 0.5f;
}
