using UnityEngine;
using System.Collections;

public class HitController : MonoBehaviour
{
	public float soundLevel;

	void OnCollisionEnter(Collision collision)
	{
		GetComponent<AudioSource>().volume = Mathf.Clamp (Mathf.Pow(collision.relativeVelocity.magnitude, 2) / 1000 * soundLevel, 0, 1);
		GetComponent<AudioSource>().Play ();
	}
}
