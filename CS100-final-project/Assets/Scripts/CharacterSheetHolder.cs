using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Scriptable objects cannot be attached to game objects like monobehavior. 
//So we must cache a reference in a dummy holder class
public class CharacterSheetHolder : MonoBehaviour
{
    public CharacterSheet characterSheet;


}
