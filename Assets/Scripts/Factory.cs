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

	[SerializeField]
	public List<Wall> Walls;

	[Serializable]
	public class Wall
	{
		public Vector3 Start;
		public Vector3 End;
		public float Height;
		public string MaterialName;
		public GameObject GameObject;
	}
	
	// Use this for initialization
	void Start ()
	{
		ModelFactory.CreateWall(Width, Height, MaterialName);
		ModelFactory.CreatePositionedWall(start, end, height, posMatName);
		
	}
	
	// Update is called once per frame
	void Update () {
		Walls.ForEach(w =>
		{
			if (w.GameObject == null)
			{
				w.GameObject = ModelFactory.CreatePositionedWall(w.Start, w.End, w.Height, w.MaterialName);
			}
		});
	}
}
