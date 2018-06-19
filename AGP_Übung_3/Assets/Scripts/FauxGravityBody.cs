using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FauxGravityBody : MonoBehaviour {

	private FauxGravityAttractor attractor;
	private Rigidbody rb;

	public bool placeNotOnSurface = false;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		attractor = FauxGravityAttractor.instance;
	}
	
	void FixedUpdate ()
	{
		if (placeNotOnSurface)
			attractor.PlaceNotOnSurface(rb);
		else
			attractor.Attract(rb);
	}

}
