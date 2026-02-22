
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions
{

    public class WanderAT : ActionTask //Repurposed from the in class example
    {

        public float wanderRadius, wanderCircleDistance;
        public BBParameter<int> randomActionBB;

        private NavMeshAgent navAgent;
        float timer, interval;

        protected override string OnInit()
        {
            navAgent = agent.GetComponent<NavMeshAgent>();
            interval = 0.005f;
            return null;
        }

        protected override void OnExecute()
        {
            navAgent.speed = 1.5f;
            SetDestination();
        }

        private void SetDestination()
        {
            Vector3 circleCenter = agent.transform.position + agent.transform.forward * wanderCircleDistance;
            Vector3 randomPoint = Random.insideUnitCircle.normalized * wanderRadius;
            Vector3 destination = circleCenter + new Vector3(randomPoint.x, agent.transform.position.y, randomPoint.y);

            VisualizeWander(circleCenter, destination, 5f);

            NavMeshHit hit;
            if (NavMesh.SamplePosition(destination, out hit, 10f, NavMesh.AllAreas))
            {
                navAgent.SetDestination(hit.position);
            }
        }

        private void VisualizeWander(Vector3 currentCircleCenter, Vector3 currentDestination, float pathUpdateFrequency)
        {
            Debug.DrawLine(agent.transform.position, currentCircleCenter, Color.red, pathUpdateFrequency);
            for (int i = 0; i < 360; i += 12)
            {
                Vector3 p1 = new Vector3(Mathf.Cos(i * Mathf.Deg2Rad), 0f, Mathf.Sin(i * Mathf.Deg2Rad)) * wanderRadius;
                Vector3 p2 = new Vector3(Mathf.Cos((i + 12) * Mathf.Deg2Rad), 0f, Mathf.Sin((i + 12) * Mathf.Deg2Rad)) * wanderRadius;

                Debug.DrawLine(currentCircleCenter + p1, currentCircleCenter + p2, Color.cyan, pathUpdateFrequency);
            }

            Debug.DrawLine(agent.transform.position, currentDestination, Color.magenta, pathUpdateFrequency);
        }

        protected override void OnUpdate()
        {
            if (navAgent.remainingDistance < 0.25f &&
                !navAgent.pathPending)
            {
                SetDestination();
            }

            if (Time.time > timer || Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)) 
            {
                int randomChance = Random.Range(0, 5000); //every 0.02 seconds, there is a 1/5000 chance of Rhyhorn wanting to headbutt a tree, and a 2/5000 chance of him wanting to greet a friend.
                if (Input.GetMouseButtonDown(0)) //if the player left clicks, rhyhorn will want to greet a friend.
                {
                    randomChance = 2;
                }
                if (Input.GetMouseButtonDown(1)) //if the player right clicks, rhyhorn will want to headbutt a tree.
                {
                    randomChance = 1;
                }
                if (randomChance == 1) //if a 1 is rolled, he will headbutt a tree.
                {
                    randomActionBB.value = 1; //represents the chosen action
                    EndAction(true);
                }
                else if (randomChance == 2 || randomChance == 3) //if a 2 or 3 is rolled, he will greet a friend.
                {
                    randomActionBB.value = 2;
                    EndAction(true);
                }
                timer = Time.time + interval; //resets timer
            }
        }

        protected override void OnStop()
        {

        }

        protected override void OnPause()
        {

        }
    }
}

