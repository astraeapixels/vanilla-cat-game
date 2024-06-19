using UnityEngine;
using UnityEngine.UI;

public class CatCustomization : MonoBehaviour
{
    [SerializeField] private Image greenHatPreview, purpleCapPreview, yellowRibbonsPreview;

    [SerializeField] private Button greenHatButton, purpleCapButton, yellowRibbonsButton;

    private void Start()
    {
        greenHatPreview.enabled = false;
        purpleCapPreview.enabled = false;
        yellowRibbonsPreview.enabled = false;
        greenHatButton.onClick.AddListener(OnGreenButtonClick);
        purpleCapButton.onClick.AddListener(OnPurpleButtonClick);
        yellowRibbonsButton.onClick.AddListener(OnYellowButtonClick);
    }
    public void OnGreenButtonClick()
    {
        purpleCapPreview.enabled = false;
        yellowRibbonsPreview.enabled = false;
        greenHatPreview.enabled = true;
    }

     public void OnPurpleButtonClick()
    {
        greenHatPreview.enabled = false;
        yellowRibbonsPreview.enabled = false;
        purpleCapPreview.enabled = true;
    }

      public void OnYellowButtonClick()
    {
        greenHatPreview.enabled = false;
        purpleCapPreview.enabled = false;
        yellowRibbonsPreview.enabled = true;
    }

 
}
