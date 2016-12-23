using UnityEngine;

public class LineElement : ITrackElement
{
	public LineElement (Vector3 linePosition, Vector3 localScale, Quaternion rotation)
	{
		_linePosition = linePosition;
		_localScale = localScale;
		_rotation = rotation;
	}

	public void AddToScene()
	{
		_instantiatedObject = GameObject.Instantiate (_penPrefab, _linePosition, _penPrefab.transform.rotation) as GameObject;
		_instantiatedObject.transform.localScale += _localScale;
		_instantiatedObject.transform.rotation = _rotation;
	}

	public void RemoveFromScene()
	{
		if (_instantiatedObject != null) 
		{
			GameObject.Destroy (_instantiatedObject);
		}
	}

	private Vector3 _linePosition;
	private Vector3 _localScale;
	private Quaternion _rotation;

	private GameObject _instantiatedObject;

	private static GameObject _penPrefab = (GameObject) Resources.Load ("Pen");
}

