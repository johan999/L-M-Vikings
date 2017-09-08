using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour {

    public GameObject textBox;
    public Text theText;

    public TextAsset textFile;
    public string[] textLines;

    public int currentLine;
    public int endAtLine;

    public bool isActive;

    public bool stopPlayerMovement;
    public bool canPress = false;

    // Use this for initialization
    void Start()
    {
        if (textFile != null)
        {
            textLines = (textFile.text.Split('\n'));
        }

        if(endAtLine == 0)
        {
            endAtLine = textLines.Length - 1;
        }

        if (isActive)
        {
            EnableTextBox();
        }
        else
        {
            DisableTextBox();
        }
    }

    void Update()
    {
        
        if (!isActive)
        {
            return;
        }
        theText.text = textLines[currentLine];

        if (canPress && Input.GetKeyDown(KeyCode.J))
        {
            currentLine++;                      
        }
        canPress = true;
        if (currentLine > endAtLine)
        {
            DisableTextBox();
        }        
    }

    public void EnableTextBox() {
        textBox.SetActive(true);
        isActive = true;

        if (stopPlayerMovement)
        {
            GameObject.Find("Player").GetComponent<Navigation>().canMove = false;
        }
    }

    public void DisableTextBox()
    {
        textBox.SetActive(false);
        isActive = false;

        GameObject.Find("Player").GetComponent<Navigation>().canMove = true;
        canPress = false;
    }


    public void ReloadScript(TextAsset theText) {
        if (theText != null)
        {
            textLines = new string[1];
            textLines = (theText.text.Split('\n'));
        }
    }
}
