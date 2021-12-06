using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMeleeBehaviour : MonoBehaviour
{
    private Animator anim;
    private bool attacking;

    [Tooltip("0 = Right, 1 = Up, 2 = Left, 3 = Down")]
    public List<Collider2D> hitBoxes;

    private Transform playerReference;

    //reference to the character Sheet associated with this game object
    public CharacterSheet characterSheet;

    public float attackCooldown;
    public float counter;

    // Start is called before the first frame update
    void Start()
    {
        attacking = false;

        if (anim == null)
        {
            anim = GetComponent<Animator>();
        }

        if (characterSheet == null && TryGetComponent<CharacterSheetHolder>(out CharacterSheetHolder csh) && csh.characterSheet != null)
        {
            characterSheet = csh.characterSheet;
        }
        else
        {
            Debug.LogError("Character sheet holder not found or character sheet is null for gameobject " + gameObject.name);
        }

        playerReference = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        if (PersistentGameManager.GetInstance().InDialogue() || PersistentGameManager.GetInstance().Paused())
        {
            return;
        }

        float distance = Vector3.Distance(transform.position, playerReference.position);
        if (distance > 0.7f || attacking)
        {
            //Reset the attack cooldown if the npc is out of range.
            counter = attackCooldown;
            return;
        }

        if(counter >= 0 && distance <= 0.7f)
        {
            counter -= Time.deltaTime;
            return;
        }

        StartCoroutine(MeleeAttack());
        counter = attackCooldown;

    }


    public IEnumerator MeleeAttack()
    {
        anim.SetBool("Is Attacking", true);
        yield return new WaitForEndOfFrame();

        //Gets the length of the currently playing animation (this is why we needed to wait until a new frame)
        float time = anim.GetCurrentAnimatorStateInfo(0).length - Time.deltaTime;
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

        //Turn off the hitbox if it is on
        foreach (BoxCollider2D collider in hitBoxes)
        {
            if (collider.enabled)
            {
                collider.enabled = false;
            }
        }
    }

    public void ActivateHitBox()
    {


        //Get the face direction of the character
        Vector2 directionVector = new Vector2(anim.GetFloat("Move X"), anim.GetFloat("Move Y"));
        //Get the angle in radians using Atan2, then convert to degrees
        float angle = Mathf.Atan2(directionVector.y, directionVector.x) * Mathf.Rad2Deg;
        //The previous bit of math gets an angle between -180 and 180, we want a value between 0 and 360.
        if (angle < 0)
        {
            angle += 360;
        }

        //The closest multiple of x for value v is found using: x * Mathf.RoundToInt(v / x);
        //We are converting that to an index between 0 and 4, so we simply omit the multiplication by x, in this case 90.
        int index = Mathf.RoundToInt(angle / 90);

        //The math above can result in an angle of 360 degrees / 90 = 4. That angle is mathematically equivalent to 0 degrees which gives index 0 (by the unit circle) 
        //We must adjust the index accordingly to prevent an out of range exception.
        if (index == 4)
        {
            index = 0;
        }

        hitBoxes[index].enabled = true;

        List<Collider2D> overlappingColliders = new List<Collider2D>();
        ContactFilter2D noFilter = new ContactFilter2D();

        //get a list of all colliders overlapping the hitbox
        hitBoxes[index].OverlapCollider(noFilter.NoFilter(), overlappingColliders);

        foreach (Collider2D collider in overlappingColliders)
        {
            if (collider.gameObject.CompareTag("Hitbox") && collider.gameObject.transform.parent.gameObject != this.gameObject)
            {
                Debug.Log("Hit a hitbox belonging to " + collider.gameObject.transform.parent.gameObject.name);

                //wew lord
                if (collider.gameObject.transform.parent.TryGetComponent<CharacterSheetHolder>(out CharacterSheetHolder csh))
                {
                    CharacterSheet other = csh.characterSheet;
                    DealDamageTo(other);
                }

                break;
            }
        }
    }

    public void DealDamageTo(CharacterSheet other)
    {
        int atk = characterSheet.stats.GetAttack() + characterSheet.inventory.GetAttackRating();



        int dmg = atk - other.inventory.GetArmorRating();
        dmg = Mathf.Clamp(dmg, 0, 1000000);

        other.stats.ModifyCurrentHealth(dmg * -1);

    }
}
