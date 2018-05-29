using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerCardsDropController : MonoBehaviour{

    public RectTransform contentWindow;
    public GameObject cardSlotPrefab;
    public GameObject draggedCard;

	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // this should create a new empty card slot in the player cards inventory
    // then place the dragged card into the new card slot
    // also need to add that card to the players stored cards list if it is not already there
    public void DragDropCreateNewSlotAddCard()
    {
        draggedCard = DragAndDropController.draggedObject;
        if (draggedCard != null)
        {
            GameObject newCardSlot = Instantiate(cardSlotPrefab, contentWindow.transform.position, Quaternion.identity);
            newCardSlot.transform.SetParent(contentWindow, false);
            draggedCard.transform.SetParent(newCardSlot.transform, false);
            draggedCard.transform.position = newCardSlot.transform.position;
        }
    }
}
