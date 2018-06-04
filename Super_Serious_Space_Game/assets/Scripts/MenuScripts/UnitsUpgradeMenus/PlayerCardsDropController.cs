using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerCardsDropController : MonoBehaviour{

    public RectTransform contentWindow;
    public GameObject cardSlotPrefab;
    private float step;

    // Use this for initialization
    void Start ()
    {
        step = 5 * Time.deltaTime;
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
            StartCoroutine(SmoothMovement(DragAndDropController.draggedObject.transform, newCardSlot.transform));
            DragAndDropController.draggedObject.transform.SetParent(newCardSlot.transform, false);           
            //DragAndDropController.draggedObject.transform.position = Vector3.Lerp(Input.mousePosition, newCardSlot.transform.position, step);
            if (DragAndDropController.originalParent.tag != "DeckSlot")
            {
                Destroy(DragAndDropController.originalParent);
            }
        }
    }

    IEnumerator SmoothMovement(Transform start, Transform target)
    {
        while (Vector3.Distance(start.position, target.position) > 0.05f)
        {
            start.transform.position = Vector3.Lerp(start.transform.position, target.transform.position, step);
            yield return null;
        }

        yield return new WaitForSeconds(0.1f);
    }
}
