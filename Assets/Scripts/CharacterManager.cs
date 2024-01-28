using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public GameObject character0; // Refer�ncia para o primeiro personagem
    public GameObject character1; // Refer�ncia para o segundo personagem

    void Start()
    {
        int choice = GameManager.Instance.GetChoice(); // Obt�m a escolha do GameManager

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
