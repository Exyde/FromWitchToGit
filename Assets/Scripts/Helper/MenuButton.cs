using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
public class MenuButton : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{

    private void Start()
    {
        Color c = GetComponentInChildren<Text>().color;
        c.a = .7f;
        GetComponentInChildren<Text>().color = c;
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        //Play sound
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Color c = GetComponentInChildren<Text>().color;
        c.a = 1f;

        GetComponentInChildren<Text>().color = c;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Color c = GetComponentInChildren<Text>().color;
        c.a = .7f;

        GetComponentInChildren<Text>().color = c;
    }
}
