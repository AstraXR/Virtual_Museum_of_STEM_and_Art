using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    public Transform detectionPoint;
    public LayerMask detectionLayers;
    public float detectionLength;

    public List<InteractionObject> _previousList = new List<InteractionObject>();
    public List<InteractionObject> cols = new List<InteractionObject>();

    public void Update()
    {
        SetInteractables();
        DetectInputs();
    }

    public void SetInteractables()
    {
        cols = Physics.OverlapSphere(detectionPoint.position, detectionLength, detectionLayers)
            .Select(o => o.GetComponent<InteractionObject>())
            .Where(o => o != null)
            .ToList();

        foreach (var interactionObject in _previousList.Except(cols))
        {
            interactionObject.ToggleVisual(false);
        }

        foreach (var interactionObject in cols.Except(_previousList))
        {
            interactionObject.ToggleVisual(true);
        }

        _previousList = cols;
    }


    public void DetectInputs()
    {
        if (!Input.GetKeyDown(KeyCode.E))
            return;

        Interact();
    }

    public void Interact()
    {
        if (cols.Count == 0)
            return;

        cols[0].Interact();
    }
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(detectionPoint.position, detectionLength);
    }
}
