using UnityEngine;
using System.Collections;

public class FloorElement : DBase 
{
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.GetComponent<Dot>()==null)
		{
			return;
		}

		if(other.HaveSameColor(this))
		{
			gm.Add1Point();
		}
		else
		{
			gm.GameOver();
		}

		Destroy(other.gameObject);
	}
}
