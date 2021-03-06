using UnityEngine;
using System.Collections;

public class HealthController : MonoBehaviour {
	
	public float currentHealth = 5;
	public float damageEffectTime = 0.02F;
	public Material damageEffectMat;
	public Material playerMat;
	public static bool damageEffect = false;
	public bool damageRecieved = true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void ApplyDamage(float damage)
	{
		if (currentHealth > 0)
		{
			damageRecieved = true;
			currentHealth -= damage;
			if (transform.position.y > 1.531) {
				currentHealth += damage;
				damageRecieved = false;
			}
			if (currentHealth <= 0)
			{
				currentHealth = 0;
				Highscore.CheckScore();
				RestartScene ();
			}
			else if (damageRecieved)
			{
				StartCoroutine(DamageEffect ());
			}
		}
	}
	
	void RestartScene()
	{
		Scorecounter.ClearScore();
		Application.LoadLevel(0);
	}
	IEnumerator DamageEffect()
	{
		damageEffect = true;
		renderer.material = damageEffectMat;
		yield return new WaitForSeconds(damageEffectTime);
		renderer.material = playerMat;
		yield return new WaitForSeconds(damageEffectTime);
		renderer.material = damageEffectMat;
		yield return new WaitForSeconds(damageEffectTime);
		renderer.material = playerMat;
		yield return new WaitForSeconds(damageEffectTime);
		renderer.material = damageEffectMat;
		yield return new WaitForSeconds(damageEffectTime);
		renderer.material = playerMat;
		yield return new WaitForSeconds(damageEffectTime);
		damageEffect = false;
	}
}
