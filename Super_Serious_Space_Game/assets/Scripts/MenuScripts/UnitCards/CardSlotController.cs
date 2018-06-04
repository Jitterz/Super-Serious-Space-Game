using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardSlotController : MonoBehaviour, IDropHandler {

    public GameObject UnitCard
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
        if (gameObject.transform.childCount == 0)
        {
            if (DragAndDropController.draggedObject != null)
            {
                // if the dragged objects parent isnt this object and this object is not a deck slot then remove it and set the new parent
                if (DragAndDropController.originalParent != gameObject)
                {                    
                    DragAndDropController.draggedObject.transform.SetParent(transform);
                    DragAndDropController.draggedObject.transform.position = transform.position;
                    if (DragAndDropController.originalParent.tag != "DeckSlot")
                    {
                        Destroy(DragAndDropController.originalParent);
                    }
                }
            }
        }      
        else if (gameObject.transform.childCount == 1)
        {
            GameObject destinationCard = gameObject.transform.GetChild(0).gameObject;
            GameObject destinationParent = gameObject;
            GameObject originalCard = DragAndDropController.draggedObject;
            GameObject originalParent = DragAndDropController.originalParent;

            originalCard.transform.SetParent(destinationParent.transform);
            destinationCard.transform.SetParent(originalParent.transform);

            Vector3 tempDestination = new Vector3(destinationParent.transform.position.x, destinationParent.transform.position.y, destinationParent.transform.position.z);
            Vector3 tempOriginal = new Vector3(originalParent.transform.position.x, originalParent.transform.position.y, originalParent.transform.position.z);

            destinationCard.transform.position = tempOriginal;
            originalCard.transform.position = tempDestination;
        }
        
    }
}
