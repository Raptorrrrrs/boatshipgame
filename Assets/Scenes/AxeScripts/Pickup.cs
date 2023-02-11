using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [Header("Pick up")]
    public float range = 1f;
    public Camera cam;
    public TextMeshProUGUI textMeshPro;

    public RaycastHit hit;

    [Header("Box")]
    public Animator animator;

    [Header("Axe")]
    public GameObject axeprefab;
    public GameObject axe;

	[Header("T-Lever")]
	public Animator leveranimator;

    public GameObject leverbool;

    [Header("player")]
    public Animator playerAnimator;

    [Header("door")]
    public Animator dooranimator;
    public GameObject glassDoor;

	// Start is called before the first frame update
	void Start()
    {
        axe.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {

            if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Highlight"))
            {
                textMeshPro.text = "Object: " + hit.transform.gameObject.name;
            }

            if (hit.transform.gameObject.layer == LayerMask.NameToLayer("whatisground"))
            {
                textMeshPro.text = "";
            }

            if (hit.transform.gameObject.name == "Box" && Input.GetKey(KeyCode.E))
            {
                animator.Play("open");

                playerAnimator.Play("Gathering");

                StartCoroutine(seconds());
            }

            if (hit.transform.gameObject.name == "t-lever" && Input.GetKey(KeyCode.E))
            {
                leveranimator.Play("t-leverOpen");

                leverbool.SetActive(true);
            }

            if (hit.transform.gameObject == glassDoor && Input.GetKey(KeyCode.E))
            {
				dooranimator.Play("open");
            }

        } else
        {
            textMeshPro.text = "";
        }

    }

    IEnumerator seconds()
    {
        yield return new WaitForSeconds(1);

		axe.SetActive(true);
		axeprefab.SetActive(false);
	}
}
