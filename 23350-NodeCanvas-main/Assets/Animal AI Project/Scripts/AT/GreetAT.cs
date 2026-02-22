using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions {

	public class GreetAT : ActionTask {

		public GameObject friend1, friend2, friend3, friend4, friend5, friend6; //friends that Rhyhorn can greet.
		GameObject currentFriend;
        GameObject[] friendList;

		public BBParameter<GameObject> CurrentFriendBB;
		NavMeshAgent navAgent;

        protected override string OnInit() {
			navAgent = agent.GetComponent<NavMeshAgent>();
            friendList = new GameObject[6] { friend1, friend2, friend3, friend4, friend5, friend6 };
            return null;
		}

		protected override void OnExecute() {
            currentFriend = friendList[0]; //determines which friend is the closest to the agent's current position.
			for (int i = 1; i < friendList.Length; i++)
			{
				if ((friendList[i].transform.position - agent.transform.position).magnitude < (currentFriend.transform.position - agent.transform.position).magnitude)
				{
					currentFriend = friendList[i];
                }
            }

			CurrentFriendBB.value = currentFriend; //sets the closest friend as the current friend that the Rhyhorn will greet.
			navAgent.SetDestination(currentFriend.transform.position);

		}

		protected override void OnUpdate() {
            if ((currentFriend.transform.position - agent.transform.position).magnitude < 2f) //Rhyhorn will travel until he is within a magnitude of 2 from the friend.
			{
                navAgent.SetDestination(agent.transform.position); //When the rhyhorn is close enough, he will stop moving and look at the friend.
                navAgent.transform.LookAt(currentFriend.transform);
                EndAction(true);
            }
        }

		protected override void OnStop() {
			
		}

		protected override void OnPause() {
			
		}
	}
}