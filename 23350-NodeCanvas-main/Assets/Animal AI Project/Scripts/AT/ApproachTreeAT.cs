using NodeCanvas.Framework;
using ParadoxNotion.Design;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions {

	public class ApproachTreeAT : ActionTask {
		//confusing mess of public variables
		public Transform hTree, h, aTree, a, pTree, p; //the transform of the headbutt point of the given tree and then the transform of the tree itself, repeating
		Transform focalPoint; //the transform of the tree at which the actor will look when he reaches it

        public BBParameter<Transform> HBB, ABB, PBB, CurrentBB; //The berry spawner for each tree, and a variable to store the one corresponding to the current tree
		public BBParameter<GameObject> HeracrossBB, AriadosBB, PinsirBB, CurrentBugBB; //^same but for the big bugs inhabiting the trees

        bool reached;
		public float timer;

		private NavMeshAgent navAgent;

		protected override string OnInit() {
            navAgent = agent.GetComponent<NavMeshAgent>();
            return null;
		}

		protected override void OnExecute() {

			reached = false;
			float hCheck, aCheck, pCheck; //checks for the distance to each tree, and chooses the one which is closest to the agent.
			//Later done much more elegantly in the script that finds the closest friend, but I don't want to mess with this now
			hCheck = (hTree.position - agent.transform.position).magnitude;
            aCheck = (aTree.position - agent.transform.position).magnitude;
            pCheck = (pTree.position - agent.transform.position).magnitude;

            if (hCheck <= aCheck)
			{
				if (hCheck <= pCheck)
				{
					navAgent.SetDestination(hTree.position); //sets destination, focal point, the current berry spawner and the current bug based on closest tree.
					focalPoint = h;
                    CurrentBB.value = HBB.value;
					CurrentBugBB.value = HeracrossBB.value;
                }
				else
				{
					navAgent.SetDestination(pTree.position);
					focalPoint = p;
                    CurrentBB.value = PBB.value;
                    CurrentBugBB.value = PinsirBB.value;
                }
			}
			else
			{
                if (aCheck <= pCheck)
                {
                    navAgent.SetDestination(aTree.position);
					focalPoint = a;
                    CurrentBB.value = ABB.value;
					CurrentBugBB.value = AriadosBB.value;
                }
                else
                {
                    navAgent.SetDestination(pTree.position);
					focalPoint = p;
					CurrentBB.value = PBB.value;
                    CurrentBugBB.value = PinsirBB.value;
                }
            }
        }

		protected override void OnUpdate() {
            if (navAgent.remainingDistance < 0.1f) //when the agent is close enough to the destination, look at the focal point and start the timer to end the action
            {
				agent.transform.LookAt(focalPoint);
				OnDestinationReached();
			}
			if (reached)
			{
				if (Time.time > timer) //ends the action 1 second after reaching the destination.
				{
					EndAction(true);
				}
			}
        }

		protected override void OnStop() {
			
		}

		protected override void OnPause() {
			
		}

        protected void OnDestinationReached() { //sets a 1 second timer after reaching the destination, and makes sure it only happens once (this was before I created the Wait AT)
			if (!reached)
			{
                reached = true;
                timer = Time.time + 1;
            }
		}

    }
}