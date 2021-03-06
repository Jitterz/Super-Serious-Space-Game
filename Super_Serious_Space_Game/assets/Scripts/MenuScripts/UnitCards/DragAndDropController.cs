﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDropController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

    public static GameObject draggedObject;
    public static GameObject originalParent;
    private Transform canvasParent;
    private Vector3 startPosition;
    private Transform startingParent;
    private CanvasGroup canvasGroup;

    // Use this for initialization
    void Start ()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }
	
	// Update is called once per frame
	void Update ()
    {
       
	}

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = transform.parent.gameObject;
        startingParent = transform.parent;
        canvasParent = GameObject.Find("CanvasMenu").transform;
        transform.SetParent(canvasParent);
        draggedObject = gameObject;
        startPosition = transform.position;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        draggedObject = null;
        canvasGroup.blocksRaycasts = true;
        if (transform.parent == canvasParent)
        {
            transform.position = startPosition;
            transform.SetParent(startingParent);
        }
    }        
}
