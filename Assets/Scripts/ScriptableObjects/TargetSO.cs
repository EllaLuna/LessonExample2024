using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Target", menuName = "Targets/Target", order = 0)]
public class TargetSO : ScriptableObject
{
    [SerializeField] string targetName;
    [SerializeField] public int reward = 1;
    [SerializeField] public int penalty = -1;
    [SerializeField] public Sprite sprite;
}
