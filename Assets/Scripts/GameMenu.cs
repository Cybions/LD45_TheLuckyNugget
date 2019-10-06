using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GameMenu : MonoBehaviour
{
    [SerializeField]
    private Transform Rules;
    [SerializeField]
    private AudioSource sound;
    [SerializeField]
    private AudioClip soundClick;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartGame()
    {
        sound.PlayOneShot(soundClick);
        LoadLevel();


    }
    public void OpenMenu()
    {
        sound.PlayOneShot(soundClick);
        Rules.gameObject.SetActive(true);
    }

    public void CloseMenu()
    {
        sound.PlayOneShot(soundClick);
        Rules.gameObject.SetActive(false);
    }
    public void QuitGame()
    {
        sound.PlayOneShot(soundClick);
        quit();
    }
    private void LoadLevel()
    {
        SceneManager.LoadScene("MainGame");
    }
    private void quit()
    {
        Application.Quit();
    }
}
