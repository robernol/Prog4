using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class SwimmingAT : ActionTask {

		public AnimationCurve swimmingCurve;
		public BBParameter<float> EnergyBB;
        public BBParameter<Transform> HeadBB, LArmBB, LLegBB, RArmBB, RLegBB; //joints

		bool isSwimming;

        protected override string OnInit() {
			return null;
		}

		protected override void OnExecute() {
			isSwimming = false;
        }

		protected override void OnUpdate() {
			if (agent.transform.position.z < 41.5f && agent.transform.position.z > 30f) //if the agent is in the water, plays a "swimming" animation
            {
				isSwimming = true;
				//bobs up and down sligtly following an animation curve.
				agent.transform.position = new Vector3(agent.transform.position.x, agent.transform.position.y + swimmingCurve.Evaluate(Time.time) * 0.2f, agent.transform.position.z);
				
                HeadBB.value.transform.localEulerAngles = new Vector3(-20, 0, 0);
                LArmBB.value.transform.localEulerAngles = new Vector3(0, 0, -30);
                LLegBB.value.transform.localEulerAngles = new Vector3(0, 0, -45);
                RArmBB.value.transform.localEulerAngles = new Vector3(0, 0, 30);
                RLegBB.value.transform.localEulerAngles = new Vector3(0, 0, 45);
				//the legs splay out and the head rises, as if floating in water


            }
			else if (isSwimming){ //if no longer in the water, resets the rotation of the joints then isSwimming is set to false to prevent repeating during other tasks
                HeadBB.value.transform.localEulerAngles = new Vector3(0, 0, 0);
                LArmBB.value.transform.localEulerAngles = new Vector3(0, 0, 0);
                LLegBB.value.transform.localEulerAngles = new Vector3(0, 0, 0);
                RArmBB.value.transform.localEulerAngles = new Vector3(0, 0, 0);
                RLegBB.value.transform.localEulerAngles = new Vector3(0, 0, 0);
				isSwimming = false;
            }            
        }

		protected override void OnStop() {
			
		}

		protected override void OnPause() {
			
		}
	}
}