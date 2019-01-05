using System;
using System.Collections;
using System.Collections.Generic;
using Unibas.DBIS.DynamicModelling;
using Unibas.DBIS.DynamicModelling.Models;
using Unibas.DBIS.DynamicModelling.Objects;
using UnityEngine;
using UnityEngine.UI;

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

	public Material DoorMaterial;

	public Material ButtonPlate;
	public Material ButtonB;

	public Vector3[] points = new[]
	{
		new Vector3(0, 0, 0), new Vector3(1, 0, 0), new Vector3(0, 1, 0), new Vector3(1, 1, 0)
	};
	
	// Use this for initialization
	void Start ()
	{
		ModelFactory.CreateWall(Width, Height, MaterialName).transform.position = new Vector3(-2,0,0);
		ModelFactory.CreatePositionedWall(start, end, height, posMatName);
		ModelFactory.CreateCuboidRoom(pos, Size, RH, names);

		GameObject cuboid = ModelFactory.CreateCuboid(CW, CH, CD);
		cuboid.transform.position = new Vector3(1,1,-1);
		GameObject canvasObj = new GameObject("Canvas");
		var c = canvasObj.AddComponent<Canvas>();
		canvasObj.transform.parent = cuboid.transform;
		canvasObj.transform.localPosition = Vector3.zero;
		RectTransform rectTransform = (RectTransform) canvasObj.transform;
		canvasObj.transform.localScale = new Vector3(1/rectTransform.rect.width, 1/rectTransform.rect.height, 1);
		c.renderMode = RenderMode.WorldSpace;
		RectTransform rect = (RectTransform)c.transform;
		GameObject button = new GameObject("Button");
		button.transform.parent = canvasObj.transform;
		var b = button.AddComponent<Button>();
		var e =  new Button.ButtonClickedEvent();
		e.AddListener( () => Debug.Log("Clicked"));
		b.onClick = e;
		
		
		
		
		
		ComplexCuboidModel doorModel = new ComplexCuboidModel();
		
		doorModel.Add(Vector3.zero, new CuboidModel(0.05f, 2-0.05f,0.3f,DoorMaterial));
		doorModel.Add(new Vector3(0,2-0.05f,0), new CuboidModel(1.5f+0.1f,0.05f,0.3f,DoorMaterial));
		doorModel.Add(new Vector3(0.05f+1.5f,0,0), new CuboidModel(0.05f, 2-0.05f,0.3f,DoorMaterial));

		ModelFactory.CreateModel(doorModel);
		
		ComplexCuboidModel buttonModel = new ComplexCuboidModel();
		buttonModel.Add(Vector3.zero, new CuboidModel(.1f,.1f,.01f, ButtonPlate));
		buttonModel.Add(new Vector3(0.02f,.02f,-.01f), new CuboidModel(0.1f-0.04f,0.1f-0.04f, 0.01f, ButtonB));
		ModelFactory.CreateModel(buttonModel);

		ModelFactory.CreateFreeformQuad(points[0], points[1], points[2], points[3]);
		
		
		CuboidObject co = CuboidObject.Create(2,3,1);
	}
}
