using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class TalkAT : ActionTask {

		public BBParameter<GameObject> talker; //the thing that will talk
		AudioSource cry; //the cry of the pokemon

		protected override string OnInit() {
			return null;
        }

		protected override void OnExecute() { //on execute, plays the respective cry of the pokemon, then ends immediately
            cry = talker.value.GetComponent<AudioSource>(); 
            cry.Play();
            EndAction(true);
		}

		protected override void OnUpdate() {
			
		}

		protected override void OnStop() {
			
		}

		protected override void OnPause() {
			
		}
	}
}