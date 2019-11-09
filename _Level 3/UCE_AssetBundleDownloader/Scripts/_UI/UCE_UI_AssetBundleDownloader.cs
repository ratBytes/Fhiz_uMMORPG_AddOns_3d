using UnityEngine;
using UnityEngine.UI;

public class UCE_UI_AssetBundleDownloader : MonoBehaviour
{
    public static UCE_UI_AssetBundleDownloader singleton;

    public GameObject panel;
    public Text messageText;
    public Slider progressSlider;
    public Text progressText;
    public Button cancelButton;

    public UCE_UI_AssetBundleDownloader()
    {
        if (singleton == null) singleton = this;
    }

    public void Show(string message)
    {


        cancelButton.onClick.SetListener(() => {
            NetworkManagerMMO.Quit();
        });

        panel.SetActive(true);

    }
}
