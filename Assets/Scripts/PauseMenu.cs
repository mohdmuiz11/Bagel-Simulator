using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] GameObject pauseMenu;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private PowerUpManager powerUpManager;
    [SerializeField] private EventSystem eventSystem;
    [SerializeField] private Button continueButton;
    [SerializeField] private Button mainMenuButton;
    [SerializeField] private InputActionAsset playerControl;

    private InputAction pauseAction;
    private bool currentlyPaused;

    void Awake()
    {
        pauseAction = playerControl.FindAction("TogglePause");
        pauseAction.performed += TogglePause;
        pauseAction.Enable();
    }
    
    private void TogglePause(InputAction.CallbackContext context)
    {
        if (!gameManager.isOver)
        {
            currentlyPaused = !currentlyPaused;
            ShowMainMenu(currentlyPaused);
        }
    }

    // only for resume button
    public void ResumeButton()
    {
        currentlyPaused = false;
        ShowMainMenu(currentlyPaused);
    }

    private void ShowMainMenu(bool isVisible)
    {
        if (isVisible)
        {
            Time.timeScale = 0f;
            eventSystem.SetSelectedGameObject(continueButton.gameObject);
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            if (powerUpManager.isGameTimeSlowedDown)
                Time.timeScale = 0.5f;
            else
                Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
        }
        Cursor.visible = isVisible;
        pauseMenu.SetActive(isVisible);
        gameManager.isPaused = isVisible;
        continueButton.interactable = isVisible;
        mainMenuButton.interactable = isVisible;
    }

    public void Home()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }
    private void OnDestroy()
    {
        pauseAction.performed -= TogglePause;
        pauseAction.Disable();
    }
}
