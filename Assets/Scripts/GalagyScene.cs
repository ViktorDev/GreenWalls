using UnityEngine;
using System.IO;
using System.Text;
using System.Collections;
using ElicitIce;

public class GalagyScene : SmartMonoBehaviour {

    public GameObject image;
    ImagePicker imagePicker;
    ImagePickerData data;

   public override void  Start () {
        base.Start();
        imagePicker = GetOrCreateComponent<ImagePicker>();
        data = new ImagePickerData(null, null, "Gallery", 1600, 1600, true, true);

        data.gameObject = gameObject.name;
        data.callback = CustomeReceiver;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();
	}

    public void openGallery() {
        
        SetData(true, false, false);

        imagePicker.StartImagePicker(data);
    }

    private void SetData(bool useDefault, bool useCamera, bool multiple)
    {
        data.useDefault = useDefault;
        data.showCamera = useCamera;
        data.selectMultiple = multiple;
    }

    internal void CustomeReceiver(string result)
    {
        int index = -1;
        string[] parts = result.Split('|');

        string load = null;

        if (parts.Length == 1)
        {
            //picker result
            load = parts[0];
        }
        else {
            if (parts.Length != 2 || !int.TryParse(parts[0], out index))
            {
                Debug.LogError("Selected callback was not valid for the executed action");
                return;
            }

            load = parts[1];

            //manually remove the entry
            imagePicker.RemoveReceivedEntry(index);
        }


        if (string.IsNullOrEmpty(load))
        {
            //use logcat to get more information
            Debug.Log("SDCard full or invalid file selected, please try again");
            return;
        }

              StartCoroutine(loadImage(load));
    }

    IEnumerator loadImage(string file)
    {

        Texture2D tex = null;
        byte[] fileData;
        if (File.Exists(file))
        {
            fileData = File.ReadAllBytes(file);
            tex = new Texture2D(2, 2, TextureFormat.ARGB32, false);
            tex.LoadImage(fileData); //..this will auto-resize the texture dimensions.
        }
        yield return tex;

        image.GetComponent<MeshRenderer>().material.mainTexture = tex;
        image.GetComponent<MeshRenderer>().material.shader = Shader.Find("Sprites/Default");
    }
}
