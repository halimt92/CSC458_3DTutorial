using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    public float rotationSpeed;
    private Animator playerAnimator;
    // Use this for initialization
    void Start () {
        playerAnimator = GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Update () {
        float mouseX = Input.GetAxis("Mouse X");
        float horzMvt = Input.GetAxis("Horizontal");
        float vertMvt = Input.GetAxis("Vertical");

        transform.Rotate(new Vector3(0, mouseX * rotationSpeed, 0));

        transform.Translate(new Vector3(horzMvt * speed, 0, vertMvt * speed));

        playerAnimator.SetFloat("Vertical Speed", Mathf.Abs(vertMvt*4f));
        playerAnimator.SetFloat("Horizontal Speed", (horzMvt));

    }
}
