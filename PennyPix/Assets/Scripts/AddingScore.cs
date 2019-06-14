using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class AddingScore : MonoBehaviour
{
    public static int count = 0;
    Text score;
    void Start()
    {
        score = GetComponent<Text>();
    }
    void Update()
    {
        score.text = "Score:  " + count;
    }
}