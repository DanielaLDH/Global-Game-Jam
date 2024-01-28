using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[System.Serializable]
public class Dialogue
{
    public string question;
    public string[] responses;
}
[System.Serializable]
public class NarrativeDialogue
{
    public string[] sentences;
}

public class DialogueSystem : MonoBehaviour
{
    public Text dialogueText;
    public Text narrativeDialogueText;
    public GameObject[] choiceButtons;
    public List<Dialogue> dialogues = new List<Dialogue>();
    public List<NarrativeDialogue> narrativeDialogues = new List<NarrativeDialogue>();
    public GameObject narrativeDialogueBar; // Barra de di�logo para narrativa
    public GameObject questionDialogueBar;  // Barra de di�logo para perguntas


    private bool isQuestionDialogue = false;
    private int currentNarrativeIndex = 0;
    private int choice;
    private int currentDialogueIndex = 0;
    private int choiceOneCount = 0; // Contador para a escolha do bot�o 1
    private int choiceTwoCount = 0; // Contador para a escolha do bot�o 2


    void Start()
    {
       // InitializeDialogues();
        StartDialogue();
    }

    // Exemplo de um di�logo
    public void StartDialogue()
    {
        if (isQuestionDialogue)
        {
            narrativeDialogueBar.SetActive(false);
            questionDialogueBar.SetActive(true);
            if (currentDialogueIndex < dialogues.Count)
            {
                Dialogue currentDialogue = dialogues[currentDialogueIndex];
                dialogueText.text = currentDialogue.question;

                SetupChoiceButtons(currentDialogue);
            }
            else
            {
                Debug.Log("Di�logos conclu�dos");
                // Processar as escolhas aqui
                SceneManager.LoadScene(2);
            }
        }
        else
        {
            narrativeDialogueBar.SetActive(true);
            questionDialogueBar.SetActive(false);
            // L�gica para di�logo narrativo
            if (currentNarrativeIndex < narrativeDialogues.Count)
            {
                string currentSentence = narrativeDialogues[currentNarrativeIndex].sentences[currentDialogueIndex];
                narrativeDialogueText.text = currentSentence;
                // Esconder ou desabilitar os bot�es de escolha
            }
            else
            {
                Debug.Log(isQuestionDialogue);
                // Transi��o para di�logo de perguntas
                isQuestionDialogue = true;
                currentDialogueIndex = 0;
                StartDialogue();
            }
        }

    }


    //void ShowDialogue(Dialogue dialogue)
    //{
    //    dialogueText.text = dialogue.text;
    //    for (int i = 0; i < choiceButtons.Length; i++)
    //    {
    //        if (i < dialogue.choices.Length)
    //        {
    //            choiceButtons[i].SetActive(true);
    //            choiceButtons[i].GetComponentInChildren<Text>().text = dialogue.choices[i];
    //        }
    //        else
    //        {
    //            choiceButtons[i].SetActive(false);
    //        }
    //    }
    //}

    public void MakeChoice(int choiceIndex)
    {
        if (choiceIndex == 0)
        {
            choiceOneCount++; // Incrementa a primeira vari�vel
        }
        else if (choiceIndex == 1)
        {
            choiceTwoCount++; // Incrementa a segunda vari�vel
        }

        Debug.Log("Escolha 1: " + choiceOneCount + ", Escolha 2: " + choiceTwoCount);

        if (choiceOneCount > choiceTwoCount) 
        {
            choice = 0;
        }
        if (choiceTwoCount > choiceOneCount)
        {
            choice = 1;
        }
        Debug.Log(choice);
        GameManager.Instance.SetChoice(choice);
        currentDialogueIndex++;
        StartDialogue();
    }

    public void AdvanceNarrative()
    {
        currentDialogueIndex++;
        if (currentDialogueIndex < narrativeDialogues[currentNarrativeIndex].sentences.Length)
        {
            narrativeDialogueText.text = narrativeDialogues[currentNarrativeIndex].sentences[currentDialogueIndex];
        }
        else
        {
            // Transi��o para di�logo de perguntas
            isQuestionDialogue = true;
            currentDialogueIndex = 0;
            StartDialogue();
        } 
    }


    void DetermineCharacter()
    {
        // Determine qual personagem ser� usado com base nas escolhas feitas
        // ...
        Debug.Log("Personagem escolhido baseado nas respostas do di�logo.");
    }

    void EndDialogue()
    {
        Debug.Log("Di�logos conclu�dos.");
        // Aqui voc� pode adicionar l�gica para o que acontece ap�s os di�logos terminarem
    }

    private void SetupChoiceButtons(Dialogue currentDialogue)
    {
        for (int i = 0; i < choiceButtons.Length; i++)
        {
            choiceButtons[i].GetComponent<Button>().onClick.RemoveAllListeners(); // Limpa listeners anteriores

            if (i < currentDialogue.responses.Length)
            {
                choiceButtons[i].SetActive(true);
                choiceButtons[i].GetComponentInChildren<Text>().text = currentDialogue.responses[i];

                // Configura o bot�o para chamar MakeChoice com o �ndice correto
                int choiceIndex = i;
                choiceButtons[i].GetComponent<Button>().onClick.AddListener(() => MakeChoice(choiceIndex));
            }
            else
            {
                choiceButtons[i].SetActive(false);
            }
        }
    }



}