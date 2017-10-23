using UnityEngine;
using System.Collections;

public class InputTouch : MonoBehaviour 
{
	public delegate void OnTouch(TouchDirection td);
	public static event OnTouch OnTouched;

	void Update()
	{

		#if UNITY_TVOS && !UNITY_EDITOR

		float h = Input.GetAxis("Horizontal");

		if(h < 0)
		{
			if(OnTouched!=null)
				OnTouched(TouchDirection.left);
		}
		else if(h > 0)
		{
			if(OnTouched!=null)
				OnTouched(TouchDirection.right);
		}

		#endif

		#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_TVOS && !UNITY_EDITOR
		if (Application.isMobilePlatform || Application.isEditor) 
		{
			int nbTouches = Input.touchCount;

			if (nbTouches > 0) 
			{
				Touch touch = Input.GetTouch (0);

				TouchPhase phase = touch.phase;

				if (phase == TouchPhase.Began) 
				{
					if (touch.position.x < Screen.width / 2f)
					{
						if(OnTouched!=null)
							OnTouched(TouchDirection.left);
					}
					else
					{
						if(OnTouched!=null)
							OnTouched(TouchDirection.right);
					}
				}

				if (phase == TouchPhase.Ended)
				{
					if(OnTouched!=null)
						OnTouched(TouchDirection.none);
				}
			}
		}
		#endif
		 
		#if (!UNITY_ANDROID && !UNITY_IOS && !UNITY_TVOS) || UNITY_EDITOR

		if (Input.GetKeyDown (KeyCode.LeftArrow) || (Input.GetMouseButtonDown(0) && Input.mousePosition.x < Screen.width / 2))
		{
			if(OnTouched!=null)
				OnTouched(TouchDirection.left);

			return;
		}

		if (Input.GetKeyDown (KeyCode.RightArrow) || (Input.GetMouseButtonDown(0) && Input.mousePosition.x > Screen.width / 2))
		{
			if(OnTouched!=null)
				OnTouched(TouchDirection.right);

			return;
		}

		if (Input.GetKeyUp (KeyCode.LeftArrow) || Input.GetMouseButtonUp(0))
		{
			if(OnTouched!=null)
				OnTouched(TouchDirection.none);

			return;
		}

		if (Input.GetKeyUp (KeyCode.RightArrow) || Input.GetMouseButtonUp(0))
		{
			if(OnTouched!=null)
				OnTouched(TouchDirection.none);

			return;
		}

		if(Input.anyKeyDown)
		{
			if(OnTouched!=null)
				OnTouched(TouchDirection.none);
		}

		#endif
	}
}

public enum TouchDirection
{
	none,
	left,
	right
}