using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermanger : MonoBehaviour
{
	#region Singleton

	public static playermanger instance;

	void Awake()
	{
		instance = this;
	}

	#endregion
	public GameObject player;
}
