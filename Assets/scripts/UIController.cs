using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIController : MonoBehaviour {

	void Awake ()
	{
		SetCurrentCamera(_riderCamera);
		SetCurrentUI (_riderUI);
	}

	public Camera CurrentCamera()
	{
		return _currentCamera;
	}

	public void SetCurrentCamera(Camera camera)
	{
		_riderCamera.enabled = false;
		_editorCamera.enabled = false;

		_currentCamera = camera;
		_currentCamera.enabled = true;
		print ("Invoke: " + camera.name);
	}

	public void SetCurrentUI(Canvas canvas)
	{
		_riderUI.enabled = false;
		_editorUI.enabled = false;

		canvas.enabled = true;
	}

	public void EnterPanMode()
	{
		FindObjectOfType<Artist> ().enabled = false;
		FindObjectOfType<EditorCameraController> ().enabled = true;
	}

	public void EnterDrawMode()
	{
		FindObjectOfType<Artist> ().enabled = true;
		FindObjectOfType<EditorCameraController> ().enabled = false;
	}

	public Camera _riderCamera;
	public Camera _editorCamera;

	public Canvas _riderUI;
	public Canvas _editorUI;

	private Camera _currentCamera;
}
