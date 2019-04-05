using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform finalposTransform;
    private Vector3 finalpos;
    private Vector3 initialpos;
    private float rate=0.5f;
    private bool positionChanged, firstChange=true;
	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
		
        if(Input.GetKeyDown(KeyCode.Q))
        {
            if (!positionChanged)
            {
                if(firstChange)
                {
                    initialpos = transform.position;
                    finalpos = finalposTransform.position;
                    firstChange = false;
                }
                StartCoroutine(ChangePosition(initialpos, finalpos));
                positionChanged = true;
                Vector3 temp = finalpos;
                finalpos = initialpos;
                initialpos = temp;
            }
        }

	}

    IEnumerator ChangePosition(Vector3 initial, Vector3 final)
    {
        float timeElapsed = 0;

        while (timeElapsed*rate<1)
        {
            timeElapsed += Time.deltaTime;
            transform.position = Vector3.Slerp(initial, final,timeElapsed*rate);
            yield return null;
        }
        positionChanged = false;

    }


}
