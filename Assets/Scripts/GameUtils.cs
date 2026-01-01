
using UnityEngine;

public static class GameUtils 
{
    public static int GetRandomInt(int minValue, int maxValue)
    {
        int value = Random.Range(minValue, maxValue);
        return value;
    }

    public static float GetRandomFloat(float minValue, float maxValue)
    {
        float value = Random.Range(minValue, maxValue);
        return value;
    }
}
