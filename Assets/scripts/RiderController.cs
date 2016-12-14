using UnityEngine;
using System.Collections;

public class RiderController : MonoBehaviour 
{
	void Start () 
	{
		Reset();
	}

	void Update ()
	{
		// if dead? or make that an event subscription,... on collision??
	}

	public void Ride()
	{
		gameObject.GetComponentInParent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
	}

	public void Reset()
	{
		gameObject.transform.position = _startingPosition;
		gameObject.transform.rotation = Quaternion.identity;
		gameObject.GetComponentInParent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeAll;
	}

	public Vector3 _startingPosition;
}
