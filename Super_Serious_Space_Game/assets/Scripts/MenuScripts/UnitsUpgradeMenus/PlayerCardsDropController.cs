using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerCardsDropController : MonoBehaviour{

    public RectTransform contentWindow;
    public GameObject cardSlotPrefab;
    

    // Use this for initialization
    void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void CreateNewSlotAddCard()
    {
        if (DragAndDropController.draggedObject != null)
        {
            GameObject newCardSlot = Instantiate(cardSlotPrefab, contentWindow.transform.position, Quaternion.identity);
            newCardSlot.transform.SetParent(contentWindow, false);            
            DragAndDropController.draggedObject.transform.SetParent(newCardSlot.transform, false);
            DragAndDropController.draggedObject.transform.position = newCardSlot.transform.position;
            if (DragAndDropController.originalParent.tag != "DeckSlot")
            {
                Destroy(DragAndDropController.originalParent);
            }
        }
    }   
}
