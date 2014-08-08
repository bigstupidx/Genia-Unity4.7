using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public float health =0;
	private EnemyAI EnemyAIscript;
	public GameObject deadbouy;
	private Vector3 deadbouylocation;
	public GameObject enemydeathps;

	//check if hit wall then don't add to score
	private bool hitwall = false;

	//creator script reference
	private GameMaster createnemy;

	//Colors for enemy
	public Color eredmat;
	public Color ebluemat;

	// Use this for initialization
	void Start () {

		createnemy = GameObject.Find("Game controller").GetComponent<GameMaster>();

		deadbouylocation = new Vector3(0,-5,0);

		EnemyAIscript = GetComponent<EnemyAI>();
		}
	
	// Update is called once per frame
	void Update () {
	
		renderer.materials[0].color = Color.Lerp(ebluemat, eredmat, health / 5f);

		if(health <=0)
		{
			//GameMaster.respawncounter++;
			//	print(GameMaster.respawncounter);
			createnemy.Creator();
			if(!hitwall){
			DeadEnemyCounter.enemiesdead++;
			}
			EnemyAIscript.enabled = !EnemyAIscript.enabled;
			Instantiate(deadbouy,transform.position,transform.rotation);
			Instantiate(enemydeathps,transform.position,transform.rotation);
			rigidbody.freezeRotation = true;
			Destroy(this.gameObject);
		}
	}

	void OnTriggerEnter(Collider wave)

	{
		if(wave.collider.name == "bigwave(Clone)")
		{
			health = health / 2;
		}

//		if(health <=0 && EnemyAIscript.enabled)
//		{
//			GameMaster.respawncounter++;
//			DeadEnemyCounter.enemiesdead++;
//			EnemyAIscript.enabled = !EnemyAIscript.enabled;
//			Instantiate(deadbouy,transform.position,transform.rotation);
//			rigidbody.freezeRotation = true;
//			Destroy(this.gameObject);
//		}
	}
	void OnCollisionEnter(Collision other)
	{
		if(other.collider.name == "Playerbody")
		{
			health = health -1;
		}

		if(other.collider.name =="outerwalls")
		{
			health = 0;
			hitwall = true;
		}

		if(other.collider.tag == "pattack")
		{
			health = health -1;
		}
	
	}
}
