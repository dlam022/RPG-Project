using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueButtonPrefab;
    public GameObject TextBoxPrefab;
    public TMP_Text textBox;
    public List<GameObject> activeButtons;
    public float textCrawlSpeed;

    public void SetupTextBox(DialogueNodeScript currentNode)
    {
        ClearBox();      
        StartCoroutine(DisplayText(currentNode));
        if(currentNode.Options.Count >1)
        {
            AddButtons(currentNode);
        }
    }

    public void ClearBox()
    {
        if(activeButtons.Count > 0)
        {
            for (int i = 0; i < activeButtons.Count; i++)
            {
                Destroy(activeButtons[i]);
            }
            activeButtons.Clear();
        }

        if(textBox != null)
        {
            Destroy(textBox.gameObject);
        }
        
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
                button.SetupButton(this, option);


                activeButtons.Add(g);

                g.SetActive(true);
            }
        }
    }

    public IEnumerator DisplayText(DialogueNodeScript node)
    {
        if (node.MainBodyString.Length > 0)
        {
            GameObject box = Instantiate(TextBoxPrefab);
            box.transform.SetParent(TextBoxPrefab.transform.parent);
            textBox = box.GetComponent<TMP_Text>();
   
            yield return new WaitForEndOfFrame();

            textBox.text = "";
            box.SetActive(true);

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
