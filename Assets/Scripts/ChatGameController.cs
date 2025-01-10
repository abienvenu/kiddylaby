using UnityEngine;
using System.Collections;

public class ChatGameController : MonoBehaviour
{
	public GameObject target;
	public GameObject effectBall;
	public Flickering spotLight;

	public void Update()
	{
		effectBall.transform.position = target.transform.position;
		effectBall.transform.rotation = target.transform.rotation;
	}
	
	public void switchTarget(GameObject newTarget)
	{
		target = newTarget;
		spotLight.startFlickering();
	}
}
