using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine.UI;


namespace NodeCanvas.Tasks.Actions {

	public class EnergyMeterAT : ActionTask {

		public Image EnergyMeter;
		public BBParameter<float> EnergyBB;

        protected override string OnInit() {
			return null;
		}

		protected override void OnExecute() {
		}

		protected override void OnUpdate() {
			EnergyMeter.fillAmount = EnergyBB.value / 100; //changes the fill amount value of the energy meter based on the current energy value.
        }

		protected override void OnStop() {
			
		}

		protected override void OnPause() {
			
		}
	}
}