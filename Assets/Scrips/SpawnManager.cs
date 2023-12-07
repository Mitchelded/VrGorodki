using Unity.Entities.UniversalDelegates;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] prefabToSpawn; // объект, который нужно заспаунить
    public Transform spawnPoint; // точка спауна

    public GameObject spawnedObject;



    void Start()
    {
        SpawnObject(); // инициализируем спаун объекта при старте
    }

    public void SpawnObject()
    {
        // Проверяем, что есть объекты для спауна и точка спауна заданы
        if (prefabToSpawn.Length > 0 && spawnPoint != null)
        {
            
            // Генерируем случайный индекс для выбора префаба
            int randomIndex = Random.Range(0, prefabToSpawn.Length);

            // Создаем объект на указанной точке
            spawnedObject = Instantiate(
                prefabToSpawn[randomIndex],
                spawnPoint.position,
                spawnPoint.rotation
            );

            // Можно также добавить дополнительные действия с заспауненным объектом
            // Например, изменить его параметры или применить дополнительные скрипты
        }
        else
        {
            Debug.LogError("Префабы для спауна или точка спауна не заданы!");
        }
    }

    public void RespawnObject()
    {
        // Уничтожаем предыдущий объект
        Destroy(spawnedObject);

        // Переспауним объект заново
        SpawnObject();
    }
}
