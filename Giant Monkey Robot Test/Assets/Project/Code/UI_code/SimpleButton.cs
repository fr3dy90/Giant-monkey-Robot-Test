using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SimpleButton : MonoBehaviour, IPointerClickHandler
{
    public JsonReader m_JR;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        m_JR.CreateTable();
    }
}
