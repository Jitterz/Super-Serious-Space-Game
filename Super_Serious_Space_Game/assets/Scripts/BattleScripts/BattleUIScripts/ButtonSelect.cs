using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSelect : MonoBehaviour
{

    public Image attackSelected;
    public Image defendSelected;
    public Image fallBackSelected;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetAttackSelected()
    {
        attackSelected.enabled = true;
        defendSelected.enabled = false;
        fallBackSelected.enabled = false;
    }

    public void SetDefendSelected()
    {
        attackSelected.enabled = false;
        defendSelected.enabled = true;
        fallBackSelected.enabled = false;
    }

    public void SetFallBackSelected()
    {
        attackSelected.enabled = false;
        defendSelected.enabled = false;
        fallBackSelected.enabled = true;
    }
}
