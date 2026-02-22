using NodeCanvas.Framework;
using ParadoxNotion.Design;
using Unity.VisualScripting;


namespace NodeCanvas.Tasks.Conditions {

	public class TiredCT : ConditionTask {

		public BBParameter<float> energyBB;

        protected override string OnInit(){
			return null;
		}

		protected override void OnEnable() {
			
		}

		protected override void OnDisable() {
			
		}

		protected override bool OnCheck() { //when energy has reached zero, Rhyhorn must take a nap to replenish it.
            //if rhyhorn is within this z value, he is in the water. Since we don't want him to drown (and it looks weird), he will wait until he is back on land to nap.
            if (energyBB.value <= 0.1f && !(agent.transform.position.z < 41.5f && agent.transform.position.z > 30f)) 
			{
				return true;
            }
            return false;
		}
	}
}