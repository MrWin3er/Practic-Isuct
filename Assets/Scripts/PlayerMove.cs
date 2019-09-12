using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class PlayerMove : MonoBehaviour {
	public float maxSpeed = 10f;
	public float jumpForce = 700f;
	bool facingRight = true;
	bool grounded = false;
	float score = 0; //очки игрока
	float life = 3; // жизни игрока
	public float spawnX,spawnY; //стартовые позиции
	public Transform groundCheck;
	public float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	public string NEXTLEVEL;
	
	Animator anim;
	
	public int MaxScore = 3; //максимум очков на уровне
	
	public float move;

	public AudioClip WinLevel;
	
	public Text TextLink; //текстовый объект UI для вывода кол-во жизней
	
	public Text TextScore; //текстовый объект UI для вывода кол-во очков
	// Use this for initialization
	void Start () {
		spawnX = transform.position.x; //сохранение стартовых позицииы
		spawnY = transform.position.y;
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		
		//grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);

		move = Input.GetAxis ("Horizontal");

	}

	void Update(){
		if (grounded &&(Input.GetKeyDown (KeyCode.Space)||Input.GetKeyDown (KeyCode.W)||Input.GetKeyDown (KeyCode.UpArrow))) {
			GetComponent<Rigidbody2D>().AddForce (new Vector2(0f,jumpForce));
			grounded = false;
			//проверка условия на наличие поверхности от которой можно отпрыгнуть
		}
		GetComponent<Rigidbody2D>().velocity = new Vector2 (move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
		
		if (move > 0 && !facingRight) //условие отвечающие за переворот персонажа
			Flip ();
		else if (move < 0 && facingRight)
			Flip ();

		if(life == 0) //условие на проигрыш
		{
			Application.LoadLevel (Application.loadedLevel);
		}

		if (Input.GetKey(KeyCode.R)) //рестар уровня
		{
			Application.LoadLevel(Application.loadedLevel);
		}

		if (Input.GetAxis("Horizontal") == 0) { //анимация персонажа
			anim.SetInteger("st", 0);
		} else {
			anim.SetInteger("st", 2);
		}
				
		TextLink.text = "x" + life.ToString();
		TextScore.text = score.ToString()+'/'+MaxScore.ToString();
		
	}
	
	void Flip(){//функция перворота персонажа
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}	
	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "VoidZone"||(col.gameObject.tag == "saw")){//проверка на "враждебные" объекты
						life = life - 1;
						transform.position = new Vector3(spawnX,spawnY,transform.position.z);
						//Application.LoadLevel (Application.loadedLevel);
			}	
		if (col.gameObject.tag == "star") {//проверка коллизии с "шестеренкой" и добавление очков
						score++;
						Destroy (col.gameObject);
				}
		if (col.gameObject.name == "EndLevel") { //проверка коллизии с концом уровня
			if (score == MaxScore) {
				GetComponent<AudioSource>().PlayOneShot(WinLevel); //проигрыш звука конца уровня
				System.Threading.Thread.Sleep(300);
				Application.LoadLevel (NEXTLEVEL); //загрузка следующего уровня
			}
				}
	}
	void OnCollisionEnter2D(Collision2D col)
	{
		grounded = true;
		if(col.gameObject.tag == "enemy")//проверка коллизии с врагом
		{
			//механика убийства врагов как в марио
			if((Math.Abs(col.gameObject.transform.position.y) - Math.Abs(transform.position.y))>0)
			{
				Destroy(col.gameObject);
			}else {
			life = life - 1;
			transform.position = new Vector3(spawnX,spawnY,transform.position.z);
			}
		}
	}
	
	//void OnGUI(){
	//GUI.Box (new Rect (0, 0, 100, 50), "Stars: " + score + '\n' + "Life: " + life);
	//}
		
}