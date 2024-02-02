using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using AudioSource = UnityEngine.AudioSource;

public class UIManager : MonoBehaviour
{
[SerializeField] private Button _nextButton,_previousButton,_infosButton,_playMusicButton;
[SerializeField] private ARTrackedImageManager _trackedObject;
private AudioSource _audioSource;
private Transform _obj;
private Transform _popUpCanvas;
private bool _popUpDisplayed;
private bool _musicPlaying;

    // Start is called before the first frame update
    void Start()
    {
        _nextButton.onClick.AddListener(() => NextButton(1));
        _previousButton.onClick.AddListener(()=>NextButton(-1));
        _infosButton.onClick.AddListener(DisplayInfo);
        _playMusicButton.onClick.AddListener(PlayMusic);
        _obj = _trackedObject.trackedImagePrefab.transform.GetChild(0);
        _popUpCanvas = _obj.GetChild(0);
        _audioSource = _obj.GetChild(1).GetComponent<AudioSource>();
        _popUpDisplayed = false;
        _musicPlaying = false;
    }

    private void NextButton(int i)
    { 
        _obj = _trackedObject.trackedImagePrefab.transform.GetChild(0);
        _obj.Rotate(new Vector3(0,15*i,0));
    }
    private void DisplayInfo()
    {
        if(_popUpDisplayed)
        {
            _popUpCanvas.GetChild(0).gameObject.SetActive(false);
            _popUpDisplayed = false;
        }
        else
        {
            _popUpCanvas.GetChild(0).gameObject.SetActive(true);
            _popUpDisplayed = true;
        }
        Debug.Log("DisplayInfo");
    }
    private void PlayMusic()
    {
        if(_musicPlaying)
        {
            _audioSource.Pause();
            _popUpDisplayed = false;
        }
        else
        {
            _audioSource.Play();
            _popUpDisplayed = true;
        }
        Debug.Log("PlayMusic");
    }   
}
