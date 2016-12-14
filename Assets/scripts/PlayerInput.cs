using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class PlayerInput : MonoBehaviour {

	void Start()
	{
		_UIController = FindObjectOfType<UIController>();
		_eventSystem = FindObjectOfType<EventSystem> ();
	}

	public Vector3 GetPointerLocation()
	{
		Vector3 position = _UIController.CurrentCamera ().ScreenToWorldPoint (Input.mousePosition);
		position.z = 0;
		return position;
	}

	public bool IsMouseDown()
	{
		return Input.GetMouseButtonDown (0) && !IsMouseOverUI ();
	}

	public bool IsMouseUp()
	{
		return Input.GetMouseButtonUp (0) && !IsMouseOverUI ();
	}

	public bool IsMouseOverUI()
	{
		return _eventSystem.IsPointerOverGameObject ();
	}

	private UIController _UIController;
	private EventSystem _eventSystem;

}
