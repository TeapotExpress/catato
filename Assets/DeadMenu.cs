using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadMenu : MonoBehaviour
{

    [SerializeField] GameObject scoreField;
    [SerializeField] CatExp catExp;
    [SerializeField] GameObject hiscoreField;



    // Start is called before the first frame update
    public void ButtonHover()
    {
        SFXManager.instance.PlaySFX("ButtonHover", transform);
    }

    private void Awake()
    {
        int hiScore = hiScore = PlayerPrefs.GetInt("hiscore");
        scoreField.GetComponent<TMP_Text>().text = "Score: " + catExp.overallExp;
        if (catExp.overallExp > hiScore)
        {
            hiScore = catExp.overallExp;
            PlayerPrefs.SetInt("hiscore", hiScore);
            hiscoreField.GetComponent<TMP_Text>().text = "New HighScore!!!: " + hiScore;
            hiscoreField.GetComponent<TMP_Text>().color = Color.yellow;
        }
        hiscoreField.GetComponent<TMP_Text>().text = "HighScore: " + hiScore;


    }

    //Buttons Pressed
    public void RestartButtonPressed()
    {
        SceneManager.LoadScene(1);
    }

    public void MenuButtonPressed()
    {
        SceneManager.LoadScene(0);
    }
}
