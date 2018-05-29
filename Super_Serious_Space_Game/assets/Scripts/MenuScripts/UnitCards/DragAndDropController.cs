using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDropController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

    public static GameObject draggedObject;
    public static GameObject originalParent;
    private Vector3 startPosition;
    private Transform startingParent;
    private Transform canvasParent;
    private CanvasGroup canvasGroup;
    private string startingList;

	// Use this for initialization
	void Start () {
        canvasGroup = GetComponent<CanvasGroup>();
	}
	
	// Update is called once per frame
	void Update () {
		
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
        Debug.Log(eventData.pointerCurrentRaycast.gameObject.tag);
        canvasGroup.blocksRaycasts = true;
        if (transform.parent == canvasParent)
        {
            // put card back in original list here
            transform.position = startPosition;
            transform.SetParent(startingParent);            
        }      
    }
}
