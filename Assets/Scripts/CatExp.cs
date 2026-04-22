using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class CatExp : MonoBehaviour
{
    public int experience=0;
    public float expNeeded=5f;
    public int overallExp = 0;
    public static CatExp instance;

    public Image progress;

    public float hp = 1;
    public float dmg = 1;
    public float rel = 1;
    public float speed = 1;

    private int comboLength = 0;
    private Coroutine timer;

    public GameObject levelUpPanel;

    public void Upgrade(string statKey)
    {
        PlayerPrefs.SetFloat(statKey, PlayerPrefs.GetFloat(statKey)*1.335f);
        LevelUP();
    }
    // Start is called before the first frame update
    void Start()
    {
        overallExp = 0;
        instance = this;
        PlayerPrefs.SetFloat("DMG", 1);
        PlayerPrefs.SetFloat("SPD", 1);
        PlayerPrefs.SetFloat("REL", 1);
    }
    public void LevelUP()
    {
        GetComponent<CatHp>().ChangeHP(GetComponent<CatHp>().hp / 4);
        SetExp(experience-(int)expNeeded);
        expNeeded*=1.15f;
    }
    // Update is called once per frame

    public void AddExp(int exp)
    {
        experience += exp;
        overallExp += exp;
        PlayPickupSFX();
        progress.fillAmount = experience / expNeeded;
        levelUpPanel.SetActive(experience / expNeeded >= 1f);
    }

    private void SetExp(int exp)
    {
        experience = exp;
        progress.fillAmount = experience / expNeeded;
        levelUpPanel.SetActive(experience / expNeeded >= 1f);
    }

    private void PlayPickupSFX()
    {
        comboLength++;
        if (timer != null) StopCoroutine(timer);
        SFXManager.instance.PlaySFX("Pickup", transform, float.NaN, Mathf.Clamp(1f + (0.05f * comboLength), 1f, 1.5f));
        timer = StartCoroutine(expChainTimer());
    }

    IEnumerator expChainTimer()
    {
        yield return new WaitForSeconds(2f);
        comboLength = 0;
        yield return null;
    }
}
