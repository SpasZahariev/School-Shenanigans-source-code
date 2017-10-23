using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour {

    public int speed;
    private bool isMoving;
    private Vector2 lastMove;
    private Animator animat;
    private Rigidbody2D myrb;
    public static bool CanMove;
    public static PlayerMovement Player;
    public bool StartD;

    void Awake()
    {
        if (Player == null)
        {
            DontDestroyOnLoad(gameObject);
            Player = this;
        }
        else if (Player != this)
        {
            Destroy(gameObject);
        }
    }

    void Start () {
        animat = GetComponent<Animator>();   //Vzimam animaciqta
        myrb = GetComponent<Rigidbody2D>();     // Vzimam rigidbodyto na player
	}
	
	void Update () {

        isMoving = false;

        if ((CrossPlatformInputManager.GetAxis("Horizontal") > 0.1f || CrossPlatformInputManager.GetAxis("Horizontal") < -0.1f) && CanMove)   // Dvijenie na lqvo/dqsno
        {
            myrb.velocity = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal") * speed * Time.deltaTime, myrb.velocity.y);
            isMoving = true;
            lastMove = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal"), 0f);
        }

        if ((CrossPlatformInputManager.GetAxis("Vertical") > 0.1f || CrossPlatformInputManager.GetAxis("Vertical") < -0.1f) && CanMove)    //Dvijenie gore/dolu
        {
            myrb.velocity = new Vector2(myrb.velocity.x, CrossPlatformInputManager.GetAxis("Vertical") * speed * Time.deltaTime);
            isMoving = true;
            lastMove = new Vector2(0f, CrossPlatformInputManager.GetAxis("Vertical"));
        }

        if ((CrossPlatformInputManager.GetAxis("Horizontal") == 0f && CrossPlatformInputManager.GetAxis("Horizontal") == 0f) || !CanMove)    //Spirane na horizontalnata inerciqta, porodena ot dvijenieto na chovecheto
        {
           myrb.velocity = new Vector2(0f, myrb.velocity.y);
        }

        if ((CrossPlatformInputManager.GetAxis("Vertical") == 0f && CrossPlatformInputManager.GetAxis("Vertical") == 0f) || !CanMove)    //Spirane na verticalnata inerciqta, porodena ot dvijenieto na chovecheto
        {
            myrb.velocity = new Vector2(myrb.velocity.x, 0f);
        }
        animat.SetFloat("Horizontal", CrossPlatformInputManager.GetAxisRaw("Horizontal"));  //Zadavam stoinosta na promenlivata "Horizontal" na animaciqta
        animat.SetFloat("Vertical", CrossPlatformInputManager.GetAxisRaw("Vertical"));  //Zadavam stoinosta na promenlivata "Vertical" na animaciqta
        animat.SetFloat("LastHorizontal", lastMove.x);
        animat.SetFloat("LastVertical", lastMove.y);
        animat.SetBool("IsMoving", isMoving);
    }
}
