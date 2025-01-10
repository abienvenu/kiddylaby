using UnityEngine;
using System.Collections;

public class Flickering : MonoBehaviour
{
	public float minFlickerSpeed = 0.01f;
	public float maxFlickerSpeed = 0.1f;
	public float intensityOverload = 2;
	public float flickerDuration = 3;
	private float initialIntensity;

	void Start()
	{
		initialIntensity = GetComponent<Light>().intensity;
		startFlickering();
	}

	public void startFlickering()
	{
		StartCoroutine(flicker());
	}

	IEnumerator flicker()
	{
		float flickeringStart = Time.time;
		while (Time.time < flickeringStart + flickerDuration)
		{
			GetComponent<Light>().intensity = initialIntensity * Random.Range (0, intensityOverload);
			yield return new WaitForSeconds(Random.Range (minFlickerSpeed, maxFlickerSpeed));
		}
		GetComponent<Light>().intensity = initialIntensity;
	}
}
