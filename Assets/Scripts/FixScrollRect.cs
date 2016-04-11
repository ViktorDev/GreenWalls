using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FixScrollRect : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IScrollHandler
{
    ScrollRect MainScroll;
    GalagyScene sceneController;
//    GameObject [] images;

    void Start() {
        sceneController = GameObject.Find("SceneController").GetComponent<GalagyScene>();
        MainScroll = sceneController.imagePanel.transform.parent.GetComponent<ScrollRect>();
 //       images = GameObject.FindGameObjectsWithTag("Item");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        MainScroll.OnBeginDrag(eventData);
        GetComponent<GalaryItem>().isButtonClicked = false;
        //foreach (GameObject g in images) {
        //    g.GetComponent<GalaryItem>().isButtonClicked = false;
        //}
    }


    public void OnDrag(PointerEventData eventData)
    {
        MainScroll.OnDrag(eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        MainScroll.OnEndDrag(eventData);
        GetComponent<GalaryItem>().isButtonClicked = true;
        //foreach (GameObject g in images)
        //{
        //    g.GetComponent<GalaryItem>().isButtonClicked = true;
        //}
    }


    public void OnScroll(PointerEventData data)
    {
        MainScroll.OnScroll(data);
    }


}
