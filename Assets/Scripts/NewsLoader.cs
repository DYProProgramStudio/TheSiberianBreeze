using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NewsLoader : MonoBehaviour {
	private static WWW request = null;

	IEnumerator Start () {
		if (request == null) {
			request = new WWW("https://github.com/DYProProgramStudio/TheSiberianBreeze/raw/master/Assets/Scripts/Menu.cs");
			// WWW request = new WWW("https://raw.githubusercontent.com/DYProProgramStudio/TheSiberianBreeze/master/Assets/Scripts/Menu.cs");
			yield return request;
		}
		if (!string.IsNullOrEmpty(request.error)) {
			GetComponent<Text>().text = request.error;
		} else {
			GetComponent<Text>().text = request.text;
		}
	}
}
