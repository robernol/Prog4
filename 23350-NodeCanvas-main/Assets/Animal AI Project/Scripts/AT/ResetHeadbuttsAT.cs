using NodeCanvas.Framework;
using ParadoxNotion.Design;


namespace NodeCanvas.Tasks.Actions {

	public class ResetHeadbuttsAT : ActionTask {

		public BBParameter<int> headbuttsBB;

        protected override string OnInit() {
			return null;
		}

		protected override void OnExecute() {
			headbuttsBB.value = 0; //resets the amount of headbutts back to zero for the next round of headbutting
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