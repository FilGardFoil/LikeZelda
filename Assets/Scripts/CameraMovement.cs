using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public float smoothing;
    public Vector2 maxPosition;
    public Vector2 minPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Последнее обновление при построение кадра.
    void LateUpdate()
    {
        // Определение движение камеры относительно цели с укзанной скоростью следования.
        if (transform.position != target.position)
        {
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z); // указание расположения камеры с учётом отдаления по оси Z.

            // ограничение движение камеры по указанным позициям возможного минимального и максимального значения.
            targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);

            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
            

        }
    }
}
