using UnityEngine;
using UnityEngine.UI;

public class MapScene : MonoBehaviour {
	public const int GROUND  = 0;
	public const int BARRIER = 1;
	public const int TRIGGER = 2;

	public GameObject[] Bases;

	private Sprite[] SS;

	void Awake() {
		Map map = GameControl.GetMap();
		SS = new Sprite[map.Resources.Length];
		for (int i = 0; i < map.Resources.Length; ++i)
			SS[i] = ResourceManager.Load(map.Resources[i]);
		int[,] mapr = map.GetMap();
		int[,] mapt = map.GetTypeMap();
		for (int i = 0; i < map.Width; ++i) {
			for (int j = 0; j < map.Height; ++j) {
				GameObject go = Instantiate(Bases[mapt[i, j]], new Vector3(i, j, j), Quaternion.identity);
				go.GetComponent<SpriteRenderer>().sprite = SS[mapr[i, j]];
			}
		}
		for (int i = -1; i < map.Width + 1; ++i) {
			GameObject go = Instantiate(Bases[BARRIER], new Vector3(i, -1, -1), Quaternion.identity);
			go.GetComponent<SpriteRenderer>().sprite = SS[0];
			go = Instantiate(Bases[BARRIER], new Vector3(i, map.Height, map.Height), Quaternion.identity);
			go.GetComponent<SpriteRenderer>().sprite = SS[0];
		}
		for (int j = 0; j < map.Height; ++j) {
			GameObject go = Instantiate(Bases[1], new Vector3(-1, j, j), Quaternion.identity);
			go.GetComponent<SpriteRenderer>().sprite = SS[0];
			go = Instantiate(Bases[BARRIER], new Vector3(map.Width, j, j), Quaternion.identity);
			go.GetComponent<SpriteRenderer>().sprite = SS[0];
		}
	}

	void OnDestroy() {
		for (int i = 0; i < SS.Length; ++i)
			Destroy(SS[i]);
	}
}
