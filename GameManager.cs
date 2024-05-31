using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int totalCollectibles = 10;
    private int collectedItems = 0;
    public TextMeshProUGUI collectiblesText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateCollectiblesText();
    }

    public void CollectItem()
    {
        collectedItems++;
        UpdateCollectiblesText();
        if (collectedItems >= totalCollectibles)
        {
            FinishGame();
        }
    }

    private void UpdateCollectiblesText()
    {
        collectiblesText.text = collectedItems + " " + "/" + " " + totalCollectibles;
    }

    private void FinishGame()
    {
        Debug.Log("All collectibles collected! Game Over.");
        ChangeScene("GameWin");
    }

    private void ChangeScene(string sceneName)
    {
        Cursor.visible = true; // Ensure the cursor is visible
        Cursor.lockState = CursorLockMode.None; // Ensure the cursor is unlocked
        SceneManager.LoadScene(sceneName);
    }
}
