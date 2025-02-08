using UnityEngine;

[CreateAssetMenu(fileName = "NewDiff", menuName = "Level/New Difficulty")] // Customize file name and menu path
public class DifficultySO : ScriptableObject // Inherit from ScriptableObject
{
    public float heightOffset;
    public float spawnRate;
    public float moveSpeed;
}