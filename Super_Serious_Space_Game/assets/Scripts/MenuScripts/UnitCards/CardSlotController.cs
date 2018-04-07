using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardSlotController : MonoBehaviour, IDropHandler {

    public GameObject unitCard
    {
        get
        {
            if (transform.childCount > 0)
            {
                return transform.GetChild(0).gameObject;
            }
            return null;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        // if my card slot does not have an item then set the cards parent to the slot
        if (!unitCard)
        {
            if (DragAndDropController.draggedObject != null)
            {
                DragAndDropController.draggedObject.transform.SetParent(transform);
                DragAndDropController.draggedObject.transform.position = transform.position;
            }
        }
    }
}
