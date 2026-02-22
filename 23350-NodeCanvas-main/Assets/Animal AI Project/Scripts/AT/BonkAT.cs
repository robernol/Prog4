using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class BonkAT : ActionTask {

		float timer;
		public BBParameter<Transform> LArmBB, RArmBB, LLegBB, RLegBB;

        protected override string OnInit() {
			return null;
		}

		protected override void OnExecute() {
			timer = Time.time + 2; //the agent will remain stunned for 2 seconds after being bonked.

        }

        protected override void OnUpdate() { //flips the agent upside down with legs splayed to indicate they have been bonked in a cartoony fashion.
            agent.transform.eulerAngles = new Vector3(0, agent.transform.eulerAngles.y, 180);
            agent.transform.position = new Vector3(agent.transform.position.x, agent.transform.position.y + .5f, agent.transform.position.z);
            LArmBB.value.transform.localEulerAngles = new Vector3(0, 0, -45);
            LLegBB.value.transform.localEulerAngles = new Vector3(0, 0, -45);
            RArmBB.value.transform.localEulerAngles = new Vector3(0, 0, 45);
            RLegBB.value.transform.localEulerAngles = new Vector3(0, 0, 45);
            if (timer < Time.time)
			{
				EndAction(true);
            }
        }

		protected override void OnStop() { //goes back to normal
            LArmBB.value.transform.localEulerAngles = new Vector3(0, 0, 0);
            LLegBB.value.transform.localEulerAngles = new Vector3(0, 0, 0);
            RArmBB.value.transform.localEulerAngles = new Vector3(0, 0, 0);
            RLegBB.value.transform.localEulerAngles = new Vector3(0, 0, 0);

        }

		protected override void OnPause() {
			
		}
	}
}