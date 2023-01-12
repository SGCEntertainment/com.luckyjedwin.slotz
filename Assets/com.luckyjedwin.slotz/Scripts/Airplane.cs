using System.Collections;
using UnityEngine.UI;
using UnityEngine;

using Random = UnityEngine.Random;
using System;

public class Airplane : MonoBehaviour
{
    private Vector2 Init { get => new Vector2(-447.9f, -317.2f); }
    private Vector2 Target { get => new Vector2(398, 301); }
    private Image Image { get; set; }


    public static Action OnStartFly { get; set; }
    public static Action OnGrowing { get; set; }
    public static Action OnEndFly { get; set; }


    private void Awake()
    {
        Image = GetComponent<Image>();

        Product.OnProductSelected += (type, id) =>
        {
            if(type == ProductType.Background)
            {
                return;
            }

            PlayerPrefsUtility.SetAirplaneSprite(id);

            Image.sprite = PlayerPrefsUtility.GetAirplaneplaneSprite;
            Image.SetNativeSize();
        };

        GameManager.OnGameStarted += () =>
        {
            StartCoroutine(nameof(Fly));
        };
    }

    private void OnEnable()
    {
        Image.sprite = PlayerPrefsUtility.GetAirplaneplaneSprite;
        Image.SetNativeSize();

        Image.enabled = false;
    }

    private IEnumerator Fly()
    {
        Image.enabled = true;
        OnStartFly?.Invoke();

        float et = 0.0f;
        float duration = Random.Range(1.5f, 2.5f);

        while(et < duration)
        {
            transform.localPosition = Vector2.Lerp(Init, Target, et / duration);

            et += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = Target;
        OnGrowing?.Invoke();

        float rv = Random.Range(5.0f, 30.0f);
        yield return new WaitForSeconds(rv);
        Image.enabled = false;

        OnEndFly?.Invoke();
    }

    public void ResetMe()
    {
        Image.enabled = false;
        transform.localPosition = Init;
        StopCoroutine(nameof(Fly));
        OnEndFly?.Invoke();
    }
}
