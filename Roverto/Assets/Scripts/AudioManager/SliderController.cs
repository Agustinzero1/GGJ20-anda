using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour {
    private Slider mainSlider;
    private AudioManager audioManager;
    public bool mainSound;
    // Use this for initialization
    void Start () {
        mainSlider = GetComponent<Slider>();
        mainSlider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
        audioManager = FindObjectOfType<AudioManager>();
        if (mainSound)
        {
            mainSlider.value = FindObjectOfType<AudioManager>().GetMusicVolume();
        }
        else
        {
            mainSlider.value = FindObjectOfType<AudioManager>().GetFxVolume();
        }
    }
 
    // Update is called once per frame
    void Update () {
		
	}

    public void ValueChangeCheck()
    {
        if (mainSound)
        {
            audioManager.AdjustMainVolumeMusic(mainSlider.value);
        }
        else
        {
            audioManager.AdjustMainVolumeFx(mainSlider.value);
        }
    }
}
