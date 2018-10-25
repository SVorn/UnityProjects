using UnityEngine;

public class Camera_Controller : MonoBehaviour {
	
	[SerializeField]
	private Transform target;

	public float smoothness;

	[SerializeField]
	private Vector3 offset;

	[SerializeField]
	private  float rotationSmoothness;

	void FixedUpdate(){
		//	transform.position = target.position + offset;
		//	transform.rotation = target.rotation;
		//Position
		Vector3 desiredPosition = target.position + (target.rotation*offset);
		Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPosition, smoothness * Time.deltaTime);
		transform.position = smoothedPos;
	
		//Rotation
		Quaternion desiredRotation = Quaternion.LookRotation(target.position - transform.position, target.up);
		Quaternion rotation = Quaternion.Slerp(transform.rotation, desiredRotation, rotationSmoothness * Time.deltaTime);
		transform.rotation = rotation;
		
		//transform.LookAt(target.forward);
		


		
		
		
		
		
	}
}
