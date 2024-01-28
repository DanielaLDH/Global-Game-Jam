using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public GameObject character0; // Referência para o primeiro personagem
    public GameObject character1; // Referência para o segundo personagem

    void Start()
    {
        int choice = GameManager.Instance.GetChoice(); // Obtém a escolha do GameManager

        if (choice == 0)
        {
            character0.SetActive(true); // Ativa o primeiro personagem
        }
        else if (choice == 1)
        {
            character1.SetActive(true); // Ativa o segundo personagem
        }
    }
}
