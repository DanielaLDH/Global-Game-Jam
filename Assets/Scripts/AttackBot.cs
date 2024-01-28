using UnityEngine;

public class AttackBot : MonoBehaviour
{
    public float attackDamage = 10f;
    public float health = 100f;

    private bool isProvoked = false;

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject); // Destrói o objeto se a saúde chegar a 0
            return;
        }

        if (!isProvoked)
        {
            isProvoked = true;
            RespondWithAttack();

        }
    }

    void RespondWithAttack()
    {
        // O bot responde com um ataque
        Debug.Log(gameObject.name + " responde com ataque!");
        // Adicione aqui a lógica do ataque do bot
    }
}
