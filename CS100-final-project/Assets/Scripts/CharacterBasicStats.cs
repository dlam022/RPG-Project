using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class CharacterBasicStats
{
    public IntEvent OnModifyHealth;

    [SerializeField]
    private int MaxHealth;

    [SerializeField]
    private int CurrentHealth;

    [SerializeField]
    private int Attack;

    [SerializeField]
    private int Defense;

    public int GetMaxHealth()
    {
        return MaxHealth;
    }

    public int GetCurrentHealth()
    {
        return CurrentHealth;
    }

    public int GetAttack()
    {
        return Attack;
    }

    public int GetDefense()
    {
        return Defense;
    }

    public void ModifyMaxHealth(int newMaxHealth)
    {
        MaxHealth = newMaxHealth;
    }

    /// <summary>
    /// Adds the amount passed to the method to the current health. Passed value can be negative. The new current health value is clamped between 0 and Max health.
    /// </summary>
    public void ModifyCurrentHealth(int amount)
    {
        CurrentHealth += amount;

        //Clamps current health between 0 and the maximum amount
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, MaxHealth);

        if(OnModifyHealth != null)
        {
            OnModifyHealth.Invoke(amount);
        }
     
    }
}
