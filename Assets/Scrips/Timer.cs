using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timer; // Блок текста
    public float time = 60f; // Время для таймера в секундах
    public bool isRealyLose = true; // Можно ли проиграть после истечения таймера

    // Start is called before the first frame update
    void Start()
    {
        timer = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void FixedUpdate() 
    {
        if (time > 0)
        {
            time -= Time.deltaTime; // Уменьшаем время на прошедшее с последнего кадра

            // Преобразуем время в формат ММ:СС (минуты:секунды)
            float minutes = Mathf.FloorToInt(time / 60);
            float seconds = Mathf.FloorToInt(time % 60);

            // Обновляем текст для отображения оставшегося времени
            timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        else
        {
            timer.text = "Время вышло!";
            // Можно добавить дополнительные действия при окончании времени
            if(isRealyLose) // Если isRealyLose = true, то после истечения таймера сцена перезагрузится
            {
                ReloadScene();
            }
            
        }
        
    }

    void ReloadScene()
    {
        // Задержка перед перезагрузкой сцены (1 секунда)
        Invoke("Reload", 1f);
    }

    void Reload()
    {
        // Получаем индекс активной сцены и перезагружаем её
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
