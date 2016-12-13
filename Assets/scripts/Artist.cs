using UnityEngine;
using System.Collections;

public class Artist : MonoBehaviour 
{
	void Start()
	{
		_isDrawing = false;
		drawLine (new Vector3(0, 0, 0), new Vector3 (1, 1, 0));
		drawLine (new Vector3(-3, 3, 0), new Vector3 (0, 3, 0));

	}

	void Update ()
	{
		if (Input.GetMouseButtonDown (0))
		{
			_isDrawing = true;
			_lastPenLocation = _camera.ScreenToWorldPoint (Input.mousePosition);

		}
		else if (Input.GetMouseButtonUp (0))
		{
			_isDrawing = false;
			Vector3 currentPenLocation = _camera.ScreenToWorldPoint (Input.mousePosition);

			drawLine (_lastPenLocation, currentPenLocation);
		}
		else if (_isDrawing)
		{

		}
	}

	private void drawLine(Vector3 start, Vector3 end)
	{
		// change them to be in 2d space
		start = new Vector3(start.x, start.y, 0);
		end = new Vector3 (end.x, end.y, 0);

		// debug anchors
		Instantiate (_pen, start, _pen.transform.rotation);
		Instantiate (_pen, end, _pen.transform.rotation);

		// instantiate and set position
		Vector3 linePosition = (start + end) / 2;
		print ("position: " + linePosition);
		GameObject line = Instantiate (_pen, linePosition, _pen.transform.rotation) as GameObject;

		// set scale
		float distance = Vector3.Distance (start, end);
		print ("dist: " + distance);
		Vector3 originalScale = line.transform.localScale;
		print ("localScale: " + line.transform.localScale);
		line.transform.localScale += (Vector3.right * distance);

		// set rotation
		float slope = (end.y - start.y) / (end.x - start.x);
		float angle = Mathf.Rad2Deg * Mathf.Atan (slope);
		print ("slope: " + slope);
		print ("FAngle: " + angle);
		line.transform.rotation = Quaternion.Euler (0, 0, angle);
	}

	public GameObject _pen;
	public Camera _camera;

	private bool _isDrawing;
	private Vector3 _lastPenLocation;
}