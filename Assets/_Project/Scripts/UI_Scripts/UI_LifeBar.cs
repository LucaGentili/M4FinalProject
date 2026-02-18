using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_LifeBar : MonoBehaviour
{
    [SerializeField] Image lifeBar;

    public void UpdateLifeBar(int hp, int maxHp)
    {
        lifeBar.fillAmount = (float) hp / maxHp;
    }
}
