﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public LayerMask mask;
    public float rayDistance;
    public float distanceFromPlayer;

    public bool IsInteracting;
    public Transform _Camera;
    
    // Update is called once per frame
    void Update()
    {
        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position, transform.forward, 100.0F);
        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];
            Ray rayInteract = new Ray (transform.position, _Camera.forward);

            if (Physics.Raycast (rayInteract, out hit, rayDistance, mask)) 
            {
                IsInteracting = true;
                IInteractable action = hit.collider.GetComponent<IInteractable>();
                if(hit.collider.tag == "Cube" || hit.collider.tag == "Interactable")
                {
                    if (action == null) return;
                        action.Interact();
                }
                Debug.DrawLine(rayInteract.origin, hit.point, Color.red);
            } else {
                IsInteracting = false;
                Debug.DrawLine(rayInteract.origin, rayInteract.origin + rayInteract.direction * rayDistance, Color.green);
            }
        }
    }
}