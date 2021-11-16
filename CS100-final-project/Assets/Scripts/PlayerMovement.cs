using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //All movement is done via vectors. This vector will determine the characters movement;
    private Vector3 movement = Vector3.zero;
    //The speed at which the character moves
    public float movementSpeed;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Gets input via wasd or arrow keys. is equal to vector3.zero if no input is detected.
        movement = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0).normalized;

        if(movement != Vector3.zero)
        {
            anim.SetBool("Is Moving", true);
            anim.SetFloat("Move X", movement.x);
            anim.SetFloat("Move Y", movement.y);
            transform.position += movement * movementSpeed * Time.deltaTime;
        }
        else
        {
            anim.SetBool("Is Moving", false);
        }

        
    }

  
}
