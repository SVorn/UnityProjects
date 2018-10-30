using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


	public Camera camera;
	[SerializeField]
	private GameObject target;
	private float singleTouchLength;
	private float singleTouchBeginnTime;

	[SerializeField]
	private float movementSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.touchCount == 1){
			Touch touch = Input.GetTouch(0);
			print(touch.position);

			if (touch.phase == TouchPhase.Began)
                    {
                        singleTouchBeginnTime = Time.time;
                        singleTouchLength = 0f;
                    }
                    else
                    {
                        singleTouchLength = Time.time - singleTouchBeginnTime;
                    }

			if (singleTouchLength < 0.2f  && touch.phase == TouchPhase.Ended)
                    {
                        SelectObjects(touch);
                    }
                    else
                    {
                      //  MoveCamera(touch);
					  MoveCube(touch);
                    }
			
		}
	}

	void SelectObjects(Touch touch){
		RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(touch.position);

		if(Physics.Raycast(ray, out hit, 100)){
			if(hit.collider.tag == "Earth"){
				Destroy(hit.collider.gameObject);
				print("HIT");
			}
		}
	}

	void MoveCamera(Touch touch){
		
        Vector2 touchPrevPos = touch.position - touch.deltaPosition;
		Vector2 movementVector;

		movementVector = touch.deltaPosition * (movementSpeed / 100000) * (camera.transform.position.y * 100);
		camera.transform.position -= camera.transform.TransformDirection(new Vector3(movementVector.x, movementVector.y, 0f));


	}

	void MoveCube(Touch touch){
	//	target.transform.Rotate(touch.deltaPosition.y*movementSpeed,touch.deltaPosition.x * movementSpeed,0,Space.World);
		target.transform.RotateAround(Vector3.zero,Vector3.up,touch.deltaPosition.x*movementSpeed);
	}
}
