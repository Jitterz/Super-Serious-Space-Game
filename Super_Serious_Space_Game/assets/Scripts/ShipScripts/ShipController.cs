using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour {
    public float shipSpeed = 10f;
    private Vector3 targetPosition;
    public bool isMoving;

    public ParticleSystem engine1;
    public ParticleSystem engine2;

    public GameObject approachPanel;
    public GameObject shipScanner;

    private PlanetScanner planetScanner;
    private Vector3 mouse_pos;
    private Vector3 object_pos;
    private float angle;

    // Use this for initialization
    void Start ()
    {
        planetScanner = shipScanner.GetComponent<PlanetScanner>();
        targetPosition = transform.position;
        isMoving = false;
        engine1.enableEmission = false;
        engine2.enableEmission = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (planetScanner.isScanning == false)
        {
            if (Input.GetMouseButton(0))
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                // layer 5 is the UI layer
                if (hit.collider == null && approachPanel.activeSelf == false)
                {
                    SetTargetPosition();
                }
            }

            if (isMoving)
            {
                engine1.enableEmission = false;
                MoveShip();
            }
        }
	}

    private void SetTargetPosition()
    {
        targetPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
        targetPosition.z = 0;
        isMoving = true;
    }


    private void MoveShip()
    {
        engine1.enableEmission = true;
        engine2.enableEmission = true;
        var newRotation = Quaternion.LookRotation(transform.position - targetPosition, Vector3.forward);
        newRotation.x = 0.0f;
        newRotation.y = 0.0f;

        transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 8);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, shipSpeed * Time.deltaTime);

        float distance = Vector3.Distance(transform.position, targetPosition);
        if (distance <= 0.5f)
        {
            engine1.enableEmission = false;
            engine2.enableEmission = false;
            isMoving = false;
        }
    }
}
