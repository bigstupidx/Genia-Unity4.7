using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public int health =0;
	private EnemyAI EnemyAIscript;


	// Use this for initialization
	void Start () {
		EnemyAIscript = GetComponent<EnemyAI>();
		}
	
	// Update is called once per frame
	void Update () {
	
	
	}
	void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("pattack"))
		{
			health = health -1;
		}
		if(health ==0 || !EnemyAIscript.enabled)
		{
			EnemyAIscript.enabled = !EnemyAIscript.enabled;
			rigidbody.freezeRotation = true;
		}
	}
}
