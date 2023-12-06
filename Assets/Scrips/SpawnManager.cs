using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject prefabToSpawn; // объект, который нужно заспаунить
    public Transform spawnPoint; // точка спауна

    void Start()
    {
        // Проверяем, что есть объект для спауна и точка спауна заданы
        if (prefabToSpawn != null && spawnPoint != null)
        {
            // Создаем объект на указанной точке
            GameObject spawnedObject = Instantiate(prefabToSpawn, spawnPoint.position, spawnPoint.rotation);

            // Можно также добавить дополнительные действия с заспауненным объектом
            // Например, изменить его параметры или применить дополнительные скрипты
        }
        else
        {
            Debug.LogError("Prefab для спауна или точка спауна не заданы!");
        }
    }
}
