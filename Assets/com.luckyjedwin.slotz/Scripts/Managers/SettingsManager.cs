using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [Space(10)]
    [SerializeField] AudioSource loop;
    [SerializeField] Button soundBtn;

    [Space(10)]
    [SerializeField] AudioSource sfx;
    [SerializeField] Button sfxBtn;

    private void Start()
    {
        loop.mute = sfx.mute = true;

        soundBtn.onClick.AddListener(() =>
        {
            loop.mute = !loop.mute;

            soundBtn.transform.GetChild(0).gameObject.SetActive(!loop.mute);
            soundBtn.transform.GetChild(1).gameObject.SetActive(loop.mute);
        });


        sfxBtn.onClick.AddListener(() =>
        {
            sfx.mute = !sfx.mute;

            sfxBtn.transform.GetChild(0).gameObject.SetActive(!sfx.mute);
            sfxBtn.transform.GetChild(1).gameObject.SetActive(sfx.mute);
        });

        soundBtn.onClick.Invoke();
        sfxBtn.onClick.Invoke();
    }
}
