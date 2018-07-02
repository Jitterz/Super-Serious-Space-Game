using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public float speed;
    public float cameraLeftClamp = -280;
    public float cameraRightClamp = 1010;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (transform.position.x > cameraLeftClamp)
            {
                transform.position += (Vector3.left * speed) * Time.deltaTime;
            }
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (transform.position.x < cameraRightClamp)
            {
                transform.position += (Vector3.right * speed) * Time.deltaTime;
            }
        }
    }
}
