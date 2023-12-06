using UnityEngine;

public class TriggerDetector : MonoBehaviour
{
    public BoxCollider boxCollider; // Ссылка на Box Collider
    public bool isConnected;
    public string connectedTag = "Gorodok";
    public GameObject mainElement;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
    }
    private void OnTriggerEnter(Collider other)
    {
        // Если объект входит в триггер
        if (other.CompareTag(connectedTag) && other.name != mainElement.name) // Можно использовать свои собственные теги для фильтрации объектов
        {
            isConnected = true;
            // Debug.Log("Object entered trigger: " + other.name);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        // Если объект остается в триггере
        if (other.CompareTag(connectedTag) && other.name != mainElement.name)
        {
            isConnected = true;
            // Debug.Log("Object stayed in trigger: " + other.name);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Если объект покидает триггер
        if (other.CompareTag(connectedTag) && other.name != mainElement.name)
        {
            isConnected = false;
            //  Debug.Log("Object exited trigger: " + other.name);
        }
    }

    // Метод для получения списка объектов, находящихся в Box Collider
    public void GetObjectsInCollider()
    {
        // Получение всех коллайдеров в указанной области Box Collider
        Collider[] colliders = Physics.OverlapBox(boxCollider.bounds.center, boxCollider.bounds.extents, boxCollider.transform.rotation);

        foreach (Collider col in colliders)
        {
            // Проверка, что коллайдер принадлежит нужному объекту
            if (col.CompareTag(connectedTag))
            {
                // Debug.Log("Object in trigger: " + col.name);
                // Вы можете сохранить или обработать объекты здесь
            }
        }
    }
}
