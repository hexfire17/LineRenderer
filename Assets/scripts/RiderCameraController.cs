using UnityEngine;
using System.Collections;

public class RiderCameraController : MonoBehaviour 
{
	void Start () 
	{
		_offset = transform.position - _rider.transform.position;
	}

	// LateUpdate is called after Update each frame
	void LateUpdate () 
	{
		transform.position = _rider.transform.position + _offset;
	}

	public GameObject _rider;
	private Vector3 _offset;
}