using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {

	void Start()
	{
		_UIController = FindObjectOfType<UIController>();
	}

	public Vector3 GetPointerLocation()
	{
		Vector3 position = _UIController.CurrentCamera ().ScreenToWorldPoint (Input.mousePosition);
		position.z = 0;
		return position;
	}

	public UIController _UIController;
}
