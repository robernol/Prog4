using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class ScanAT : ActionTask { //repurposed from the in class example
		public Color scanColour;
		public int numberOfScanCirclePoints;
		public LayerMask targetMask;
		public float scanRadius = 3f;
        public float scanSpeed = 1f;
		public float baseRadius = 3f;
		public BBParameter<GameObject> Berry;
		public BBParameter<List<GameObject>> BerryList;

        protected override string OnInit() {
			return null;
		}

		protected override void OnExecute() {
			scanRadius = baseRadius;
		}

		protected override void OnUpdate() { //no longer increases range, instead scans continuously at a set range
            DrawCircle(agent.transform.position, scanRadius, scanColour, numberOfScanCirclePoints);

			Collider[] objectsInRange = Physics.OverlapSphere(agent.transform.position, scanRadius, targetMask);

            foreach (Collider objectInRange in objectsInRange) //upon finding a berry within range
            {
				if (BerryList.value.Contains(objectInRange.gameObject)) //only adds each berry to the list once, if it is already in the list it is ignored
                {
					continue;
                }
				else {
                    Berry.value = objectInRange.gameObject; //sets the current berry to the one found
                    BerryList.value.Add(objectInRange.gameObject); //adds to the list of found berries
                }
					
            }

        }

		private void DrawCircle(Vector3 center, float radius, Color colour, int numberOfPoints)
		{
			Vector3 startPoint, endPoint;
			int anglePerPoint = 360 / numberOfPoints;
			for (int i = 1; i <= numberOfPoints; i++)
			{
				startPoint = new Vector3(Mathf.Cos(Mathf.Deg2Rad * anglePerPoint * (i-1)), 0, Mathf.Sin(Mathf.Deg2Rad * anglePerPoint * (i-1)));
				startPoint = center + startPoint * radius;
				endPoint = new Vector3(Mathf.Cos(Mathf.Deg2Rad * anglePerPoint * i), 0, Mathf.Sin(Mathf.Deg2Rad * anglePerPoint * i));
				endPoint = center + endPoint * radius;
				Debug.DrawLine(startPoint, endPoint, colour);
			}

			
		}

		protected override void OnStop() {
			
		}

		protected override void OnPause() {
			
		}
	}
}