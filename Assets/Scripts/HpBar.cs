using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    [SerializeField] private Image lefthalf, righthalf;

    public void SetHPBarValue(float hpBarValue)
    {
        lefthalf.fillAmount = hpBarValue;
        righthalf.fillAmount = hpBarValue;
    }
}
