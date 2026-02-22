using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions {

	public class FindBerryCT : ConditionTask {

		public BBParameter<List<GameObject>> BerryList;
		public BBParameter<GameObject> Berry;

        protected override string OnInit(){
			return null;
		}

		protected override void OnEnable() {
			
		}

		protected override void OnDisable() {
			
		}

		protected override bool OnCheck()
		{
			for (int i = 0; i < BerryList.value.Count; i++) //checks the berry list blackboard variable. Checks if any of the items in the list are within a magnitude of 5 from the agent. 
			{
				if ((BerryList.value[i].transform.position - agent.transform.position).magnitude < 5)
				{
					Berry.value = BerryList.value[i]; //sets the first item that matches the conditions in the blackboard for future reference
                    return true;
				}
            }
			return false;
        }
	}
}