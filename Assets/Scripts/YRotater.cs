using UnityEngine;
using System.Collections;

public class YRotater : MonoBehaviour
{

	public float maxSpeed;
	public Color color1;
	public Color color2;

	private float speed = 0;

	void FixedUpdate()
	{
		speed += Random.Range(-maxSpeed/10, maxSpeed/10);
		speed = Mathf.Clamp (speed, -maxSpeed, maxSpeed);
		transform.Rotate(Vector3.up * speed * Time.deltaTime, Space.World);

		float t = Mathf.PingPong (Time.time, 1);
		GetComponent<Light>().color = Color.Lerp (color1, color2, t);
	}	
}
