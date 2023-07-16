using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomMove : MonoBehaviour
{
    public Vector2 cameraChange;
    public Vector3 playerChange;
    private CameraMovement cam;
    public bool needText;
    public string placeName;
    public GameObject text;
    public Text placeText;
    private float transferTimer;
    
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.GetComponent<CameraMovement>();
        transferTimer = Time.fixedTime;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // HACK обход проблемы с двойной отработкой перехода из за задержки взаимодействия триггера коллайдера.
        var curentTransferTime = Time.fixedTime;

        if (curentTransferTime > transferTimer)
        {
            transferTimer = curentTransferTime;

            // Организация перехода камеры на другую область.
            if (other.gameObject.CompareTag("Player"))
            {          
                cam.minPosition += cameraChange;
                cam.maxPosition += cameraChange;
                other.transform.position += playerChange;

                // Отображение название области при переходе.
                if (needText)
                {
                    StartCoroutine(PlaceNameCoroutine());
                }
            }
        }
    }

    // обработка отображения текст с установленным значением и последующим исчезанием.
    private IEnumerator PlaceNameCoroutine()
    {
        text.SetActive(true);
        placeText.text = placeName;
        yield return new WaitForSeconds(4f);
        text.SetActive(false);
    }
}
