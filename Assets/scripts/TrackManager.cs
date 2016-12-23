using UnityEngine;
using System.Collections.Generic;

public class TrackManager : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		_trackElements = new LinkedList<ITrackElement> ();
		_nodePtr = null;
	}

	public void AddTrackElement(ITrackElement element)
	{
		LinkedListNode<ITrackElement> newNode = new LinkedListNode<ITrackElement> (element);

		if (_nodePtr == null) 
		{
			_trackElements.AddFirst (newNode);
		}
		else
		{
			//_trackElements.AddAfter (_nodePtr, newNode);
			_trackElements.AddLast (newNode);
		}

		_nodePtr = newNode;
		element.AddToScene ();
	}

	public void Backward()
	{
		if (_nodePtr == null)
		{
			return;
		}
			
		ITrackElement previousTrackElement = _nodePtr.Value;
		previousTrackElement.RemoveFromScene ();

		_nodePtr = _nodePtr.Previous;
	}

	public void Forward()
	{
		if (_trackElements.First == null)
		{
			return;
		}

		LinkedListNode<ITrackElement> nextNode = null;
		if (_nodePtr == null)
		{
			nextNode = _trackElements.First;
		}
		else 
		{
			nextNode = _nodePtr.Next;
		}

		if (nextNode != null) 
		{
			nextNode.Value.AddToScene ();
			_nodePtr = nextNode;
		}
	}
		
	private LinkedList<ITrackElement> _trackElements;
	private LinkedListNode<ITrackElement> _nodePtr;
}
