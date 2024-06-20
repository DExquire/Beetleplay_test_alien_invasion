using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthBar;
    public EnemyController enemyHealth;

    void Update()
    {
        healthBar.fillAmount = (enemyHealth.health/100f);
    }
}
