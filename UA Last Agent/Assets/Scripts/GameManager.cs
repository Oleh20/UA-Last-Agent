using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class GameManager : MonoBehaviour
{
    private string lastSceneName; // Змінна для зберігання останньої запущеної сцени
    private string saveFileName = "lastscene.txt"; // Назва файлу для зберігання останньої сцени
    private static GameObject gameManager;

    private void Awake()
    {
        gameManager = gameObject;
        DontDestroyOnLoad(gameManager);
        // Перевіряємо, чи є збережена остання сцена
        if (!string.IsNullOrEmpty(lastSceneName))
        {
            // Запускаємо збережену останню сцену
            SceneManager.LoadScene(lastSceneName);
        }
        // Перевіряємо, чи є збережений файл
        if (File.Exists(saveFileName))
        {
            // Зчитуємо назву сцени з файлу
            lastSceneName = File.ReadAllText(saveFileName);
            SceneManager.LoadScene(lastSceneName);
        }
        else
        {
            // Створюємо новий файл і записуємо в нього пусту рядок
            File.WriteAllText(saveFileName, string.Empty);
        }
    }

    private void OnApplicationQuit()
    {
        // Зберігаємо назву поточної сцени перед виходом з програми
        Scene currentScene = SceneManager.GetActiveScene();
        lastSceneName = currentScene.name;

        // Записуємо назву сцени в файл
        File.WriteAllText(saveFileName, lastSceneName);
    }

}