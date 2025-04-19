using UnityEngine;
using UnityEngine.UI;

public class ButtonSoundHook : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            if (AudioManager.Instance != null)
                AudioManager.Instance.PlayClick();
        });
    }
}
