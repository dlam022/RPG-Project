using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueButtonPrefab;

    public TMP_Text textBox;

    public List<GameObject> activeButtons;

    public float textCrawlSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetupTextBox(DialogueNodeScript currentNode)
    {
        ClearBox();      
        StartCoroutine(DisplayText(currentNode));
        AddButtons(currentNode);
        
    }

    public void ClearBox()
    {
        if(activeButtons.Count > 0)
        {
            for (int i = 0; i < activeButtons.Count - 1; i++)
            {
                Destroy(activeButtons[i]);
            }
            activeButtons.Clear();
        }

        textBox.text = "";
    }

    public void AddButtons(DialogueNodeScript node)
    {
        foreach(DialogueNodeScript option in node.Options)
        {
            if(option.IsAvailable())
            {
                GameObject g = Instantiate(dialogueButtonPrefab);
                g.transform.SetParent(dialogueButtonPrefab.transform.parent);
                DialogueButton button = g.GetComponent<DialogueButton>();
                button.SetupButton(option);

                activeButtons.Add(g);
            }
        }
    }

    public IEnumerator DisplayText(DialogueNodeScript node)
    {
        if (node.MainBodyString.Length > 0)
        {
            int index = 0;
            while (textBox.text != node.MainBodyString)
            {
                textBox.text += node.MainBodyString[index];
                index++;

                if (Input.GetKeyDown("e"))
                {
                    textBox.text = node.MainBodyString;
                }

                yield return new WaitForSeconds(textCrawlSpeed);

            }

            while (!Input.GetKeyDown("e"))
            {
                yield return null;
            }

            if (node.Options.Count == 1)
            {
                SetupTextBox(node.Options[0]);
            }
            else if (node.Options.Count == 0)
            {
                Destroy(this.gameObject);
            }
        }
       
        yield return null;
    }

}
