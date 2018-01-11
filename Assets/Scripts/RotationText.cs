using UnityEngine;
using UnityEngine.UI;

public class RotationText : MonoBehaviour {

    public DefaultTrackableEventHandler oldScientist;
    public DefaultTrackableEventHandler testPit;

    [SerializeField] private Image rotationIcon;

    // Use this for initialization
    void Start () {
        gameObject.GetComponent<Text>().enabled = false;
        rotationIcon.enabled = false;

        //screen orientantion for mobile
        Screen.orientation = ScreenOrientation.AutoRotation;
    }

    // Update is called once per frame
    void Update () {
		if(oldScientist.trackingEnabled || testPit.trackingEnabled)
        {
            gameObject.GetComponent<Text>().enabled = true;
            rotationIcon.enabled = true;

        }
        else
        {
            gameObject.GetComponent<Text>().enabled = false;
            rotationIcon.enabled = false;
        }
    }
}
