using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class placeableBuilding : MonoBehaviour {

	public static placeableBuilding control ;


	public List<Collider> col = new List<Collider>();

	public bool canPlace;
	bool isSelected;

	void Start()
	{
		control = this;
	
	}

	void Update()
	{

	}


		void OnGUI()
	{
		if(isSelected){

			GUI.Button(new Rect(300,200,100,30),name);
		}
	}

	void OnTriggerEnter(Collider c)
	{
		if(c.tag == "building" )
		{
		
			col.Add(c);
		}
		if(c.tag == "road")
		{
			col.Add(c);

		}
		if(c.tag == "ground")
		{
			
			//print("im touching ground");
			canPlace = true;
		}
	}

	void OnTriggerExit(Collider c)
	{
		if(c.tag == "building" || c.tag == "road")
		{
			col.Remove(c);

		}
		if(c.tag == "ground")
		{
			canPlace = false;
		}
	}

	public void SetSelected(bool s)
	{

		isSelected = s;
	}
}
