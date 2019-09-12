using UnityEngine;
using System.Collections;

//Скрипт Передвижения Врага

public class EnemyWalk : MonoBehaviour {
	public float speed = 7f;
	float direction = 1.5f;
	void Start () {
	
	}
	void OnCollisionEnter2D(Collision2D col){ //Функция вызывается при коллизи
		if (col.gameObject.tag == "wall") //проверка коллизи с объектом тип wall
						direction *= -1f; //Переворачивает Врага
	}
	void Update () { //Функция вызывается при обновление кадра, отвечает за перемещение
		GetComponent<Rigidbody2D>().velocity = new Vector2 ( speed * direction, GetComponent<Rigidbody2D>().velocity.y);
		transform.localScale = new Vector3 (direction, 1.5f, 1);
	}
}