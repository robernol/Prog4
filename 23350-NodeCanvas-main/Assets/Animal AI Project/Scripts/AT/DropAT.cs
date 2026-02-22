using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class DropAT : ActionTask {

		public BBParameter<GameObject> bugBB;
		DropDown drop; //the monobehaviour script on the bugs that allow them to drop down from the tree

        protected override string OnInit() {
			return null;
		}

		protected override void OnExecute() {
			bugBB.value.GetComponent<AudioSource>().Play(); //plays the cry of the bug as it drops

            drop = bugBB.value.GetComponent<DropDown>();
			drop.dropped = true; //sets the dropped variable to true and sets the timer in the corresponding script.
			drop.timer = Time.time + 1;
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