using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/*
    CONCEPT
    The character get a nugget  DONE
    The character will buy a pickaxe w/ that nugget DONE
    By Clicking on the mine, the player is able to generate gold (depending on the pickaxe) DONE
    After a certain amount of gold, the player is able to :
    - Buy a pub : Bring constant amount of gold + recruits ? DONE x2
    - Upgrade pickaxe : Increase the mining rewards DONE
    - What about a ultimate pickaxe to unlock the end screen ? DONE
    - the number of upgrades will depend of the amount of time that I will have lel
    - What about an indicator about the reward per click ? DONE

    - Create a song
    - More Sound Design
    - Sound system
    - Prepare Itch.io 
    - Prepare Github
    - Build that shit



*/
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Pickaxe CurrentPickaxe;
    public float playerGold = 0;

    public int ClickAmount = 0;
    public int EmployeeAmount = 0;
    public float CumulativeGain = 0;

    public bool isGameRunning = true;
    [SerializeField]
    private EndScreen escreen;
    [SerializeField]
    private Transform Interface;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    public void ChangeAmountOfGold(float amount)
    {
        playerGold -= amount;
        MenuManager.Instance.Goldpopup(ExtremeValueResolver.Instance.GetValueResolved(amount), false);
    }

    public void EearnGold(float amount)
    {
        playerGold += amount;
        CumulativeGain += amount;
        MenuManager.Instance.Goldpopup(ExtremeValueResolver.Instance.GetValueResolved(amount), true);
    }

    public void EearnGoldWithoutAnim(float amount)
    {
        playerGold += amount;
        CumulativeGain += amount;
    }

    public void LootTheNugget()
    {
        CameraManager.Instance.ChangeCameraSpot();
        EearnGold(25);
    }

    public void BuyTheFirstPickAxe()
    {
        CameraManager.Instance.ChangeCameraSpot();
    }

    public void EndGame()
    {
        isGameRunning = false;
        Interface.gameObject.SetActive(false);
        escreen.StartEndScreen();
    }

    public void QuitGame()
    {
        print("quitting");
        Application.Quit();
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

   

}
