using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class WaitAT : ActionTask {

		float timer;
		bool ended;
		public float interval; //the amound of time to wait before the next action is executed. Can be changed in the inspector

        protected override string OnInit() {
			return null;
		}

		protected override void OnExecute() {
			timer = Time.time + interval;
			ended = false;
        }

		protected override void OnUpdate()
		{
			if (timer < Time.time) //when the elapsed time is up, the action will end.
			{
				ended = true;
			}
			if (ended) //this variable is probably a redundancy as it is a holdover from when I forgot about actions running in sequence vs parallel, but I don't want to mess with it just in case
			{
				EndAction(true);
			}
		}

		protected override void OnStop() {
			
		}

		protected override void OnPause() {
			
		}
	}
}