using UnityEngine;
using System.Collections;

public class EditorCameraController : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		_playerInput = FindObjectOfType<PlayerInput> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (_playerInput.IsMouseDown ()) 
		{
			_mousePanStartPosition = _playerInput.GetPointerLocation ();
		}

		if (_playerInput.IsMouseHeld ()) 
		{
			Vector3 currentMousePosition = _playerInput.GetPointerLocation ();
			Vector3 mousePanDistance = _mousePanStartPosition - currentMousePosition;
			Vector3 newCameraPosition = _editorCamera.transform.position + mousePanDistance;
			_editorCamera.transform.position = newCameraPosition;
		}
	}

	public Camera _editorCamera;

	private PlayerInput _playerInput;
	private Vector3 _mousePanStartPosition;
}
