using UnityEngine;
using UnityEngine.UI;

public class ArrowsScript : MonoBehaviour
{
    [SerializeField] private Image[] previewImages;
    [SerializeField] Button leftButton, rightButton;
    private int numOfHatImages;

    // Start is called before the first frame update
    void Start()
    {   
    //     for(int i = 0; i < previewImages.Length; i++)
    // {
    //     if(!previewImages[i].isActiveAndEnabled) continue; 

    //     numOfHatImages = i;
    // }
        rightButton.onClick.AddListener(showNextPreview);
        leftButton.onClick.AddListener(showPreviousPreview);
    }

    // Update is called once per frame
    public void showNextPreview()
    {
        previewImages[numOfHatImages].enabled = true;
        numOfHatImages++;

        if(numOfHatImages > previewImages.Length -1)
        {
            numOfHatImages = 0;
        }

        //previewImages[numOfHatImages].enabled = false;
    }

    public void showPreviousPreview()
    {
        previewImages[numOfHatImages].enabled = true;
        numOfHatImages--;
        if(numOfHatImages < 0)
        {
            numOfHatImages = previewImages.Length -1;
        }

        // Show previous model
        previewImages[numOfHatImages].enabled = true;
    }
    }
