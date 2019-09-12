using UnityEngine;
using System.Collections;
//скрипт на вращение пилы
public class SawScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3(0f,0f,-1f));
	}
}