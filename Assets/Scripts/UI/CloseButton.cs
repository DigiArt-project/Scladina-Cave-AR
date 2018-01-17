using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseButton : MonoBehaviour {

    public GameObject infoPanel;

    private void OnMouseDown()
    {
        infoPanel.SetActive(false);
    }


}
