using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class Conversation : MonoBehaviour
{

    public static Conversation _Conversation;
    public TextAsset textfile;  // .txt failut koito shte zadadem za dialog
    public string[] textlines;  // izpolzvam go za holder na redovete na .txt fila( vseki element na textlines e red na failut)
    public GameObject Textbox;  // kutiqta, koqto durji teksta v igrata
    public Text theText;    //  tekstut koito se pokazva v igrata   
    public int currentLine;
    public int endLine;
    public bool show;
    public bool isTyping;
    private bool canceltyping;
    public float typeSpeed;


    void Start()
    {
        if (textfile != null)   //proverqva dali failut e prazen
            textlines = textfile.text.Split('\n');  // elementite na textlines stavat otdelnite redove na .txt

        if (endLine == 0)
            endLine = textlines.Length - 1;

        if (show)
            ActivateTextbox();
        else
            DisableTextbox();
    }


    void Update()
    {
        if (!show)
            return;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (!isTyping)
            {
                currentLine++;
                if (currentLine > endLine)
                    DisableTextbox();
                else
                    StartCoroutine(TextAnim(textlines[currentLine]));
            }
            else if (isTyping && !canceltyping)
            {
                canceltyping = true;
            }
        }

    }

    private IEnumerator TextAnim(string textlines)
    {
        int currentLetter = 0;
        isTyping = true;
        canceltyping = false;
        theText.text = "";
        while (isTyping && !canceltyping && (currentLetter < textlines.Length - 1))
        {
            theText.text += textlines[currentLetter];
            currentLetter++;
            yield return new WaitForSeconds(typeSpeed);
        }
        theText.text = textlines;
        isTyping = false;
        canceltyping = false;
    }

    public void ActivateTextbox()
    {
        Textbox.SetActive(true);    // vkluchva kutiqta,koqto durji teksta v igrata
        show = true;
        PlayerMovement.CanMove = false;
        StartCoroutine(TextAnim(textlines[currentLine]));
    }
    public void DisableTextbox()
    {
        Textbox.SetActive(false);   // izkluchva kutiqta,koqto durji teksta v igrata
        show = false;
        PlayerMovement.CanMove = true;
    }
    public void ReActivate(TextAsset textfileOther)    //reactivira scripta s nov .txt file
    {
        if (textfile != null)
        {
            textlines = new string[1];
            textlines = textfileOther.text.Split('\n');
            endLine = textlines.Length - 1;
            currentLine = 0;
        }
        ActivateTextbox();
    }
}
