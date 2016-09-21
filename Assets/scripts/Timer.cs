using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

	public Color col, defCol;// col-цвет на который будет меняться, defCol-цвет по умолчанию
	public GameObject mCube;
	private Color lastCol; // 

	void Start () {
		lastCol = mCube.GetComponent <Renderer> ().material.color; // lastCol=текущий цвет нашего куба
	}

	void Update () {
		if (!mCube.GetComponent <GameCntrl> ().lose) {
			if (transform.position.x < -8.5f) //если таймер уходит далее 8,5 то уничтожаем, и соответственно возвращаем lose.
				Destroy (gameObject);
			if (transform.position.x < -1.5f)//если доходит до 1.5 то начинаем менять цвет.
				//берем цвет блока GetComponent <Renderer> ().material.color, в который с помощью функции Color.Lerp(меняет из одного цвета в другой)\
				// из GetComponent <Renderer> ().material.color меняем в col, который мы обозначили ранее, за время Time.deltaTime(постепено по фреймам)
				GetComponent <Renderer> ().material.color = Color.Lerp (GetComponent <Renderer> ().material.color, col, Time.deltaTime);
			transform.position -= new Vector3 (0.03f, 0, 0);// двигаем наш блок по Х на 0,03
		}

		if (mCube.GetComponent <Renderer> ().material.color != lastCol) {// если сейчас цвет и цвет который был раньше отличаюятся,
			// значит пользователь нажал правильно и ставим цвет по умолчанию.
			lastCol = mCube.GetComponent <Renderer> ().material.color;
			transform.position = new Vector3 (0, transform.position.y, 0);
			GetComponent <Renderer> ().material.color = defCol;
		}
	}

	void OnDestroy () {
		if (mCube)
			mCube.GetComponent <GameCntrl> ().lose = true;
	}	
}