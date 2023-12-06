using UnityEngine;

public class CylinderConnection : MonoBehaviour
{
    public bool isConnected;
    public string connectedTag = "Gorodok";
    public float connectionDistanceThreshold = 0.38f;
    public Color gizmoColor = Color.green;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = gizmoColor;

        // Получаем размеры объекта
        Vector3 size = GetComponent<Renderer>().bounds.size;

        // Рассчитываем радиус для гизмо на основе размеров объекта
        float radius = Mathf.Max(size.x, size.y, size.z) / 2f + connectionDistanceThreshold;

        // Рисуем сферу вокруг объекта
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    private void Update()
    {
        isConnected = CheckIfConnected();
        // Дополнительные действия в зависимости от состояния isConnected
    }

    private bool CheckIfConnected()
    {
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(connectedTag);
        foreach (GameObject obj in objectsWithTag)
        {
            if (obj != this.gameObject)
            {
                // Получаем размеры текущего и другого объекта
                Vector3 thisSize = GetComponent<Renderer>().bounds.size;
                Vector3 otherSize = obj.GetComponent<Renderer>().bounds.size;

                // Рассчитываем расстояние, на котором объекты считаются соединенными
                float distanceThreshold = Mathf.Max(thisSize.x, thisSize.y, thisSize.z, otherSize.x, otherSize.y, otherSize.z) / 2f + connectionDistanceThreshold;

                float distance = Vector3.Distance(transform.position, obj.transform.position);

                if (distance < distanceThreshold)
                {
                    return true;
                }
            }
        }
        return false;
    }
}
