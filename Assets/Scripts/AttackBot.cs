using UnityEngine;

public class AttackBot : MonoBehaviour
{
    public float attackDamage = 10f;
    public float health = 100f;
    public int defense; // defesa do inimigo

    private bool isProvoked = false;

    public void TakeDamage(float damage)
    {
        if (damage > defense)
        {
            health -= damage;
            if (health <= 0)
            {
                Destroy(gameObject); // Destr�i o objeto se a sa�de chegar a 0
                return;
            }

            if (!isProvoked)
            {
                isProvoked = true;
                RespondWithAttack();

            }
        }
        else
        {
            Debug.Log("Ataque insuficiente para penetrar a defesa.");
        }
    }

    void RespondWithAttack()
    {
        // O bot responde com um ataque
        Debug.Log(gameObject.name + " responde com ataque!");
        // Adicione aqui a l�gica do ataque do bot
    }
}
