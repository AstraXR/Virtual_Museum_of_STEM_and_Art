using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerAction : MonoBehaviour
{
    public UnityEvent InRangeEvent;
    public UnityEvent OutOfRangeEvent;

    private ThirdPersonController controller;

    public float distanceThreshold;
    public bool isCloseEnough;
    public bool IsCloseEnough
    {
        get => isCloseEnough;
        set
        {
            if(value != isCloseEnough)
            {
                isCloseEnough = value;

                if (value == true)
                    InRangeEvent?.Invoke();
                else OutOfRangeEvent?.Invoke();
            }
        }
    }

    private void Awake()
    {
        controller = FindFirstObjectByType<ThirdPersonController>();
    }

    public void Update()
    {
        float distance = Vector3.Distance(transform.position, controller.transform.position);
        IsCloseEnough = distance < distanceThreshold;
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, distanceThreshold);
    }
}
