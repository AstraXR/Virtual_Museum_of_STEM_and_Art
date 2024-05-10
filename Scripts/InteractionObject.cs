using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class InteractionObject : MonoBehaviour
{
	public UnityEvent OnInteractionOn;
	public UnityEvent OnInteractionOff;
	public GameObject toggleSelectVisual;
	public bool interactionState = false;

	public void ToggleVisual(bool state)
	{
		toggleSelectVisual.SetActive(state);
	}

	[ContextMenu("Interact")]
	public void Interact()
	{
		interactionState = !interactionState;
		UpdateState();

	}

	public void UpdateState()
	{
		if (interactionState)
			OnInteractionOn.Invoke();
		else
			OnInteractionOff.Invoke();
	}

}
