
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions
{

    public class RunAT : ActionTask //basically exactly the same as wander but with a different end condition, "animation", and speed.
    {

        public float wanderRadius;
        public float wanderCircleDistance;

        float timer;

        private NavMeshAgent navAgent;
        public BBParameter<Transform> JawBB, HeadBB;


        protected override string OnInit()
        {
            navAgent = agent.GetComponent<NavMeshAgent>();
            return null;
        }

        protected override void OnExecute()
        {
            agent.transform.eulerAngles = new Vector3(0, agent.transform.eulerAngles.y + 180, 0);
            SetDestination();
            navAgent.speed *= 5; //5 times as fast while running
            timer = Time.time + 5; //runs for 5 seconds
            //head is made to look like Rhyhorn is yelling in fear
            JawBB.value.eulerAngles = new Vector3(JawBB.value.eulerAngles.x + 20, JawBB.value.eulerAngles.y, JawBB.value.eulerAngles.z);
            HeadBB.value.eulerAngles = new Vector3(HeadBB.value.eulerAngles.x -45, HeadBB.value.eulerAngles.y, HeadBB.value.eulerAngles.z);
            agent.GetComponent<AudioSource>().Play();
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

            if (timer < Time.time) //no specific condition, exits after 5 seconds
            {
                EndAction(true);
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
