using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMove : MonoBehaviour
{
	[Header("Boat")]
	public Transform boat;
	public Transform iceland;

	public GameObject leverbool;

	public Rigidbody rb;

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (leverbool.activeSelf == true)
		{
			Vector3 destination = new Vector3(iceland.position.x, boat.position.y, iceland.position.z);

			Vector3 pos = Vector3.MoveTowards(boat.position, destination, 15 * Time.deltaTime);

			rb.MovePosition(pos);
		}
	}
}
