using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PictureTransition : MonoBehaviour {
    public Sprite Chemistrysnimka;
    public Sprite Physicsysnimka;
    public Sprite Biologysnimka;
    public GameObject Panel;
    public void SmqnaSnimka()
    {
        if (Panel.GetComponent<TheQuestion>().br == 1)
        {
            gameObject.GetComponent<Image>().overrideSprite = Chemistrysnimka;
        }
        if (Panel.GetComponent<TheQuestion>().br == 2)
        {
            gameObject.GetComponent<Image>().overrideSprite = Physicsysnimka;
        }
        if (Panel.GetComponent<TheQuestion>().br == 3)
        {
            gameObject.GetComponent<Image>().overrideSprite = Biologysnimka;
        }
    }
}
