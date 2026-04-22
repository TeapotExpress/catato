using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ValueShow : MonoBehaviour
{
    private Image im;
    public string type;
    private GameObject addLevelButton;
    // Start is called before the first frame update
    void Start()
    {
        im = GetComponent<Image>();
        addLevelButton = transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        im.fillAmount = PlayerPrefs.GetFloat(type) / 18;
        if (im.fillAmount == 1f) addLevelButton.SetActive(false);
    }
}
