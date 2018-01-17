using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PresentBox : MonoBehaviour {

    public Slider slider;
    private float maxSliderValue;
    private Animator animator;

	// Use this for initialization
	void Start () {
        animator = this.gameObject.GetComponent<Animator>();
        this.gameObject.GetComponent<Image>().enabled = false;
        animator.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(slider.value >= slider.maxValue)
        {
            this.gameObject.GetComponent<Image>().enabled = true;
            animator.enabled = true;
        }
    }
}
