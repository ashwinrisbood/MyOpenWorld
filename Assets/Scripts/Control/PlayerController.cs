using UnityEngine;
using RPG.Movement;
using System;
using RPG.Combat;

namespace RPG.Control
{
    public class PlayerController : MonoBehaviour
    {

        private void Update()
        {
            if (!InteractWithCombat())
            {
                InteractWithMovement();
            }
        }

        private bool InteractWithCombat()
        {
            RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());
            foreach(RaycastHit hit in hits)
            {
                if(hit.transform.GetComponent<CombatTarget>() != null)
                {
                    if (Input.GetMouseButtonDown(1))
                    {
                        GetComponent<Fighter>().Attack();
                    }
                    return true;
                }
            }
            return false;
        }

        private void InteractWithMovement()
        {
            if (Input.GetMouseButtonDown(1))
            {
                MoveToCursor();
            }
        }

        //draws the ray
        //Debug.DrawRay(lastRay.origin, lastRay.direction * 100);
        private void MoveToCursor()
        {
            bool hasHit = Physics.Raycast(GetMouseRay(), out RaycastHit hit);

            if (hasHit)
            {
                GetComponent<Mover>().MoveTo(hit.point);
                //set navmesh agent's destionation to target's position.
            }
        }

        private static Ray GetMouseRay()
        {
            // creates a ray going form the camera to the positon of mouse click.
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    }
}
