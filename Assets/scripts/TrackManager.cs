using UnityEngine;
using System.Collections.Generic;

public class TrackManager : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		_liveTrackElements = new Stack<ITrackElement> ();
		_revertedTrackElements = new Stack<ITrackElement> ();
	}

	public void AddTrackElement(ITrackElement element)
	{
		element.AddToScene ();
		_liveTrackElements.Push (element);
	}


	
	Stack<ITrackElement> _liveTrackElements;
	Stack<ITrackElement> _revertedTrackElements;
}
