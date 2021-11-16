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
        anim.SetBool("Is Attacking", true);
        yield return new WaitForEndOfFrame();
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


    public void AttackFinished()
    {
        attacking = false;
    }
}
