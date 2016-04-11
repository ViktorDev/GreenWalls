using UnityEngine;

public class GalaryItem : MonoBehaviour {

    GalagyScene sceneController;
    bool isClicked;
    public bool isButtonClicked;
	// Use this for initialization
	void Start () {
        sceneController = GameObject.Find("SceneController").GetComponent<GalagyScene>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void click() {
        if (isButtonClicked) {
            if (!isClicked)
            {
                sceneController.selectedImage = gameObject;
                isClicked = true;
            }
            else {
                sceneController.selectedImage = null;
                isClicked = false;
            }
        }
    }
}
