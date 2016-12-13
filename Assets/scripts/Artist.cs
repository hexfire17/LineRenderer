using UnityEngine;
using System.Collections;

public class Artist : MonoBehaviour 
{
	void Start()
	{
		_isDrawing = false;
		Vector3 start = new Vector3 (0, 0, 0);
		Vector3 end = new Vector3 (2, 2, 0);
		Instantiate (_pen, start, _pen.transform.rotation);
		Instantiate (_pen, end, _pen.transform.rotation);

		// set position
		Vector3 linePosition = (start + end) / 2;
		print ("position: " + linePosition);
		GameObject line = Instantiate (_pen, linePosition, _pen.transform.rotation) as GameObject;

		// set scale
		float distance = Vector3.Distance (start, end);
		print ("dist: " + distance);
		Vector3 originalScale = line.transform.localScale;
		print ("localScale: " + line.transform.localScale);
		line.transform.localScale += (Vector3.forward * distance);

		// rotation
		line.transform.rotation = Quaternion.LookRotation (end);
	}

	void Update ()
	{
		if (Input.GetMouseButtonDown (0))
		{
			_isDrawing = true;

			Vector3 currentPenLocation = _camera.ScreenToWorldPoint (Input.mousePosition);
			currentPenLocation.z = 0;
			Instantiate (_pen, currentPenLocation, _pen.transform.rotation);

			_lastPenLocation = currentPenLocation;

		}
		else if (Input.GetMouseButtonUp (0))
		{
			_isDrawing = false;

			Vector3 currentPenLocation = _camera.ScreenToWorldPoint (Input.mousePosition);
			currentPenLocation.z = 0;

			GameObject line = Instantiate (_pen, currentPenLocation, _pen.transform.rotation) as GameObject;

			float distance = Vector3.Distance (currentPenLocation, _lastPenLocation);
			Vector3 originalScale = line.transform.localScale;
			Vector3 newScale = originalScale + (Vector3.right * distance);
			line.transform.localScale = newScale;
			line.transform.position = line.transform.position - (Vector3.right * distance / 2);

			// rotation
			float rotationAngle = Vector3.Angle (_lastPenLocation, currentPenLocation);
			print(rotationAngle);
			Vector3 rotationVector = new Vector3 (0, 0, rotationAngle);
			line.transform.rotation = Quaternion.Euler (rotationVector.x, rotationVector.y, rotationVector.z);
		}
		else if (_isDrawing)
		{

		}
	}

	public GameObject _pen;
	public Camera _camera;

	private bool _isDrawing;
	private Vector3 _lastPenLocation;
}