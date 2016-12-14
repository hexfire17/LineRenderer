using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Artist : MonoBehaviour 
{
	void Start()
	{
		_isDrawing = false;
		_PlayerInput = FindObjectOfType<PlayerInput> ();
	}

	void Update ()
	{
		if (_PlayerInput.IsMouseDown ())
		{
			_isDrawing = true;

			Vector3 currentPosition = _PlayerInput.GetPointerLocation ();
			_startLinePoint = currentPosition;
			_lastPenLocation = currentPosition;

		}
		else if (_PlayerInput.IsMouseUp ())
		{
			_isDrawing = false;
			Vector3 currentPosition = _PlayerInput.GetPointerLocation ();
			drawLine (_lastPenLocation, currentPosition);
			Destroy (_aimParticles.gameObject);
		}
		else if (_isDrawing)
		{
			if (_aimParticles == null) {
				_aimParticles = Instantiate (_aimParticlePrefab, _startLinePoint, _aimParticlePrefab.transform.rotation) as ParticleSystem;
			}

			Vector3 currentPosition = _PlayerInput.GetPointerLocation ();
			_aimParticles.transform.LookAt (currentPosition);
		}
	}

	private void drawLine(Vector3 start, Vector3 end)
	{
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
	public PlayerInput _PlayerInput;

	private bool _isDrawing;
	private Vector3 _lastPenLocation;
	private ParticleSystem _aimParticles;
	private Vector3 _startLinePoint;

}