using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions {


	public class RestAT : ActionTask {

		public BBParameter<Transform> HeadBB, JawBB, RArmBB, LArmBB, RLegBB, LLegBB; //joints
		public BBParameter<float> energyBB;
		NavMeshAgent navAgent;


        protected override string OnInit() {
			navAgent = agent.GetComponent<NavMeshAgent>();
            return null;
		}


		protected override void OnExecute() { //changes the pose to look like the Rhyhorn is resting (though looks kinda weird with open eyes)
			HeadBB.value.localEulerAngles = new Vector3(HeadBB.value.localEulerAngles.x - 15, HeadBB.value.localEulerAngles.y - 30, HeadBB.value.localEulerAngles.z - 15);
            RArmBB.value.localEulerAngles = new Vector3(RArmBB.value.localEulerAngles.x - 50, RArmBB.value.localEulerAngles.y, RArmBB.value.localEulerAngles.z);
            LArmBB.value.localEulerAngles = new Vector3(LArmBB.value.localEulerAngles.x - 50, LArmBB.value.localEulerAngles.y - 60, LArmBB.value.localEulerAngles.z);
            RLegBB.value.localEulerAngles = new Vector3(RLegBB.value.localEulerAngles.x + 80, RLegBB.value.localEulerAngles.y, RLegBB.value.localEulerAngles.z);
            LLegBB.value.localEulerAngles = new Vector3(LLegBB.value.localEulerAngles.x + 80, LLegBB.value.localEulerAngles.y, LLegBB.value.localEulerAngles.z);
			navAgent.SetDestination(agent.transform.position); //so that the Rhyhorn doesn't try to move while resting
        }

		protected override void OnUpdate() {
			//changing position continuously as it will snap back to normal y value otherwise and look like its floating.
			agent.transform.position = new Vector3(agent.transform.position.x, agent.transform.position.y - 0.181f, agent.transform.position.z); 
			energyBB.value += 10 * Time.deltaTime; //increases energy while resting
			if (energyBB.value >= 100f) //at full energy, will end the action
			{
				energyBB.value = 100f;
				EndAction(true);
            }
        }

		protected override void OnStop() {
			
		}

		protected override void OnPause() {
			
		}
	}
}