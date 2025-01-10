using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public string horizontalInput;
	public string verticalInput;
	public float sensitivity;
	public AudioSource rollAudio;
	public AudioSource hitPlayerAudio;
	public ChatGameController gameController;
	public bool isTarget = false;

	void Update()
	{
		float minVelocity = 0.2f;
		float velocity = GetComponent<Rigidbody>().linearVelocity.magnitude;
		if (velocity > minVelocity && GetComponent<Rigidbody>().position.y <= 2.5)
		{
			rollAudio.pitch = Mathf.Clamp (0.8f + velocity / 30, 0.8f, 1.4f);
			rollAudio.volume = Mathf.Clamp (velocity * velocity / 1000, 0.0f, 1.0f);
			if (!rollAudio.isPlaying)
			{
				rollAudio.Play ();
			}
		}
		else if (rollAudio.isPlaying)
		{
			rollAudio.Stop();
		}
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			hitPlayerAudio.volume = Mathf.Clamp (Mathf.Pow (collision.relativeVelocity.magnitude, 2) / 2000, 0, 1);
			hitPlayerAudio.Play ();
			isTarget = !isTarget;
			if (isTarget)
			{
				gameController.switchTarget(gameObject);
			}
		}
	}

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis(horizontalInput);
		float moveVertical = Input.GetAxis(verticalInput);

		Vector3 movement = new Vector3 (moveHorizontal, 0, moveVertical);
		// rigidbody.velocity = movement * sensitivity;
		GetComponent<Rigidbody>().AddForce(movement * sensitivity * Time.deltaTime);
	}
}
