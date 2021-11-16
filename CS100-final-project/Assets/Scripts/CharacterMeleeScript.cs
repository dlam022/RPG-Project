using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMeleeScript : MonoBehaviour
{
    [SerializeField]
    private Animator anim;
    private bool attacking;

    //The key to be pressed to attack. We can change this or specify in editor
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
        //Only start the coroutine if not already attacking
        if(Input.GetKeyDown(attackKeycode) && !attacking)
        {
            StartCoroutine(MeleeAttack());
        }
    }

    public IEnumerator MeleeAttack()
    {
        anim.SetBool("Is Attacking", true);
        yield return new WaitForEndOfFrame();

        //Gets the length of the currently playing animation (this is why we needed to wait until a new frame)
        float time = anim.GetCurrentAnimatorStateInfo(0).length -Time.deltaTime;
        attacking = true;

        while (attacking) 
        {
            time -= Time.deltaTime;
            yield return null;
        }

        anim.SetBool("Is Attacking", false);
        attacking = false;
        yield return null;
    }


    //In order to notify the animator of when the animation is finished, this method is called via animation
    //event in a keyframe. The animation itself calls it.
    public void AttackFinished()
    {
        attacking = false;
    }
}
