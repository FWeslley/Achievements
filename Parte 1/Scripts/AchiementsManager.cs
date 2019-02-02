using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchiementsManager : MonoBehaviour
{

    private static Dictionary<string, Achievement> achievements = new Dictionary<string, Achievement>();

    void Start()
    {
        GetAchievements();
    }

    void GetAchievements()
    {
        Achievement[] achievementsTemp = Resources.LoadAll<Achievement>("Achievements");

        foreach (var item in achievementsTemp)
            achievements.Add(item.achievementName, item);
    }

    public static void IncreaseAchievementProgress(string achievementName)
    {
        if (achievements.ContainsKey(achievementName))
            achievements[achievementName].Increase("Click Mouse");
    }
}
