using UnityEngine;
using System.Collections;

public class TargetTracker : MonoBehaviour
{
	public GameObject target;
	public float speed;
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		Quaternion neededRotation = Quaternion.LookRotation (target.transform.position - transform.position);
		transform.rotation = Quaternion.Lerp (transform.rotation, neededRotation, Time.deltaTime * speed);
	}
}
