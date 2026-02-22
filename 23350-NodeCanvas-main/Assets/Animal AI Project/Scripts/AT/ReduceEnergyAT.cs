using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class ReduceEnergyAT : ActionTask {

		public BBParameter<float> EnergyBB;

        protected override string OnInit() {
			return null;
		}

		protected override void OnExecute() {
		}

		protected override void OnUpdate() {
			EnergyBB.value -= Time.deltaTime; //rduces energy at a constant rate. 
			if (EnergyBB.value <= 0f)
			{
				EnergyBB.value = 0f; //prevents energy from going negative.
            }
        }

		protected override void OnStop() {
			
		}

		protected override void OnPause() {
			
		}
	}
}