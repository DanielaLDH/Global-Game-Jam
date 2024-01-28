using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatTest : MonoBehaviour
{
    public GameObject attacker;
    public GameObject defender;

    void Start()
    {
        // Exemplo de estatísticas
        int attackerAttack = 25;
        int defenderDefense = 22;
        int basePower = 50; // 50% do poder do golpe
        bool isCritical = false; // Altere para testar o dano crítico

        CombatSystem combatSystem = new CombatSystem();
        int damage = combatSystem.CalculateDamage(attackerAttack, defenderDefense, basePower, isCritical);

        Debug.Log("Dano causado: " + damage);
    }
}
