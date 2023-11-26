using UnityEngine.UI;
using UnityEngine;
using System.Collections;


public class ScoreLabel : MonoBehaviour
{
    public Text label;
    public int score { get; private set; } = 0;

    void Update()
    {
        label.text = score.ToString();

    }

    // Call this when a firefly is caught
    public void OnCatch()
    {
        score += 1;
        Debug.Log(score);
    }
}
