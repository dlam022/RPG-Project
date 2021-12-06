using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    private Vector3 movement;
    private Animator anim;

    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PersistentGameManager.GetInstance().InDialogue() || PersistentGameManager.GetInstance().Paused())
        {
            return;
        }

        if (movement == Vector3.zero)
        {
            anim.SetBool("Is Moving", false);
            return;
        }

        UpdateAnimations();
        transform.position += movement * Time.deltaTime * moveSpeed;

        movement = Vector3.zero;
    }

    public void Move(Vector3 change)
    {
        movement = change;
    }

    private void UpdateAnimations()
    {
        anim.SetBool("Is Moving", true);

        anim.SetFloat("Move X", movement.x);
        anim.SetFloat("Move Y", movement.y);
    }
}
