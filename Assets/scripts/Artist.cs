using UnityEngine;
using System.Collections;

public class Artist : MonoBehaviour 
{
	void Start()
	{
		_isDrawing = false;
	}

	// LateUpdate is called after Update each frame
	void Update ()
	{
		if (Input.GetMouseButtonDown (0))
		{
			_isDrawing = true;
		}
		else if (Input.GetMouseButtonUp (0))
		{
			_isDrawing = false;
		}
		else if (_isDrawing)
		{
			print ("held");
			Vector3 spawnPosition = _camera.ScreenToWorldPoint (Input.mousePosition);
			spawnPosition.z = 0;
			Instantiate (_pen, spawnPosition, _pen.transform.rotation); // TODO as?? store in arr for better mem?
			// TODO slow down drawing??
		}
	}

	public GameObject _pen;
	public Camera _camera;

	private bool _isDrawing;
}