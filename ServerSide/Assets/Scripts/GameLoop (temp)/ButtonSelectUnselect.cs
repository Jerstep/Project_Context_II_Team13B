using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class ButtonSelectUnselect : Button
{
    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);
        ColorBlock cb = this.colors;
    }
}
