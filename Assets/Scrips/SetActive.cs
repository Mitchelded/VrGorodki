using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SetActive : MonoBehaviour
{
    public GameObject mainElement;

    // [SerializeField] private GameObject Trigger1;
    // [SerializeField] private GameObject Trigger2;
    // [SerializeField] private GameObject Trigger3;
    // [SerializeField] private GameObject Trigger4;
    // [SerializeField] private GameObject Trigger5;
    // [SerializeField] private GameObject Trigger6;
    public bool isConnected = true;

    // public TextMeshProUGUI scoreText; // Блок текста

    // public int scoreForGorodok = 100;
    // [SerializeField]
    // private int score = 0;

    [SerializeField]
    private bool isDisappear = true;

    public float untilForDesappear = 2f;

    // Ссылка на компонент MeshRenderer
    public MeshRenderer meshRenderer;

    // Начальный цвет объекта
    public Color startColor = Color.white;

    [SerializeField]
    private TriggerDetector Trigger1Detector;

    [SerializeField]
    private TriggerDetector Trigger2Detector;

    [SerializeField]
    private TriggerDetector Trigger3Detector;

    [SerializeField]
    private TriggerDetector Trigger4Detector;

    [SerializeField]
    private TriggerDetector Trigger5Detector;

    [SerializeField]
    private TriggerDetector Trigger6Detector;

    // Start is called before the first frame update
    void Start()
    {
        // Получаем дочерние элементы главного элемента
        // Trigger1 = mainElement.transform.Find("Trigger1").gameObject;
        // Trigger2 = mainElement.transform.Find("Trigger2").gameObject;
        // Trigger3 = mainElement.transform.Find("Trigger3").gameObject;
        // Trigger4 = mainElement.transform.Find("Trigger4").gameObject;
        // Trigger5 = mainElement.transform.Find("Trigger5").gameObject;
        // Trigger6 = mainElement.transform.Find("Trigger6").gameObject;

        isConnected = true;
        Trigger1Detector = mainElement
            .transform
            .Find("Trigger1")
            .gameObject
            .GetComponent<TriggerDetector>();
        Trigger2Detector = mainElement
            .transform
            .Find("Trigger2")
            .gameObject
            .GetComponent<TriggerDetector>();
        Trigger3Detector = mainElement
            .transform
            .Find("Trigger3")
            .gameObject
            .GetComponent<TriggerDetector>();
        Trigger4Detector = mainElement
            .transform
            .Find("Trigger4")
            .gameObject
            .GetComponent<TriggerDetector>();
        Trigger5Detector = mainElement
            .transform
            .Find("Trigger5")
            .gameObject
            .GetComponent<TriggerDetector>();
        Trigger6Detector = mainElement
            .transform
            .Find("Trigger6")
            .gameObject
            .GetComponent<TriggerDetector>();

        // Получаем компонент MeshRenderer из объекта
        meshRenderer = GetComponent<MeshRenderer>();

        // Устанавливаем начальный цвет объекта
        meshRenderer.material.color = startColor;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (
            Trigger1Detector != null
            && Trigger2Detector != null
            && Trigger3Detector != null
            && Trigger4Detector != null
            && Trigger5Detector != null
            && Trigger6Detector != null
        )
        {
            if (
                Trigger1Detector.isConnected
                || Trigger2Detector.isConnected
                || Trigger3Detector.isConnected
                || Trigger4Detector.isConnected
                || Trigger5Detector.isConnected
                || Trigger6Detector.isConnected
            )
            {
                isConnected = true;
            }
            else if (
                !Trigger1Detector.isConnected
                && !Trigger2Detector.isConnected
                && !Trigger3Detector.isConnected
                && !Trigger4Detector.isConnected
                && !Trigger5Detector.isConnected
                && !Trigger6Detector.isConnected
            )
            {
                isConnected = false;
                if (isDisappear)
                {
                    StartCoroutine(DeactivateWithDelay());
                }
            }
        }
    }

    IEnumerator DeactivateWithDelay()
    {
        yield return new WaitForSeconds(untilForDesappear); // Задержка в 2 секунды (можно изменить значение)

        // gameObject.SetActive(false); // Отключение объекта после задержки

        // Генерируем новый случайный цвет
        Color newColor = new Color(255, 0, 0);

        // score += scoreForGorodok
        // scoreText.text = score.ToString();

        // Устанавливаем новый цвет материала меша
        meshRenderer.material.color = newColor;
    }
}
