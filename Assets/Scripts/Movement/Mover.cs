using UnityEngine;
using UnityEngine.AI;

namespace RPG.Movement
{
    public class Mover : MonoBehaviour
    {

        // Update is called once per frame
        void Update()
        {
            UpdateAnimator();
        }

        //draws the ray
        //Debug.DrawRay(lastRay.origin, lastRay.direction * 100);
        private void MoveToCursor()
        {
            // creates a ray going form the camera to the positon of mouse click.
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            bool hasHit = Physics.Raycast(ray, out RaycastHit hit);

            if (hasHit)
            {
                //set navmesh agent's destionation to target's position.
                MoveTo(hit.point);
            }
        }

        public void MoveTo(Vector3 destination)
        {
            GetComponent<NavMeshAgent>().destination = destination;
        }

        private void UpdateAnimator()
        {
            Vector3 velocity = GetComponent<NavMeshAgent>().velocity;
            Vector3 localVelocity = transform.InverseTransformDirection(velocity);

            float speed = localVelocity.z;
            GetComponent<Animator>().SetFloat("forwardSpeed", speed);

        }
    }
}
