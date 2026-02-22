using NodeCanvas.Framework;
using ParadoxNotion.Design;


namespace NodeCanvas.Tasks.Conditions {

	public class HeadbuttCountCT : ConditionTask {

		public BBParameter<int> headbuttCount;
		int headbuttLimit = 3; //when approaching a tree, Rhyhorn may headbutt up to three times.

        protected override string OnInit(){
			return null;
		}

		protected override void OnEnable() {
			
		}

		protected override void OnDisable() {
			
		}

		protected override bool OnCheck() { //checks if three headbutts have been performed. If so, exits the Sub FSM.
			if (headbuttCount.value >= headbuttLimit -1) //not completely sure why but removing the -1 causes Rhyhorn to headbutt 4 times so I didn't question it 
			{
				return false;
            }
			else
			{
				headbuttCount.value++; //only checks after a headbutt, so if the condition fails, will increase the number of headbutts performed
            }
            return true;
		}
	}
}