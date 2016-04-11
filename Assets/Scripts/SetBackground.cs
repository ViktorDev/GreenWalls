using UnityEngine;
using System.Collections;

public class SetBackground : MonoBehaviour {

    
	// Use this for initialization
	void Start () {
        Resize();
	}
	
	// Update is called once per frame
    void Update()
    {


    }
    void Resize()
    {
        
        transform.localScale = new Vector3(140*Screen.width/Screen.height, 1, 140);
    }

}
