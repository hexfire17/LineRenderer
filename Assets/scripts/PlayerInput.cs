using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;

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

	public bool IsMouseHeld()
	{
		return Input.GetMouseButton (0) && !IsMouseOverUI ();
	}

	public bool IsMouseOverUI()
	{
		return _eventSystem.IsPointerOverGameObject () || IsTouchOverUI ();
	}

	private bool IsTouchOverUI()
	{
		PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
		eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
		List<RaycastResult> results = new List<RaycastResult>();
		EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
		return results.Count > 0;
	}

	private UIController _UIController;
	private EventSystem _eventSystem;

}
