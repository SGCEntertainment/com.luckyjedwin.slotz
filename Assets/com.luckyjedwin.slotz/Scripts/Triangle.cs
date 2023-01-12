using UnityEngine;

public class Triangle : MonoBehaviour
{
    private RectTransform Rectransform { get; set; }

    [SerializeField] Transform airplane;
    [SerializeField] Vector2 position;

    private void Awake()
    {
        Rectransform = GetComponent<RectTransform>();
    }
    private void Update()
    {
        Rectransform.offsetMax = airplane.localPosition;
    }
}
