using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class SpawnAT : ActionTask {

        public GameObject item1, item2, item3, item4, item5; //used for both berries and falling pokemon
        public GameObject[] itemList;
		public BBParameter<Transform> spawnerBB; //loation for the item to be spawned at


        protected override string OnInit() {
            itemList = new GameObject[5] { item1, item2, item3, item4, item5 };
            return null;
		}

		protected override void OnExecute() {
			
        }

		protected override void OnUpdate() {
            GameObject.Instantiate(itemList[Random.Range(0, 5)], spawnerBB.value.position, spawnerBB.value.rotation); //chooses a random item to spawn at the position of the spawner
			EndAction(true);
        }

		protected override void OnStop() {
			
		}

		protected override void OnPause() {
			
		}
	}
}