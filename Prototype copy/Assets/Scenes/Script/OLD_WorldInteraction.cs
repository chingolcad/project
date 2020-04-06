using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent (typeof (NavMeshAgent))]
public class WorldInteraction : MonoBehaviour
{
    NavMeshAgent playerAgent;
    private Camera _Camera;

    void Start()
    {
        playerAgent = GetComponent<NavMeshAgent>();
        _Camera = FindObjectOfType<Camera>();
    }

    public void MovetoPoint(Vector3 point)
    {
        playerAgent.SetDestination(point);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            GetInteraction();
        }
    }

    void GetInteraction()
    {
        Ray interactionRay = _Camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit interactionInfo;
        if (Physics.Raycast(interactionRay, out interactionInfo, Mathf.Infinity))
        {
            GameObject interactedObject = interactionInfo.collider.gameObject;
            if (interactedObject.tag == "Interactable Object")
            {
                interactedObject.GetComponent<Interactable>().MoveToInteraction(playerAgent);

            }
            else
            {
                playerAgent.destination = interactionInfo.point;
            }
        }
    }
}

