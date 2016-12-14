using UnityEngine;
using System.Collections;

public class Rider : MonoBehaviour 
{
	void Start () 
	{
		gameObject.GetComponentInParent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
	}

	void Update ()
	{
		// if dead? or make that an event subscription,... on collision??
	}

	public void Ride()
	{
		gameObject.GetComponentInParent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
	}

}
