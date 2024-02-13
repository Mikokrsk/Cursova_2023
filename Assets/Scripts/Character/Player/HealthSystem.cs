using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HealthSystem : MonoBehaviour
{
    public void ChangeHp(int amount)
    {
        Player player = GetComponent<Player>(); 
           player._playerStats.health = Mathf.Clamp(player._playerStats.health + amount, 0, player._playerStats.maxHealth);
        GameUI.Instance.SetHealthValue(player._playerStats.health / (float)player._playerStats.maxHealth);
    }
}
