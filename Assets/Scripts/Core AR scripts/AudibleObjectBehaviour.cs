using UnityEngine;


public class AudibleObjectBehaviour : MonoBehaviour {

    private AudioSource audioSource;
    [SerializeField] private AudioClip soundClip;

    private DefaultTrackableEventHandler trackableObject;

    // Use this for initialization
    void Start () {
        trackableObject = GetComponentInParent<DefaultTrackableEventHandler>();

        audioSource = GameObject.FindGameObjectWithTag("AudioSourceAudible").GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (trackableObject.trackingEnabled)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Pause();
        }
	}
}
