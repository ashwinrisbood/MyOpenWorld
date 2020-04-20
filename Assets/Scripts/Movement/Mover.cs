using System;
using RPG.Combat;
using RPG.Core;
using UnityEngine;
using UnityEngine.AI;

namespace RPG.Movement
{
    public class Mover : MonoBehaviour
    {

        [SerializeField] Transform target;

        NavMeshAgent navMeshAgent;

        private void Start()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
        }

        // Update is called once per frame
        void Update()
        {
            UpdateAnimator();
        }

        //draws the ray
        //Debug.DrawRay(lastRay.origin, lastRay.direction * 100);
        //private void MoveToCursor()
        //{
        //    // creates a ray going form the camera to the positon of mouse click.
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    bool hasHit = Physics.Raycast(ray, out RaycastHit hit);

        //    if (hasHit)
        //    {
        //        //set navmesh agent's destionation to target's position.
        //        MoveTo(hit.point);
        //    }
        //}
        
        public void StartMoveAction(Vector3 destination)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            GetComponent<Fighter>().Cancel();
            MoveTo(destination);
        }

        public void MoveTo(Vector3 destination)
        {
            navMeshAgent.destination = destination;
            navMeshAgent.isStopped = false;
        }

        private void UpdateAnimator()
        {
            Vector3 velocity = navMeshAgent.velocity;
            Vector3 localVelocity = transform.InverseTransformDirection(velocity);

            float speed = localVelocity.z;
            GetComponent<Animator>().SetFloat("forwardSpeed", speed);

        }

        public void Stop()
        {
            navMeshAgent.isStopped = true;
        }
    }
}
