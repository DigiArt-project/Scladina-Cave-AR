using UnityEngine;
using UnityEngine.UI;

public class AugmentedObjectController : MonoBehaviour
{

    private DefaultTrackableEventHandler trackableEventHandler;
    private Animator animator;

    //Rotation icon
    private static Text rotationText;
    private static Image rotationImage;

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

        //rotation icon
        rotationText = GameObject.FindGameObjectWithTag("RotationText").GetComponent<Text>();
        rotationImage = GameObject.FindGameObjectWithTag("RotationImage").GetComponent<Image>();
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
        EnableUI();
        IncrementXP();

        /*
        var n = GetComponentInParent<Transform>().position - transform.position;
        var newRotation = Quaternion.LookRotation(n) * Quaternion.Euler(0, 90, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 1.0f);*/
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

    public void EnableUI()
    {
        if (trackableEventHandler.trackingEnabled == true)
        {
            rotationText.enabled = true;
            rotationImage.enabled = true;
        }
        else
        {
            rotationText.enabled = false;
            rotationImage.enabled = false;
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
