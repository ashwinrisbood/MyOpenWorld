using UnityEngine;

namespace RPG.Core
{
    public class ActionScheduler : MonoBehaviour
    {
        MonoBehaviour currentAction;

        public ActionScheduler()
        {
            currentAction = null;
        }

        public void StartAction(MonoBehaviour action)
        {
            if(currentAction != null)
            {
                Debug.Log("cancelling action" + currentAction);
            }

            Debug.Log("starting action");
        }
    }
}
