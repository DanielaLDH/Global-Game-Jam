using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int choice; // Variável para armazenar a escolha

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Mantém o objeto na troca de cena
        }
        else if (Instance != this)
        {
            Destroy(gameObject); // Garante que só exista uma instância
        }
    }

    public void SetChoice(int newChoice)
    {
        choice = newChoice;
    }

    public int GetChoice()
    {
        return choice;
    }
}
