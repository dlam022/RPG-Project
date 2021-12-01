using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class CharacterSheetEvent : UnityEvent<CharacterSheet> { };


[CreateAssetMenu(menuName = "CharacterSheet", fileName = "New Character Sheet")]
public class CharacterSheet : ScriptableObject
{
    public string CharacterName;


    public CharacterBasicStats stats;
    public Inventory inventory;
    public LevelData levelData;


    //
    public CharacterSheetEvent OnKillsCharacter;


}
