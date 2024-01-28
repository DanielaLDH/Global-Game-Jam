using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public Player player1; // Referência para o primeiro personagem
    public Player player2; // Referência para o segundo personagem

    private Player activePlayer;

    void Start()
    {
        // Define o jogador ativo com base na escolha salva no GameManager
        activePlayer = GameManager.Instance.GetChoice() == 0 ? player1 : player2;
    }

    public void AttackTypeOne()
    {
        activePlayer.AttackTypeOne();
    }

    public void AttackTypeTwo()
    {
        activePlayer.AttackTypeTwo();
    }
}
