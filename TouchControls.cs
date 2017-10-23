using UnityEngine;
using System.Collections;

public class TouchControls : MonoBehaviour {

    private PlayerMovementInRunner thePlayer;
	// Use this for initialization
	void Start () {
        thePlayer = FindObjectOfType<PlayerMovementInRunner>();
	}
    public void LeftArrow()
    {
        thePlayer.Move(-1); }
    public void RightArrow()
    { thePlayer.Move(1); }
    public void Unpressed()
    { thePlayer.Move(0); }
    public void JumpButton()
    { thePlayer.Jump(); }
}
