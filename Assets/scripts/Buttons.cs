using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Buttons : MonoBehaviour {

	public GameObject m_on, m_off; //переменные , для отображения разных картинок на звуке.
	public Sprite layer_blue, layer_red;


	void Start () {// при старте проверяем значения при старте.
		if (gameObject.name == "Music") { // кнопка это - Music, то проверяться будет, на других нет.
			if (PlayerPrefs.GetString ("Music") == "no") {
				m_on.SetActive (false); // если выключаем,то устанваливаем включение выключеным
				m_off.SetActive (true);
			} else {
				m_on.SetActive (true); // если выключаем,то устанваливаем включение выключеным
				m_off.SetActive (false);
			}
		}
	}
	void OnMouseDown () {
		GetComponent <SpriteRenderer> ().sprite = layer_red;
	}

	void OnMouseUp () {
		GetComponent <SpriteRenderer> ().sprite = layer_blue;
	}

	void OnMouseUpAsButton () {
		if (PlayerPrefs.GetString ("Music") != "no")
			//находим объкт с названиес ClickAudio и у него берем компонтнт
			GameObject.Find ("ClickAudio").GetComponent <AudioSource> ().Play ();
		switch (gameObject.name) {
		case "Play":
			SceneManager.LoadScene ("play");
			break;
		case "Rating":
			Application.OpenURL ("http://google.com");
			break;
			//Добовляем новый кейс
		case "Reply":
			SceneManager.LoadScene ("play");
			break;
		case "Home":
			SceneManager.LoadScene ("main");
			break;	
		case "Facebook":
			Application.OpenURL ("http://facebook.com");
			break;
		case "Help":
			SceneManager.LoadScene ("HowTo");
			break;	
		case "Close":
			SceneManager.LoadScene ("main");
			break;	
		case "Music": //PlayerPrefs -позволит сохранять статус вкючен или нет звук 
			if (PlayerPrefs.GetString ("Music") != "no") {
				PlayerPrefs.SetString ("Music", "no");
				m_on.SetActive (false); // если выключаем,то устанваливаем включение выключеным
				m_off.SetActive (true);
			} 
			else {
				PlayerPrefs.SetString ("Music", "yes");
				m_on.SetActive (true);
				m_off.SetActive (false);
			}

			break;	
		}
	}
}