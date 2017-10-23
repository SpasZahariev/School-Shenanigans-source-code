using UnityEngine;
using System.Collections;

public class FadeAnim : MonoBehaviour {


    Animator anim;
    bool IsFading = false;



	void Start () {
        anim = GetComponent<Animator>();
	}
    public IEnumerator FadeToClear()
    {
        IsFading = true;
        anim.SetTrigger("FadeIn");

        while (IsFading)
            yield return null;

    }
    public IEnumerator FadeToBlack()
    {
        IsFading = true;
        anim.SetTrigger("FadeOut");

        while (IsFading)
            yield return null;
    }
    void AnimationComplete()
    {
        IsFading = false;
    }

}
