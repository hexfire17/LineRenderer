using UnityEngine;
using System.Collections;

public class LineDrawer : MonoBehaviour {
	
	void Start ()
	{
		_playerInput = FindObjectOfType<PlayerInput> ();
		_trackManager = FindObjectOfType<TrackManager> ();
	}

	public void CaptureStartState ()
	{
		Vector3 currentPosition = _playerInput.GetPointerLocation ();
		_startLinePoint = currentPosition;
		_lastPenLocation = currentPosition;
	}

	public void UpdatePreview ()
	{
		if (_aimParticles == null)
		{
			_aimParticles = Instantiate (_aimParticlePrefab, _startLinePoint, _aimParticlePrefab.transform.rotation) as ParticleSystem;
		}

		Vector3 currentPosition = _playerInput.GetPointerLocation ();
		_aimParticles.transform.LookAt (currentPosition);
	}

	public void DrawLineToCurrentLocation ()
	{
		Vector3 currentPosition = _playerInput.GetPointerLocation ();
		drawLine (_lastPenLocation, currentPosition);
		Destroy (_aimParticles.gameObject);
	}

	private void drawLine(Vector3 start, Vector3 end)
	{
		// Calculate positon
		Vector3 linePosition = (start + end) / 2;

		// Calculate scale
		float distance = Vector3.Distance (start, end);
		Vector3 localScale = Vector3.right * distance;

		// Calculate rotation
		float slope = (end.y - start.y) / (end.x - start.x);
		float angle = Mathf.Rad2Deg * Mathf.Atan (slope);
		Quaternion rotation = Quaternion.Euler (0, 0, angle);

		LineElement line = new LineElement (linePosition, localScale, rotation);
		_trackManager.AddTrackElement (line);
	}

	public ParticleSystem _aimParticlePrefab;

	private PlayerInput _playerInput;
	private TrackManager _trackManager; // TODO maybe change this to a draw event and the manager will auto capture it??

	private Vector3 _lastPenLocation;
	private ParticleSystem _aimParticles;
	private Vector3 _startLinePoint;

}
