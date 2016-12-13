using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour 
{
	void Start () 
	{
		mOffset = transform.position - mPlayer.transform.position;
	}

	// LateUpdate is called after Update each frame
	void LateUpdate () 
	{
		transform.position = mPlayer.transform.position + mOffset;
	}

	public GameObject mPlayer;
	private Vector3 mOffset;
}