using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipAbilityButtonController : MonoBehaviour {

    public List<GameObject> shipSpecialButtonPrefabs;
    private GameObject myShipSpecialPrefab;

    // Use this for initialization
    void Start()
    {
        BuildAndPlaceShipSpecialPrefabButton();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void BuildAndPlaceShipSpecialPrefabButton()
    {
        if (PlayerInfoStatic.CurrentShipSpecialAbility == "Turret")
        {
            myShipSpecialPrefab = shipSpecialButtonPrefabs[0];
            GameObject myUnitButton = Instantiate(myShipSpecialPrefab, transform.position, Quaternion.identity);
            myUnitButton.transform.SetParent(gameObject.transform, false);
            myUnitButton.transform.position = gameObject.transform.position;
        }
    }
}
