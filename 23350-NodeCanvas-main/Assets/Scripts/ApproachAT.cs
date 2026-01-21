using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class ApproachAT : ActionTask {

		public BBParameter<float> speed;
		public BBParameter<Transform> target;

        private Blackboard lighthouseBB;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			//Blackboard agentBlackboard = agent.GetComponent<Blackboard>();
			//speed = agentBlackboard.GetVariableValue<float>("speed");

            //agentBlackboard.SetVariableValue("speed", 0f);


            return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {

		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			//move towards target transform
			Vector3 directionToMove = target.value.position - agent.transform.position;
			agent.transform.position += directionToMove.normalized * speed.value * Time.deltaTime;

			float distanceToTarget = directionToMove.magnitude;
			if(distanceToTarget < 0.5f)
			{
				EndAction(true);

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