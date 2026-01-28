using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions {

	public class ScoutAT : ActionTask {

        public NavMeshAgent navAgent;
        public Vector3 targetPosition;
		bool scouted;
		float timer;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			targetPosition = new Vector3(Random.Range(-3f, 3f), 0, Random.Range(-3f, 3f)) + agent.transform.position;
            navAgent.SetDestination( targetPosition );
			scouted = false;
			timer = Time.time + 10f;
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate()
		{
			if (Time.time > timer)
			{
				EndAction(true);
			}
			else
			{
				if ((Mathf.Abs(targetPosition.x - agent.transform.position.x) < 0.5) && (Mathf.Abs(targetPosition.y - agent.transform.position.y) < 0.5)){
					scouted = true;
					EndAction(true);
                }
			}
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}