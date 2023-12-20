using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreText;

    public List<GameObject> gorodokObjects;
    public int scoreForGorodok = 100;

    private int score = 0;

    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        GetGorodki();
    }

    public void GetGorodki()
    {
        gorodokObjects = new List<GameObject>(GameObject.FindGameObjectsWithTag("Gorodok"));
    }

    public void ResetScrore()
    {
        score = 0;
    }

    void Update()
    {
        gorodokObjects.RemoveAll(item => item == null); // Удаляем отсутствующие объекты из списка

        List<GameObject> objectsToRemove = new List<GameObject>();

        foreach (GameObject obj in gorodokObjects)
        {
            SetActive gorodokScript = obj.GetComponent<SetActive>();

            if (gorodokScript != null && !gorodokScript.isConnected)
            {
                Debug.Log("Not connected " + obj.name);
                objectsToRemove.Add(obj);
                score += scoreForGorodok;
            }
        }

        foreach (GameObject objToRemove in objectsToRemove)
        {
            gorodokObjects.Remove(objToRemove);
            Debug.Log("Not connected " + objToRemove.name);
            // Destroy(objToRemove); // Удаляем объект из сцены
        }

        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        scoreText.text = score.ToString();
    }
}
