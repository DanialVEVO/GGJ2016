using UnityEngine;
using System.Collections;

public class UiHider : MonoBehaviour {

	public GameObject mainmenu;
	public GameObject mobile;
	public GameObject tutorial;

	void MainMenuActive () {
		mainmenu.SetActive (true);
		mobile.SetActive (true);
		tutorial.SetActive (false);
	}

	void TutorialActive () {
		mainmenu.SetActive (false);
		mobile.SetActive (false);
		tutorial.SetActive (true);	
	}
}