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
		GameObject line = GameObject.Instantiate (_penPrefab, _linePosition, _penPrefab.transform.rotation) as GameObject;
		line.transform.localScale = _localScale;
		line.transform.rotation = _rotation;
	}

	private Vector3 _linePosition;
	private Vector3 _localScale;
	private Quaternion _rotation;

	private static GameObject _penPrefab = (GameObject) Resources.Load ("Pen");
}

