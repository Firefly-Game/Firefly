using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreLabel : MonoBehaviour
{
    public Text label;

    private Dictionary<FireflyBehaviour.FireflyType, int> typeValues = new Dictionary<FireflyBehaviour.FireflyType, int> {
        { FireflyBehaviour.FireflyType.Common,    1 },
        { FireflyBehaviour.FireflyType.Rare,      3 },
        { FireflyBehaviour.FireflyType.Epic,      8 },
        { FireflyBehaviour.FireflyType.Legendary, 25 },
    };

    public int score { get; private set; } = 0;

    void Update()
    {
        label.text = score.ToString();
    }

    // Call this when a firefly is caught
    public void OnCatch(FireflyBehaviour firefly)
    {
        score += typeValues[firefly.Type];
    }
}
