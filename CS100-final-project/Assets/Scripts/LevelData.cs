using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class IntEvent : UnityEvent<int> { };

[System.Serializable]
public class LevelData
{
    [SerializeField]
    private int currentExperience;
    [SerializeField]
    private int experienceRequiredToLevelUp;

    [SerializeField]
    private int currentLevel;

    public IntEvent OnGainExperience;
    public IntEvent OnGainlevel;

    public int GetLevel()
    {
        return currentLevel;
    }

    public int GetCurrentExperience()
    {
        return currentExperience;
    }

    public int GetExperienceRequiredForNextLevel()
    {
        return experienceRequiredToLevelUp;
    }

    public void GainExperience(int amount)
    {
        currentExperience += amount;

        if(OnGainExperience != null)
        {
            OnGainExperience.Invoke(amount);
        }

        if(currentExperience >= experienceRequiredToLevelUp)
        {
            LevelUp();
        }
    }


    private void LevelUp()
    {
        currentLevel++;
        experienceRequiredToLevelUp = CalculateExperienceRequiredToLevelUp();

        if(OnGainlevel != null)
        {
            OnGainlevel.Invoke(currentLevel);
        }

    }

    private int CalculateExperienceRequiredToLevelUp()
    {
        return ((int)Mathf.Pow(currentLevel, 4) + 50);
    }
}
