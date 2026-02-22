using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class HeadbuttOutcomeAT : ActionTask {

		public int outcome;
		public BBParameter<int> outcomeBB;

        protected override string OnInit() {
			return null;
		}

		protected override void OnExecute() { //Happens after Rhyhorn has headbutted a tree.
			float gen = Random.Range(0, 10);
			if (gen >= 9) // 1/10 chance that the big bug inhabiting the tree will drop down and scare Rhyhorn.
			{
				outcome = 3;
			}
            else if (gen >= 6) // 3/10 chance a small pokemon inhabiting the tree will fall and bonk Rhyhorn on the head.
			{
				outcome = 2;
			}
			else // 6/10 chance that a tasty berry will drop for Rhyhorn to eat.
			{
				outcome = 1;
			}
			outcomeBB.value = outcome; // 1 = berry, 2 = bonk, 3 = bug drop. Set for future use
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