using UnityEngine;

public class SoundManager : MonoBehaviour {

    private AudioSource audioSource;

	// Use this for initialization
	void Awake () {
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
	}

    public void PlayXPSound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    } 

}
