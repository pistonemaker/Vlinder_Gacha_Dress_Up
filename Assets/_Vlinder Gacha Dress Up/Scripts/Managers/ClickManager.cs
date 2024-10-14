using UnityEngine;

public class ClickManager : MonoBehaviour
{
    public static ClickManager Instance;
    public Circle circle;
    public Coroutine circleCoroutine;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 10f; // Khoảng cách Z cần thiết cho camera
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            circle.transform.position = worldPosition;
            circle.gameObject.SetActive(true);

            if (circleCoroutine != null)
            {
                StopCoroutine(circleCoroutine);
            }

            circleCoroutine = StartCoroutine(circle.CircleAnim());
        }
    }
}