using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
	public void NewGame() {
		GameControl.Status = GameControl.GAME;
		GameControl.SetMap(Map.FIELD, 0);
		SceneManager.LoadScene(1); // MapScene
	}

	public void LoadGame() {
	}

	public void Config() {
	}

	public void QuitGame() {
		Application.Quit();
	}
}
