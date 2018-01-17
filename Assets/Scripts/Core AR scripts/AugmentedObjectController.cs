using UnityEngine;
using UnityEngine.UI;

public class AugmentedObjectController : MonoBehaviour
{

    private DefaultTrackableEventHandler trackableEventHandler;
    private Animator animator;

    //Rotation icon
    [SerializeField] private GameObject rotationIcon;
    private Image rotationImage;
    private Text rotationText;

    //experience bar
    private Slider xpBar;
    private int xp = 1;

    [SerializeField] private AudioClip XPClip;
    private SoundManager soundManager;



    void Start()
    {
        trackableEventHandler = GetComponentInParent<DefaultTrackableEventHandler>();

        animator = gameObject.GetComponent<Animator>();
        animator.enabled = false;

        //slider
        xpBar = GameObject.FindGameObjectWithTag("xpBar").GetComponent<Slider>();

        //sound manager
        soundManager = GameObject.FindGameObjectWithTag("AudioSource").GetComponent<SoundManager>();

        //set the screen to be rotated on phone automaticaly (portrait or landscape)
        Screen.orientation = ScreenOrientation.AutoRotation;
    }

    // Update is called once per frame
    void Update()
    {
        ControlAugmentedObjectAnimation();
        IncrementXP();
    }

    public void ControlAugmentedObjectAnimation()
    {
        //stops animation when tracking is lost, and resumes when found again.
        if (trackableEventHandler.trackingEnabled == true)
        {
            animator.enabled = true;
        }
        else if (trackableEventHandler.trackingEnabled == false)
        {
            animator.enabled = false;
        }
    }

    public void IncrementXP()
    {
        if (trackableEventHandler.trackingEnabled == true && xp == 1)
        {
            xpBar.value += 1;
            xp++;
            soundManager.PlayXPSound(XPClip);
        }
    }
}
