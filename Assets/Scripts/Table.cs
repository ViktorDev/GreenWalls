using UnityEngine;
using System.Collections;

public class Table : MonoBehaviour {

    float height;
    float width;
    public GameObject box;

	// Use this for initialization
	void Start () {

        for (int x = 0; x < 6; x++) {
            for (int y = 0; y < 5; y++) {
                GameObject b = Instantiate(box);
                b.transform.parent = transform;
                b.transform.localPosition = new Vector3(x * 10, 0, y*10);
            }
        }
        height = 5;
        width = 6;
        transform.position = new Vector3(-width*10/2, 450, -height*10/2);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ScaleWidth(float w) {

    }

    public void ScaleHeight(float h)
    {

    }
}
