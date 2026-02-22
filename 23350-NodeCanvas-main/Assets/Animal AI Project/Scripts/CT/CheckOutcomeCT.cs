using NodeCanvas.Framework;
using ParadoxNotion.Design;


namespace NodeCanvas.Tasks.Conditions {

	public class CheckOutcomeCT : ConditionTask {

		public int outcome; //The outcome, represented by an int, to check for.
		public BBParameter<int> outcomeBB;

        protected override string OnInit(){
			return null;
		}

		protected override void OnEnable() {
			
		}
		protected override void OnDisable() {
			
		}
		protected override bool OnCheck()
		{
			if (outcomeBB.value == outcome) //if the randomly chosen outcome matches the outcome value, this condition will be successful.
			{
				outcomeBB.value = 0;
                return true;
			}
			else
			{
				return false;
            }
        }
	}
}