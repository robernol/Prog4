using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions {

	public class ForageAT : ActionTask {

		public BBParameter<GameObject> BerryBB; //(Usually) The closest berry to the agent.
		NavMeshAgent navAgent;

        protected override string OnInit() {
			navAgent = agent.GetComponent<NavMeshAgent>();
            return null;
		}

		protected override void OnExecute() {
			navAgent.SetDestination(BerryBB.value.transform.position); //agent will walk over to the berry.
        }

		protected override void OnUpdate() {
			if (navAgent.remainingDistance <= 0.5f) //when close enough to the berry, stops the agent.
			{
				navAgent.SetDestination(agent.transform.position);
                EndAction(true);
            }
        }

		protected override void OnStop() {
			
		}

		protected override void OnPause() {
			
		}
	}
}