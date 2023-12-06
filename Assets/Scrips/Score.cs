using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{


    [SerializeField]
    private TextMeshProUGUI scoreText; // Блок текста

    // [SerializeField]
    // private GameObject[] gorodokObjects;
    public List<GameObject> gorodokObjects;



    public int scoreForGorodok = 100;
    [SerializeField]
    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        // gorodokObjects = GameObject.FindGameObjectsWithTag("Gorodok");
        gorodokObjects = new List<GameObject>(GameObject.FindGameObjectsWithTag("Gorodok"));

    }

    // Update is called once per frame
    void Update()
    {
        List<GameObject> objectsToRemove = new List<GameObject>(); // Создаем список для объектов, которые нужно удалить

        foreach (GameObject obj in gorodokObjects)
        {
            SetActive gorodokScript = obj.GetComponent<SetActive>();

            if (gorodokScript != null && !gorodokScript.isConnected)
            {
                Debug.Log("Not connected "+obj.name);
                objectsToRemove.Add(obj); // Добавляем объекты для удаления в отдельный список
                score += scoreForGorodok;
            }
        }

        // Удаляем объекты только после завершения цикла, чтобы не изменять список в процессе итерации
        foreach (GameObject objToRemove in objectsToRemove)
        {
            gorodokObjects.Remove(objToRemove);
            Debug.Log("Not connected "+objToRemove.name);
            // Destroy(objToRemove); // Удаляем объект из сцены
        }

        UpdateScoreUI();
    }



    void UpdateScoreUI()
    {
        scoreText.text = score.ToString(); // Обновляем текст UI
    }
}
