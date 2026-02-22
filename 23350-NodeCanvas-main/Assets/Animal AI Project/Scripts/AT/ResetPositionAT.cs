using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class ResetPositionAT : ActionTask {

        public BBParameter<Transform> HeadBB, JawBB, RArmBB, LArmBB, RLegBB, LLegBB;

        protected override string OnInit() {
		
			return null;
		}

		protected override void OnExecute() { //sets all joints back to how they started, and resets everything but y rotation of the agent.

            HeadBB.value.localEulerAngles = new Vector3(0, 0 , 0);
            JawBB.value.localEulerAngles = new Vector3(0, 0, 0);
            RArmBB.value.localEulerAngles = new Vector3(0, 0, 0);
            LArmBB.value.localEulerAngles = new Vector3(0, 0, 0);
            RLegBB.value.localEulerAngles = new Vector3(0, 0, 0);
            LLegBB.value.localEulerAngles = new Vector3(0, 0, 0);

            Vector3 temp = agent.transform.eulerAngles;
			temp.x = 0;
			temp.z = 0;
			agent.transform.eulerAngles = temp;
			agent.transform.position = new Vector3(agent.transform.position.x, 0.081f, agent.transform.position.z); //would be ideal, but doesn't really happen due to how the navmesh bakes
            EndAction(true);
		}

		protected override void OnUpdate() {
			
		}

		protected override void OnStop() {
			
		}

		protected override void OnPause() {
			
		}
	}
}