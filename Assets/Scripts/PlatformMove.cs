using UnityEngine;
using System.Collections;

public class PlatformMove : MonoBehaviour {
	public float speed = 7f;
	float direction = -1f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {//Функция отвечающая за перемещение
		GetComponent<Rigidbody2D>().velocity = new Vector2 ( speed * direction, GetComponent<Rigidbody2D>().velocity.y);
		transform.localScale = new Vector3 (direction, 1, 1);
	}
	void OnCollisionEnter2D(Collision2D col){//коллизия с объектом
		if (col.gameObject.tag == "wall")//проверка условия коллизии с объектом типа wall
						direction *= -1f;
	}
}
