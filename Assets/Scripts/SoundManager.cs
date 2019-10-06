using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource musicShop;
    [SerializeField]
    private AudioSource musicTavern;
    private bool isTransitionning = false;
    [SerializeField]
    private GameObject shopgo;
    [SerializeField]
    private GameObject taverngo;
    [SerializeField]
    private AudioSource minesource;
    [SerializeField]
    private AudioClip minesound;
    [SerializeField]
    private AudioSource EndSource;
    [SerializeField]
    private Slider volumeparam;
    Tweener twtavern;
    Tweener twshop;

    private float globalvolume = 1;

    public enum States
    {
        Global,
        Shop,
        Tavern,
        notSet
    }

    private States CurrentState = States.notSet;
    private bool isMuted = false;


    // Start is called before the first frame update
    void Start()
    {
        PlayTransition(States.Global);
    }

    public void ToggleMute()
    {
        isMuted = !isMuted;
        twshop.Kill();
        twtavern.Kill();
        if (isMuted)
        {
            musicShop.Pause();
            musicTavern.Pause();
            musicShop.volume = 0;
            musicTavern.volume = 0;
            minesource.volume = 0;
            CurrentState = States.notSet;
        }
        else
        {
            minesource.volume = 0.2f * globalvolume;
            musicShop.UnPause();
            musicTavern.UnPause();
        }
    }

    private void Update()
    {
        DifineState();
    }

    private void DifineState()
    {
        if (isTransitionning || isMuted) { return; }
        if (shopgo.active)
        {
            PlayTransition(States.Shop);
        }
        else if (taverngo.active)
        {
            PlayTransition(States.Tavern);
        }
        else
        {
            PlayTransition(States.Global);
        }
    }

    public void PlayTransition(States newState)
    {
        if(newState == CurrentState || isTransitionning || isMuted) { return; }
        if(newState == States.Shop) {
            twshop = musicShop.DOFade(1 * globalvolume, 3f);
            twtavern = musicTavern.DOFade(0.15f * globalvolume, 3f);
        }
        else if(newState == States.Tavern) {
            twshop = musicShop.DOFade(0, 3f);
            twtavern = musicTavern.DOFade(1 * globalvolume, 3f);
        }
        else {
            twshop = musicShop.DOFade(1 * globalvolume, 3f);
            twtavern = musicTavern.DOFade(1 * globalvolume, 3f);
        }
    }

    public void PlayMineSound()
    {
        minesource.PlayOneShot(minesound);
    }

    public void PlayEndSong()
    {
        musicShop.Pause();
        musicTavern.Pause();
        musicShop.volume = 0;
        musicTavern.volume = 0;
        minesource.volume = 0;
        CurrentState = States.notSet;
        EndSource.Play();
        EndSource.DOFade(1 * globalvolume, .5f);
    }

    public void ChangeGlobalVolume()
    {
        globalvolume = volumeparam.value;
        musicShop.volume = musicShop.volume * globalvolume;
        musicTavern.volume = musicTavern.volume * globalvolume;
        minesource.volume = minesource.volume * globalvolume;
    }

}
