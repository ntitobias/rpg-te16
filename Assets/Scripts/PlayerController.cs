using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

    public LayerMask movementMask;
    public Interactable focus;

    Camera cam;
    PlayerMotor motor;

	// Use this for initialization
	void Start () {

        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
	}
	
	// Update is called once per frame
	void Update () {

        //Vänster musknapp
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, 100, movementMask))
            {
                //Move our object to what we hit
                Debug.Log("We hit " + hit.collider.name + " " + hit.point);
                motor.MoveToPoint(hit.point);

                //Stop focusing any objects
                RemoveFocus();
            }
        }

        //Höger musknapp
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                //Check if we hit an interactable
                Interactable interactable = hit.collider.GetComponent<Interactable>();

                //If we did set it as our focus.
                if(interactable != null)
                {
                    SetFocus(interactable);
                }
            }
        }
    }

    private void RemoveFocus()
    {
        focus = null;
        motor.StopFollowingTarget();
    }

    void SetFocus(Interactable newFocus)
    {
        focus = newFocus;
        motor.FollowTarget(newFocus);
    }
}
