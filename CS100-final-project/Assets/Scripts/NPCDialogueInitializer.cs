using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCDialogueInitializer : MonoBehaviour
{
    public GameObject interactionPromptPrefab;
    public DialogueNodeScript initialNode;
    public GameObject DialogueSystemPrefab;
    public string interactionPromptString;


    private GameObject interactionPromptInstance;
    private TMP_Text interactionPromptText;

    private bool PlayerInRange;

    // Start is called before the first frame update
    void Start()
    {
        interactionPromptInstance = Instantiate(interactionPromptPrefab);
        interactionPromptText = interactionPromptInstance.GetComponentInChildren<TMP_Text>();
        interactionPromptText.text = interactionPromptString;

        interactionPromptInstance.gameObject.transform.SetParent(gameObject.transform);
        interactionPromptInstance.transform.position = new Vector3(transform.position.x,
            transform.position.y + 2, 0);

        interactionPromptInstance.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerInRange && Input.GetKeyDown("e") && !PersistentGameManager.GetInstance().InDialogue())
        {
            GameObject g = Instantiate(DialogueSystemPrefab);
            DialogueManager m = g.GetComponentInChildren<DialogueManager>();
            m.SetupTextBox(initialNode);

            interactionPromptInstance.SetActive(false);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            PlayerInRange = true;
            if (interactionPromptInstance.activeSelf == false)
            {
                interactionPromptInstance.SetActive(true);
            }
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerInRange = false;
            if (interactionPromptInstance.activeSelf == true)
            {
                interactionPromptInstance.SetActive(false) ;
            }
        }
    }
}
