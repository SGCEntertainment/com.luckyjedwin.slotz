using UnityEngine.UI;
using UnityEngine;

public class Cash : MonoBehaviour
{
    private Text TextComponent { get; set; }
    public static float Count { get; set; }
    private void Awake()
    {
        TextComponent = transform.GetChild(0).GetComponent<Text>();
    }

    private void Update()
    {
        Count = Coefficient.Count * GameManager.Instance.bidCount;
        TextComponent.text = $"{Count}";
    }
}
