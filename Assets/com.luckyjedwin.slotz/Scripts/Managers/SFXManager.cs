using UnityEngine;

public class SFXManager : MonoBehaviour
{
    [SerializeField] AudioSource sfxSource;

    [Space(10)]
    [SerializeField] AudioClip win;
    [SerializeField] AudioClip lose;

    private void Start()
    {
        Airplane.OnEndFly += () =>
        {
            if (sfxSource.isPlaying)
            {
                sfxSource.Stop();
            }

            sfxSource.PlayOneShot(lose);
        };
    }

    public void CashOut()
    {
        if (sfxSource.isPlaying)
        {
            sfxSource.Stop();
        }

        sfxSource.PlayOneShot(win);
    }
}
