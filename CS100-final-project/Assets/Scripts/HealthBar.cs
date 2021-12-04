using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{

    //public bool testTakeDamageButton;
    //public int testAmount;

    public TMP_Text Text;

    public Image healthBarFill;
    public CharacterSheet character;

    public Color HealthyColor;
    public Color DamagedColor;
    public Color DyingColor;

    // Start is called before the first frame update
    void Start()
    {
        character = transform.root.GetComponentInChildren<CharacterSheetHolder>().characterSheet;

        if(character.stats.OnModifyHealth == null)
        {
            character.stats.OnModifyHealth = new IntEvent();
        }
        character.stats.OnModifyHealth.RemoveListener(UpdateFill);
        character.stats.OnModifyHealth.AddListener(UpdateFill);


        Text.text = character.CharacterName;

    }

    public void UpdateFill(int amount)
    {
        float ratio = (float)character.stats.GetCurrentHealth() / (float)character.stats.GetMaxHealth();

        healthBarFill.fillAmount = ratio;

        if(ratio > 0.66f)
        {
            healthBarFill.color = HealthyColor;
        }
        else if(ratio <= 0.66f && ratio > 0.33f)
        {
            healthBarFill.color = DamagedColor;
        }
        else
        {
            healthBarFill.color = DyingColor;
        }

        if(ratio <=0)
        {
            Destroy(this.gameObject);
        }
    }

    /*
    public void OnValidate()
    {
        if(testTakeDamageButton)
        {
            testTakeDamageButton = false;

            character.stats.ModifyCurrentHealth(testAmount);
        }
    }
    */
}
