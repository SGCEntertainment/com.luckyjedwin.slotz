using UnityEngine.UI;
using UnityEngine;

public class Coefficient : MonoBehaviour
{
    private Text TextComponent { get; set; }
    public static int Count { get; set; }
    private void Awake()
    {
        TextComponent = transform.GetChild(0).GetComponent<Text>();

        Count = 0;
        TextComponent.text = $"x{Count}";

        Airplane.OnGrowing += () =>
        {
            InvokeRepeating(nameof(Growing), 0.0f, 1.0f);
        };

        Airplane.OnStartFly += () =>
        {
            Count = 0;
            TextComponent.text = $"x{Count}";
        };

        Airplane.OnEndFly += () =>
        {
            CancelInvoke(nameof(Growing));
        };
    }

    private void Growing()
    {
        Count += Random.Range(1, 3);
        TextComponent.text = $"x{Count}";
    }
}
