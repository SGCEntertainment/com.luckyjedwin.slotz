using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject menu;
    [SerializeField] GameObject game;

    [Space(10)]
    [SerializeField] GameObject bet;
    [SerializeField] GameObject cashOut;
    [SerializeField] GameObject cancel;

    [Space(10)]
    [SerializeField] Text bidText;

    [Space(10)]
    [SerializeField] Button[] btns;

    private void Awake()
    {
        Airplane.OnStartFly += () =>
        {
            bet.SetActive(false);
            cancel.SetActive(true);

            foreach(Button b in btns)
            {
                b.interactable = false;
            }
        };

        Airplane.OnGrowing += () =>
        {
            cancel.SetActive(false);
            cashOut.SetActive(true);
        };

        Airplane.OnEndFly += () =>
        {
            cashOut.SetActive(false);
            cancel.SetActive(false);
            bet.SetActive(true);

            foreach (Button b in btns)
            {
                b.interactable = true;
            }
        };
    }

    private void Start()
    {
        bidText.text = $"{GameManager.Instance.bidCount}";
    }

    public void Menu()
    {
        Cancel();

        game.SetActive(false);
        menu.SetActive(true);
    }

    public void Game()
    {
        menu.SetActive(false);
        game.SetActive(true);
    }

    public void SetBid(int dir)
    {
        GameManager.Instance.bidCount += dir;
        if (GameManager.Instance.bidCount < 0)
        {
            GameManager.Instance.bidCount = 0;
        }

        bidText.text = $"{GameManager.Instance.bidCount}";
    }

    public void SetFixedBid(int bid)
    {
        GameManager.Instance.bidCount = bid;
        bidText.text = $"{GameManager.Instance.bidCount}";
    }

    public void Cancel()
    {
        if (FindObjectOfType<Airplane>())
        {
            FindObjectOfType<Airplane>().ResetMe();
        }
    }

    public void CashOut()
    {
        Product.OnBuyItem?.Invoke(Mathf.FloorToInt(-Cash.Count));
        Cancel();
    }
}