using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class Factory : MonoBehaviour
{

	public float Width = 1;
	public float Height = 1;
	public string MaterialName = "";


	public Vector3 start = new Vector3(1,0,0);
	public Vector3 end = new Vector3(0,0,1);
	public float height = 2f;
	public string posMatName = "";

	
	public Vector3 pos = new Vector3(10,0,0);
	public float Size = 10f;
	public float RH = 5f;
	public string[] names = new[] {"Concrete", "Concrete", "Concrete", "Concrete", "Concrete", "Concrete"};

	public float CW = 1;
	public float CH = 1;
	public float CD = 1;
	
	// Use this for initialization
	void Start ()
	{
		ModelFactory.CreateWall(Width, Height, MaterialName).transform.position = new Vector3(-2,0,0);
		ModelFactory.CreatePositionedWall(start, end, height, posMatName);
		ModelFactory.CreateSquareRoom(pos, Size, RH, names);
		ModelFactory.CreateCuboid(CW, CH, CD).transform.position = new Vector3(1,1,-1);
	}
}
