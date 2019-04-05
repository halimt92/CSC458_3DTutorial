using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting: MonoBehaviour {

    public GameObject arrow;
    public GameObject RightHand;
    private bool draw, recoil;
    private Animator playerAnimator;
    private GameObject tempArrow;
    private Vector3 mousePos;
    // Use this for initialization
    void Start () {
        playerAnimator = GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Update () {

        mousePos = Input.mousePosition;
        mousePos.z = transform.position.z +5;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        if (Input.GetMouseButtonDown(0)&& !draw)
        {
            playerAnimator.SetBool("Draw", true);
            playerAnimator.SetBool("Recoil", false);
            tempArrow= GameObject.Instantiate(arrow, RightHand.transform);
            draw = true;
            recoil = false;
        }

        if (Input.GetMouseButtonUp(0) && draw)
        {
            playerAnimator.SetBool("Recoil", true);
            playerAnimator.SetBool("Draw", false);
            tempArrow.GetComponent<Rigidbody>().useGravity = true;

            tempArrow.transform.LookAt(mousePos);
            tempArrow.GetComponent<Rigidbody>().AddForce(tempArrow.transform.forward*50, ForceMode.Impulse);
            tempArrow.transform.SetParent(null);
            recoil = true;
            draw = false;
        }

    }
}
