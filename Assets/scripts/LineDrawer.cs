using UnityEngine;
using System.Collections;

public class LineDrawer : MonoBehaviour {
	
	void Start ()
	{
		_PlayerInput = FindObjectOfType<PlayerInput> ();
	}

	public void CaptureStartState ()
	{
		Vector3 currentPosition = _PlayerInput.GetPointerLocation ();
		_startLinePoint = currentPosition;
		_lastPenLocation = currentPosition;
	}

	public void UpdatePreview ()
	{
		if (_aimParticles == null)
		{
			_aimParticles = Instantiate (_aimParticlePrefab, _startLinePoint, _aimParticlePrefab.transform.rotation) as ParticleSystem;
		}

		Vector3 currentPosition = _PlayerInput.GetPointerLocation ();
		_aimParticles.transform.LookAt (currentPosition);
	}

	public void DrawLineToCurrentLocation ()
	{
		Vector3 currentPosition = _PlayerInput.GetPointerLocation ();
		drawLine (_lastPenLocation, currentPosition);
		Destroy (_aimParticles.gameObject);
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
	public ParticleSystem _aimParticlePrefab;

	private PlayerInput _PlayerInput;

	private Vector3 _lastPenLocation;
	private ParticleSystem _aimParticles;
	private Vector3 _startLinePoint;
}
