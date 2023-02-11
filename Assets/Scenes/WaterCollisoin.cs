using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCollisoin : MonoBehaviour
{
    public GameObject player;
    public GameObject deathScene;

    // Start is called before the first frame update
    void Start()
    {
        deathScene.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject == player)
        {
            deathScene.SetActive(true);
        } else if (collision.gameObject != player)
        {
            deathScene.SetActive(false);
        }
	}
}
