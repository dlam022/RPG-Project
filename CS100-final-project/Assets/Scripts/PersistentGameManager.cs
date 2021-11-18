using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The Persistent Game Manager handles game states, such as whether the game is paused, which must be easily accessed by many if not all game objects. 
/// </summary>
public class PersistentGameManager : MonoBehaviour
{
    private static PersistentGameManager Instance;
    private bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        if(Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad means that if the scene in which this game object is located in initially gets unloaded, this 
            //game object continues existing.
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this.gameObject);
        }

    }

    public static PersistentGameManager GetInstance()
    {
        return Instance;
    }


    public bool Paused()
    {
        return isPaused;
    }

    public void PauseGame()
    {
        isPaused = true;
    }

    public void UnPauseGame()
    {
        isPaused = false;
    }

}
