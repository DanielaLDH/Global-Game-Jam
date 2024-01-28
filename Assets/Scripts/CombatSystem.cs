using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatSystem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public int CalculateDamage(int attack, int defense, int basePower, bool isCritical)
    {
        float criticalMultiplier = isCritical ? 1.5f : 1.0f;
        float damage = criticalMultiplier * ((basePower / 100.0f * attack) - defense);
        return Mathf.Max((int)damage, 0); // Garante que o dano não seja negativo
    }

}
