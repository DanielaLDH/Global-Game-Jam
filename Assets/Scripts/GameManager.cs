using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int choice; // Vari�vel para armazenar a escolha

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Mant�m o objeto na troca de cena
        }
        else if (Instance != this)
        {
            Destroy(gameObject); // Garante que s� exista uma inst�ncia
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
