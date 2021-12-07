using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UseItemStrategy
{
    protected CharacterSheet characterSheet;
    protected Item item;
    protected abstract void Execute();

}
