using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToNode : MonoBehaviour {

    public GameObject myResource;
    public GameObject currentResourceNode;
    public bool isMovingToNode;
    public bool isAtNode;

    private Vector3 myMiningPosition;
    private Vector3 nullPosition;
    private Animator animator;

	// Use this for initialization
	void Start ()
    {
        isMovingToNode = false;
        isAtNode = false;
        nullPosition = new Vector3(0, 0, 0);
        animator = GetComponent<Animator>();
        animator.SetBool("isMining", false);
    }
	
	// Update is called once per frame
	void Update ()
    {
		if (isMovingToNode)
        {
            MoveMinerToNode(myResource);
        }
	}

    public void MoveMinerToNode(GameObject resourceNode)
    {
        Resource resourceScript = resourceNode.GetComponent<Resource>();
        Transform position1 = resourceNode.transform.GetChild(0);
        Transform position2 = resourceNode.transform.GetChild(1);

        // if I already have a selected resource
        if (currentResourceNode != null)
        {
            // and my current resource isnt the same as the new resource
            if (currentResourceNode != resourceNode)
            {
                Resource currentResource = currentResourceNode.GetComponent<Resource>();                

                // then I am leaving the resource and need to free up the position
                if (myMiningPosition == currentResourceNode.transform.GetChild(0).position)
                {
                    currentResource.position1Taken = false;
                }
                if (myMiningPosition == currentResourceNode.transform.GetChild(1).position)
                {
                    currentResource.position2Taken = false;
                }

                // reset mining position and get my new node
                currentResourceNode = resourceNode;
                myMiningPosition = nullPosition;
                isAtNode = false;
                animator.SetBool("isMining", false);
            }
        }
        else
        {
            currentResourceNode = resourceNode;
        }



        // if position 1 isnt taken take it
        if (myMiningPosition == nullPosition)
        {
            if (!resourceScript.position1Taken)
            {
                resourceScript.position1Taken = true;
                myMiningPosition = position1.position;
            }
            else if (!resourceScript.position2Taken)
            {
                resourceScript.position2Taken = true;
                myMiningPosition = position2.position;
            }
            else
            {
                myMiningPosition = nullPosition;
            }
        }

        // if I have a mining position
        if (myMiningPosition != nullPosition)
        {
            float distance = Vector3.Distance(transform.position, myMiningPosition);
            // and I havent reached it yet
            if (distance > 0)
            {
                // then keep moving towards it
                transform.position = Vector3.MoveTowards(transform.position, myMiningPosition, 20f * Time.deltaTime);
            }
            else
            {
                isMovingToNode = false;
                isAtNode = true;
                animator.SetBool("isMining", true);
            }
        }
    }
}
