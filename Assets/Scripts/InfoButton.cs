using UnityEngine;

public class InfoButton : MonoBehaviour {

    public GameObject infoPanel;

	// Use this for initialization
	void Start () {
        infoPanel.SetActive(false);
	}

    private void OnMouseDown()
    {
        infoPanel.SetActive(true);
    }
}
