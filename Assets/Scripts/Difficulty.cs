using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Difficulty
{
    private static float _secondsToMaxDifficulty = 60;

    public static float GetDifficultyPercent()
    {
        return Mathf.Clamp01(Time.timeSinceLevelLoad / _secondsToMaxDifficulty);
    }
}
