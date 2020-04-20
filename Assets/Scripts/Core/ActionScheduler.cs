using UnityEngine;

namespace RPG.Core
{
    public class ActionScheduler : MonoBehaviour
    {
        IAction currentAction;

        public ActionScheduler()
        {
            currentAction = null;
        }

        public void StartAction(IAction action)
        {
            if (currentAction == action) return;
            if(currentAction != null)
            {
                Debug.Log(currentAction.ToString() + "cancelled");
                currentAction.Cancel();
            }
            currentAction = action;
            Debug.Log("starting action");
        }
    }
}
