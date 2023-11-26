using UnityEngine.UI;

public class ScoreLabel : Text
{
    public int score { get; private set; } = 0;

    void Update()
    {
        text = score.ToString();
    }

    // Call this when a firefly is caught
    void OnCatch()
    {
        score += 1;
    }
}
