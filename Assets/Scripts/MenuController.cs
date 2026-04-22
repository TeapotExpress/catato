using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] TMP_Text version;
    [SerializeField] private GameObject creditsSplash;
    private bool creditsScreenOn = false;

    //Buttons Hovered

    public void Start()
    {
        version.text = "Version: " + Application.version;
        creditsSplash.GetComponent<Animator>().Update(0.90f);
        //Cursor.SetCursor(null, Vector2.zero, CursorMode.ForceSoftware);
    }

    public void ButtonHover()
    {
        SFXManager.instance.PlaySFX("ButtonHover", transform);
    }    

    //Buttons Pressed
    public void StartButtonPressed()
    {
        SceneManager.LoadScene(1);
    }
    
    public void CredditsButtonPressed()
    {
        if (!creditsScreenOn)
        {
            creditsScreenOn = true;
            creditsSplash.GetComponent<Animator>().SetTrigger("Credits On");
            SFXManager.instance.PlaySFX("CreditsSweep", transform);
        }
        else
        {
            creditsScreenOn = false;
            creditsSplash.GetComponent<Animator>().SetTrigger("Credits Off");
            SFXManager.instance.PlaySFXReverse("CreditsSweep", transform);
        }
    }

    public void ExitButtonPressed()
    {
        Application.Quit();
        if (Application.isEditor && Application.isPlaying)
        {
            Debug.Log("Exit function called in editor - I would exit on application");
        }
    }
}
