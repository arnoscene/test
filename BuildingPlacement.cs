using UnityEngine;
using System.Collections;

public class BuildingPlacement : MonoBehaviour {

	public static BuildingPlacement control;

	private Transform currentBuilding;

//	private bool hasPlaced;
//	placeableBuilding Placeable;
//	placeableBuilding placeableBuildingOld;
//	public LayerMask buildingsMask;
	

	// Use this for initialization
	void Start () {

		control =  this;
	
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 m = Input.mousePosition;
		m = new Vector3(m.x,m.y,transform.position.y);
		Vector3 p = camera.ScreenToWorldPoint(m);

		if(currentBuilding !=  null && !hasPlaced){
			currentBuilding.position =  new Vector3(p.x,3.327274f,p.z);


		if(Input.GetMouseButtonDown(0))
		{

				if(isLegalPosition())
					hasPlaced = true;
				
		}
		}
		else 
		{
			if(Input.GetMouseButtonDown(0))
			{
				//print ("else mouse");
				RaycastHit hit = new RaycastHit();
			
				Ray ray = new Ray(new Vector3(p.x,30,p.z),Vector3.down);
				if(Physics.Raycast(ray,out hit,Mathf.Infinity,buildingsMask)){
					if(placeableBuildingOld != null)
					{
						
						print ("Yes this is working");
						placeableBuildingOld.SetSelected(false);
					}

					hit.collider.gameObject.GetComponent<placeableBuilding>().SetSelected(true);
					Placeable = hit.collider.gameObject.GetComponent<placeableBuilding>();
					placeableBuildingOld = Placeable; 


				}else
				{
					if(placeableBuildingOld != null)
					{
						
						print ("ielse also working");
						placeableBuildingOld.SetSelected(false);
					}
				}
			}
			
		}

				
		
			
			
		
	
	}

	bool isLegalPosition()
	{
		if(Placeable.col.Count > 0 )
		{
			return false;
		}
		return true;
	}

	public void SetItem(GameObject b)
	{
		hasPlaced = false;
		currentBuilding = ((GameObject)Instantiate(b)).transform;
		Placeable = currentBuilding.GetComponent<placeableBuilding>();

	}
}
