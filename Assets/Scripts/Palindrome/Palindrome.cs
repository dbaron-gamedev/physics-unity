using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Palindrome", menuName = "Scriptable Objects/Palindrome")]
public class Palindrome : ScriptableObject
{
    [Header("Puzzle Info")]
    public string puzzleName;
    [TextArea(2, 5)]
    public string description;
    public int difficulty = 1;

    [Header("Word Pool (Scrambled Input)")]
    public List<string> words = new List<string>();

    [Header("Optional: Correct Solution Order")]
    public string solution;
    

    [Header("Hints")]
    [TextArea]
    public string hint;
}
