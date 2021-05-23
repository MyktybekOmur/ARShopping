using UnityEngine;
using UnityEngine.UI;

public class ScreenShot : MonoBehaviour
{
    public Image pictureHolder;
    public Image btnDetaıls;
    public Image btnBack;


    //Hide picture holder
    void Start()
    {
        //this method will show and hide the picture holder
        ShowPictureHolder(false);
    }

    private void ShowPictureHolder(bool visible)
    {
        pictureHolder.gameObject.SetActive(visible);
        btnDetaıls.gameObject.SetActive(!visible);
        btnBack.gameObject.SetActive(!visible);
    }

    //Create take screenshot method. It will be called by the button
    public void TakeScreenshot()
    {
        btnDetaıls.gameObject.SetActive(false);
        btnBack.gameObject.SetActive(false);
        GleyShare.Manager.CaptureScreenshot(ScreenshotCaptured);
    }
   
    //called after a screenshot is captured
    private void ScreenshotCaptured(Sprite sprite)
    {
        if (sprite != null)
        {
            //set captured image on picture holder and enable it
            pictureHolder.sprite = sprite;
            ShowPictureHolder(true);
        }
    }

    //create the cancel method
    public void Cancel()
    {
        ShowPictureHolder(false);
    }

    //Create share method
    public void Share()
    {
        GleyShare.Manager.SharePicture();
    }
}