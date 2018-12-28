using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class Factory : MonoBehaviour
{

	public float Width = 1;
	public float Height = 1;
	public string MaterialName = "";
	
	// Use this for initialization
	void Start ()
	{
		GameObject go = WallFactory.CreateFlattWall(Width, Height, MaterialName);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
