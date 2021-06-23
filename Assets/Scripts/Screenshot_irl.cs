using UnityEngine;

public class Screenshot_irl : MonoBehaviour
{
    public KeyCode takeScreenshot = KeyCode.SysReq;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if (Input.GetKeyDown(takeScreenshot))
        {
            string date = System.DateTime.Now.ToString();
            date = date.Replace("/", "-");
            date = date.Replace(":", "-");

            string fileName = Application.persistentDataPath + "/Screenshots/screenshot_" + date + ".png";
            if(!System.IO.Directory.Exists(Application.persistentDataPath + "/Screenshots"))
                System.IO.Directory.CreateDirectory(Application.persistentDataPath + "/Screenshots");

            try{
                ScreenCapture.CaptureScreenshot(fileName);
            }
            catch(System.Exception e)
            {
                Debug.LogError(e);
                return;
            }

            Debug.Log("Screenshot at: " + fileName);
        }
    }
}
