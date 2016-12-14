using UnityEngine;
using System.Collections;

public class Artist : MonoBehaviour 
{
	void Start()
	{
		_isDrawing = false;
	}

	void Update ()
	{
		if (Input.GetMouseButtonDown (0))
		{
			_isDrawing = true;
			Vector3 currentPosition = _camera.ScreenToWorldPoint (Input.mousePosition);
			currentPosition.z = 0;

			_startLinePoint = currentPosition;
			_lastPenLocation = currentPosition;

		}
		else if (Input.GetMouseButtonUp (0))
		{
			_isDrawing = false;
			Vector3 currentPenLocation = _camera.ScreenToWorldPoint (Input.mousePosition);
			drawLine (_lastPenLocation, currentPenLocation);
			Destroy (_aimParticles.gameObject);
		}
		else if (_isDrawing)
		{
			if (_aimParticles == null) {
				_aimParticles = Instantiate (_aimParticlePrefab, _startLinePoint, _aimParticlePrefab.transform.rotation) as ParticleSystem;
			}

			Vector3 pointerPosition = _camera.ScreenToWorldPoint (Input.mousePosition);
			pointerPosition.z = 0; // TODO make this anotherr method
			_aimParticles.transform.LookAt (pointerPosition);
		}
	}

	private void drawLine(Vector3 start, Vector3 end)
	{
		// change them to be in 2d space
		start = new Vector3(start.x, start.y, 0);
		end = new Vector3 (end.x, end.y, 0);

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
	public ParticleSystem _aimParticlePrefab;

	private bool _isDrawing;
	private Vector3 _lastPenLocation;
	private ParticleSystem _aimParticles;
	private Vector3 _startLinePoint;

}