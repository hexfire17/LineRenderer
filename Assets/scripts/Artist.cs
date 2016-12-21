using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Artist : MonoBehaviour 
{
	void Start()
	{
		_PlayerInput = FindObjectOfType<PlayerInput> ();
		_LineDrawer = FindObjectOfType<LineDrawer> ();
		_EditorCameraController = FindObjectOfType<EditorCameraController> ();
		_currentMode = ArtistMode.IDLE;
	}

	void Update ()
	{
		if (_PlayerInput.IsMouseDown ())
		{
			_currentMode = GetArtistMode ();
			if (_currentMode == ArtistMode.DRAW)
			{
				_LineDrawer.CaptureStartState ();
			}
			else if (_currentMode == ArtistMode.PAN)
			{
				_EditorCameraController.CaptureStartState ();
			}
		}
		else if (_PlayerInput.IsMouseHeld ())
		{
			if (_currentMode == ArtistMode.DRAW)
			{
				_LineDrawer.UpdatePreview ();
			}
			else if (_currentMode == ArtistMode.PAN)
			{
				_EditorCameraController.MoveCameraBasedOnDrag ();
			}
		}
		else if (_PlayerInput.IsMouseUp ())
		{ 
			if (_currentMode == ArtistMode.DRAW)
			{
				_LineDrawer.DrawLineToCurrentLocation ();
			}

			_currentMode = ArtistMode.IDLE;
		}
	}

	private ArtistMode GetArtistMode ()
	{
		Vector3 currentPointerPosition = _PlayerInput.GetPointerLocation ();
		Vector3 currentCameraCenter = _PlayerInput.GetCameraPosition ();

		bool isLeftOfCamera = currentPointerPosition.x > currentCameraCenter.x;
		if (isLeftOfCamera)
		{
			return ArtistMode.PAN;
		} 
		else 
		{
			return ArtistMode.DRAW;
		}
	}

	public GameObject _pen;
	public ParticleSystem _aimParticlePrefab;

	private PlayerInput _PlayerInput;
	private LineDrawer _LineDrawer;
	private EditorCameraController _EditorCameraController;

	private Vector3 _lastPenLocation;
	private ParticleSystem _aimParticles;
	private Vector3 _startLinePoint;
	private ArtistMode _currentMode;

	private enum ArtistMode{DRAW, PAN, IDLE};

}