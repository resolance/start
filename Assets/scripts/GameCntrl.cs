using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Advertisements;// добавление ADS

public class GameCntrl : MonoBehaviour {

	public GameObject pLost;
	public GameObject colBlock;
	public Vector3 [] positions;
	private GameObject block;
	private GameObject [] blocks = new GameObject[4];

	private int rand, count;
	private float rCol, gCol, bCol;
	public Text score;
	private static Color aColor;

	private static int advCount = 0; // переменная для рекламы
	private	bool FuncDone; // вводим переменную для того, чтобы реклама не запускалась каждый раз
	//т.к. реклама появлялась при каждом проигрыше и не убиралась, т.к. Lose dsdj;bnmcz dctulf ghb ghjbuhsit


		[HideInInspector]
	public bool next, lose;

	void Start () {
		if (PlayerPrefs.GetString ("NoAds")!="yes") {
		if (Advertisement.isSupported)  // говорим, если реклама поддерживается, то
			Advertisement.Initialize ("1103537", false); // показываем рекламу с unityADS (gthtl 'nbv cjp;fk ghjtrn b nfv gjkexbk yjvth)
		 else
			Debug.Log ("Platform is not supported");
		}
		count = 0;
//next - булевская переменная, которая означает что мы можем перейти к следующему этапу и добовляет к count+1
		next = false;
		lose = false;
// rand 
		rand = Random.Range (0, positions.Length);// сколько кубиков столько и выбираем рандомное число. от 0 до колличества рандомных кубиков positions.Length
		for (int i = 0; i < positions.Length; i++) {
			//в цикле от 0 до кол-ва кубиков в массиве Blocks(указали в начале). Каждый кубик создаем.
			//colBlock это наш префап, ставим в позицию i, для каждоко вектора это новая, так же ее объявили в начале.identity-по умолчанию.
			blocks [i] = Instantiate (colBlock, positions[i], Quaternion.identity) as GameObject;// все это записываем в массив как GameObject, всего их 4 - объявили в начале.
			if (rand == i) // Если рандомное число равно итерации,для того чтобы взять какой то блок из 4 и стоановаить у него значение тру
				block = blocks [i];
		}
		block.GetComponent <RandCol> ().right = true;
	}

	void Update () {
		if (lose && !FuncDone) // через RightOne меняем на тру, тогда вызывается функция playerLose ()
							// позже добавили FUncDone. Указываем ее просто без данных, 
							//т.к при первом вызове ее значение было Null или false, дальнейшее значение ее будет в 
							// в playerLose
			playerLose ();
		if (next && !lose)
			nextColors ();
	}

	void nextColors () {
		// проверка если звук включен тогда,
		if (PlayerPrefs.GetString ("Music") != "no")
			GetComponent <AudioSource> ().Play (); // здесь Play- это наша сцена



		count++; // увеличиваем коунт на 1
		score.text = count.ToString ();// записываем в переменную public text score. преобразуем как текст toString
		//для обозначения text подключаем using UnityEngine.UI
		aColor = new Vector4 (Random.Range (0.1f, 1f), Random.Range (0.1f, 1f), Random.Range (0.1f, 1f), 1);
		GetComponent <Renderer> ().material.color = aColor;
		next = false;

		if (count < 3) {
			rCol = 0.2f;
			gCol = 0.2f;
			bCol = 0.2f;
		} else if (count >= 3 && count < 5) {
			rCol = 0.1f;
			gCol = 0.1f;
			bCol = 0f;
		} else if (count >= 5) {
			rCol = 0f;
			gCol = 0f;
			bCol = 0.05f;
		}

		// New colors for blocks
		rand = Random.Range (0, positions.Length); //выбираем рандомный блок
		for (int i = 0; i < positions.Length; i++) {
			if (i == rand)// и если итерация равна этому числу, то блок будет такого же цвета как и главный.
				blocks [i].GetComponent <Renderer> ().material.color = aColor;
			else { // далее записываются цвета переменный, чтобы задать цвета для остальных блоков
				float r = aColor.r + Random.Range (0.1f, rCol) > 1f ? 1f : aColor.r + Random.Range (0.1f, rCol);
				// здесь значения должны быть до 1. проверяем (0.1f, rCol) > 1f исли нет, то ставим 1f,если да, то подставляем значениыя aColor.r + Random.Range (0.1f, rCol)
				float g = aColor.g + Random.Range (0.1f, gCol) > 1f ? 1f : aColor.g + Random.Range (0.1f, gCol);
				float b = aColor.b + Random.Range (0.1f, bCol) > 1f ? 1f : aColor.b + Random.Range (0.1f, bCol);
				// ниже меняем цвет для каждого из блоков.
				blocks [i].GetComponent <Renderer> ().material.color = new Vector4 (r, g, b, aColor.a);
			}
		}
	}

	void playerLose () {
				//if (Player.Prefs.GetString ("NoAds") != "yes") {- говорим если пользователь не купил отказ от рекламы,то
		FuncDone = true;
		advCount++;
		if (Advertisement.IsReady () && advCount %5 ==0) // adv загрузилась и при делении на 5==0,т.е каждый 5 проигрыш показывать рекламу
			Advertisement.Show ();
		
				//}


		if (PlayerPrefs.GetInt("Score")< count)
		PlayerPrefs.SetInt ("Score", count);
		pLost.SetActive (true);
		//для того чтобы звук контролировался базово.
		if (PlayerPrefs.GetString ("Music") == "no") // если звук включен, тогда включаем звук объекта pLost
			pLost.GetComponent<AudioSource> ().mute = true;

	}
}