using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCollectibleScript : MonoBehaviour
{
    private player_data data;
	public bool rotate; // do you want it to rotate?

	public float rotationSpeed;

	public GameObject collectEffect;

	// Use this for initialization
	void Start () {
        data = FindObjectOfType<player_data>();
	}
	
	// Update is called once per frame
	void Update () {

		if (rotate)
			transform.Rotate (Vector3.up * rotationSpeed * Time.deltaTime, Space.World);

	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") {
			Collect ();
		}
	}

	public void Collect()
	{
		if(collectEffect)
			Instantiate(collectEffect, transform.position, Quaternion.identity);
        data.coin++;

		Destroy (gameObject);
	}
}
