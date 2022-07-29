using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class MusicTitle : MonoBehaviour, IPointerDownHandler
{

    public static event Action<int> NewMusicSelected;

    public int index;
    
    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left) 
            NewMusicSelected?.Invoke(index);
    }
}
