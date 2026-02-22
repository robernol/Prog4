using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class HeadbuttAT : ActionTask {

		public AnimationCurve headbutt;
		float timer;
		Vector3 startPos, startRot;

		protected override string OnInit() {
			return null;
		}

		protected override void OnExecute() {
			timer = Time.time + 1; //headbutt lasts for 1 second.
            startPos = agent.transform.position;
			startRot = agent.transform.eulerAngles;
        }

		protected override void OnUpdate() {
			Vector3 headbuttPos = startPos + agent.transform.forward * headbutt.Evaluate(1 - (timer - Time.time)); //performs a headbutt by moving agent forward following the animation curve.
            agent.transform.position = headbuttPos;
			agent.transform.eulerAngles = startRot;
            if (timer < Time.time)
			{
				agent.transform.position = startPos; //puts the agent back to its original position and rotation after the headbutt is done.
                agent.transform.eulerAngles = startRot;
                EndAction(true);
            }
        }

		protected override void OnStop() {
			
		}

		protected override void OnPause() {
			
		}
	}
}