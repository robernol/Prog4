using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class EatAT : ActionTask {

		public BBParameter<GameObject> BerryBB;
		public BBParameter<List<GameObject>> BerryListBB;
        public BBParameter<Transform> HeadBB, JawBB;
		public BBParameter<float> EnergyBB;
        float timer;

		public AnimationCurve eatCurve;

        protected override string OnInit() {
			return null;
		}

		protected override void OnExecute() {
			agent.transform.LookAt(BerryBB.value.transform); //when the agent begins eating, looks at the berry
            timer = Time.time + 3f; //will eat for 3 seconds
        }

		protected override void OnUpdate() {
			HeadBB.value.localEulerAngles = new Vector3(eatCurve.Evaluate (timer - Time.time) * 10, 0, 0); //head bobs up and down while eating
			JawBB.value.localEulerAngles = new Vector3(eatCurve.Evaluate(timer - Time.time) * 20, 0, 0); //jaw SHOULD open and close while eating, doesn't for some reason I didn't feel like investigating
            if (Time.time > timer)
			{
				for (int i = 0; i < BerryListBB.value.Count; i++) //goes through the berry list to find where the current berry is
				{
					if (null != BerryListBB.value[i]) //check if it is null first to avoid errors
                    {
                        if (BerryListBB.value[i] == BerryBB.value) //if it finds the berry in the list, removes it and breaks out of the loop
                        {
                            BerryListBB.value.RemoveAt(i);
                            break;
                        }
                    }
					
                }
				
                EndAction(true);
            }
        }

		protected override void OnStop() {
            EnergyBB.value += 10; //when the berry has been eaten, replenishes 10 energy
        }

		protected override void OnPause() {
			
		}
	}
}