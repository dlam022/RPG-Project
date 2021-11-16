using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMeleeScript : MonoBehaviour
{
    [SerializeField]
    private Animator anim;
    private bool attacking;


    public KeyCode attackKeycode;

    // Start is called before the first frame update
    void Start()
    {
        if(anim == null)
        {
            anim = GetComponent<Animator>();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(attackKeycode) && !attacking)
        {
            StartCoroutine(MeleeAttack());
        }
    }

    public IEnumerator MeleeAttack()
    {


        yield return null;
    }
}
