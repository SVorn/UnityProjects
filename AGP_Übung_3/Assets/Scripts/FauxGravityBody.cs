using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FauxGravityBody : MonoBehaviour {
/*Counterpart to the Attractor */
	private FauxGravityAttractor attractor;
	private Rigidbody rb;
	
	[SerializeField]
	private bool placeOnSurface = false;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		attractor = FauxGravityAttractor.instance;
	}
	
	void FixedUpdate ()
	//give Component Rigidbody to Attractor
	{
		if (placeOnSurface)
			attractor.PlaceOnSurface(rb);
		else
			attractor.Attract(rb);
	}

}
