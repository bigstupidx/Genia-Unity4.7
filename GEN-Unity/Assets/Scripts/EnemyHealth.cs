using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public int health =0;
	private EnemyAI EnemyAIscript;
	public GameObject deadbouy;


	// Use this for initialization
	void Start () {
		EnemyAIscript = GetComponent<EnemyAI>();
		}
	
	// Update is called once per frame
	void Update () {
	
	
	}

	void OnTriggerEnter(Collider wave)

	{
		if(wave.collider.name == "bigwave(Clone)")
		{
			health = health -3;
		}
	}
	void OnCollisionEnter(Collision other)
	{
		if(other.collider.name == "Playerbody")
		{
			health = health -1;
		}

		if(other.collider.tag == "pattack")
		{
			health = health -1;
		}

		if(health <=0 && EnemyAIscript.enabled)
		{
			GameMaster.respawncounter++;
			DeadEnemyCounter.enemiesdead++;
			EnemyAIscript.enabled = !EnemyAIscript.enabled;
			Instantiate(deadbouy,transform.position,transform.rotation);
			rigidbody.freezeRotation = true;
			Destroy(this.gameObject);
		}
	}
}
