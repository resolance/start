using UnityEngine;
using System.Collections;

public class RandCol : MonoBehaviour {
	//является ли этот куб главным, здесь она по умолчанию false,  и 
	public bool main = false, right = false;
	private static Color aColor;
	
	void Awake () {
		if (main)
			// выбрали этот параметр потому что можно задать 4 параметра RGB(цвет)+прозрачность
		aColor = new Vector4 (Random.Range (0.1f, 1f), Random.Range(0.1f, 1f), Random.Range (0.1f, 1f), 1);
	}
	// функция смены цвета при старте один раз
	void Start () {
		if (main || right)
				GetComponent <Renderer> ().material.color = aColor;
		else
			GetComponent <Renderer> ().material.color = new Vector4 (aColor.r + Random.Range (0.1f, 0.3f), aColor.g + Random.Range (0.1f, 0.3f), aColor.b + Random.Range (0.1f, 0.3f), aColor.a);
	
	
	}
}
