using UnityEngine;
using UnityEngine.SceneManagement;

namespace UserInterface
{
    public class PauseMenuUI : MonoBehaviour
    {
        [SerializeField] private GameObject pauseMenu;
    
        private void Start()
        {
            pauseMenu.SetActive(false);
        }

        public void PauseGame()
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            GameState.IsPaused = true;
        }

        public void ResumeGame()
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
            GameState.IsPaused = false;
        }

        public void MainMenu()
        {
            Time.timeScale = 1f;
            GameState.IsPaused = false;
            SceneManager.LoadScene(0);
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
