using UnityEngine;
using System.IO;
using System.Text;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GalagyScene : MonoBehaviour {

    public GameObject image;
    public GameObject imagePanel;
    public GameObject operationPanel;
    public GameObject selectedImage;
    void Start () {
        loadImages();
        Debug.Log(Application.persistentDataPath);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) SceneManager.LoadScene(0);
        if (selectedImage != null) operationPanel.SetActive(true);
	}

    public void loadImages() {
        StringBuilder text = new StringBuilder();
       foreach (string file in Directory.GetFiles(Application.persistentDataPath))
 //           foreach (string file in Directory.GetFiles("D"))
            {
             StartCoroutine(loadImage(file));
        }
    }

    IEnumerator loadImage(string file) {

        Texture2D tex = null;
        byte[] fileData;
        if (File.Exists(file))
        {
            fileData = File.ReadAllBytes(file);
            tex = new Texture2D(2, 2, TextureFormat.ARGB32, false);
            tex.LoadImage(fileData); //..this will auto-resize the texture dimensions.
        }
        yield return tex;
        GameObject imageView = Instantiate(image) as GameObject;
        Sprite sp = new Sprite();
        sp = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(tex.width / 2, tex.height / 2), 100);
        imageView.GetComponent<Image>().sprite = sp;

        imageView.transform.SetParent(imagePanel.transform);
        imageView.GetComponent<Transform>().localScale = new Vector3(1, 1, 1);
        imageView.tag = file;
    }

    public void selectImage() {
 //       Settings.currPhoto = selectedImage.GetComponent<Image>().sprite.texture;
        SceneManager.LoadScene(4);
    }

    public void deleteImage() {
        File.Delete(selectedImage.tag);
        Destroy(selectedImage);
        operationPanel.SetActive(false);
    }
}
