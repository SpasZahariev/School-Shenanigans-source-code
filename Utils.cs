using UnityEngine;
using System.Collections;

public static class Utils
{
	public static bool HaveSameColor(this DBase dBase, DBase other)
	{
		return dBase.color == other.color;
	}

	public static bool HaveSameColor(this Transform dBase, Transform other)
	{
		return dBase.GetComponent<DBase>().color == other.GetComponent<DBase>().color;
	}

	public static bool HaveSameColor(this Collider2D c, Transform other)
	{
		return c.GetComponent<DBase>().color == other.GetComponent<DBase>().color;
	}

	public static bool HaveSameColor(this Collider2D c, DBase other)
	{
		return c.GetComponent<DBase>().color == other.color;
	}

	public static bool HaveSameColor(this DColor c, Transform other)
	{
		return c == other.GetComponent<DBase>().color;
	}


	public static bool SetBest(int lastScore)
	{
		int best = GetBest();

		if(lastScore > best)
		{
			PlayerPrefs.SetInt("BEST_SCORE",lastScore);
			PlayerPrefs.Save();
			return true;
		}

		return false;
	}

	public static int GetBest()
	{
		return PlayerPrefs.GetInt("BEST_SCORE",0);
	}
}
