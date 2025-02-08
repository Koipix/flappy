using UnityEngine;
using UnityEngine.UI;

public class CharacterSelect : MonoBehaviour
{
    public PlayerScript playerScript; // Assign your PlayerScript
    public PipeSpawn pipeSpawn;
    public GameObject GameplayUI;
    public GameObject characterSelectUI; // Assign your character select UI GameObject
    public Button[] characterButtons; // Assign your character buttons in order

    void Start()
    {
        if (playerScript == null)
        {
            Debug.LogError("PlayerScript not assigned in CharacterSelect script!");
            return;
        }

        if (characterSelectUI == null)
        {
            Debug.LogError("Character Select UI not assigned in CharacterSelect script!");
            return;
        }

        if (characterButtons == null || characterButtons.Length == 0)
        {
            Debug.LogError("Character Buttons not assigned in CharacterSelect script!");
            return;
        }

        // Initially show character select UI and disable player functions
        characterSelectUI.SetActive(true);
        DisableGameplay(); // Disable gameplay functions

        // Add listeners to character buttons
        for (int i = 0; i < characterButtons.Length; i++)
        {
            int index = i;
            characterButtons[i].onClick.AddListener(() => SelectCharacter(index));
        }
    }

    void DisableGameplay()
    {
        if (pipeSpawn != null) pipeSpawn.enabled = false; // Disable pipe spawning
        playerScript.enabled = false;
        // Disable any other gameplay-related scripts or components
        if (GameplayUI != null) GameplayUI.SetActive(false); // Hide gameplay UI if you have one
    }

    void EnableGameplay()
    {
        if (pipeSpawn != null) pipeSpawn.enabled = true; // Enable pipe spawning
        playerScript.enabled = true;
        // Enable any other gameplay-related scripts or components
        if (GameplayUI != null) GameplayUI.SetActive(true); // Show gameplay UI
    }

    void SelectCharacter(int index)
    {
        if (index >= 0 && index < playerScript.playerPrefabs.Length)
        {
            playerScript.currentPlayerIndex = index;

            // Instantiate the selected prefab and assign it to the playerBody
            playerScript.InstantiatePlayer(index); // Call the new InstantiatePlayer function

            characterSelectUI.SetActive(false);
            EnableGameplay();
        }
        else
        {
            Debug.LogError("Invalid character index: " + index);
        }
    }
}