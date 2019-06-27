using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PropItem : MonoBehaviour {
    public float factor = 0.9f;
    private RectTransform rectTransform;
    private GridLayoutGroup gridLayoutGroup;
    private Vector2 size;
    void Start()
    {
        //parent = GetComponentInParent<RectTransform>();
        gridLayoutGroup = GetComponent<GridLayoutGroup>();
        rectTransform = GetComponent<RectTransform>();
        ResizeItem();
    }
    void Update()
    {
        if(rectTransform.rect.size != size)
        {
            ResizeItem();
        }
    }
    private void ResizeItem()
    {
        size = rectTransform.rect.size;
        //float width = parentWidth * factor;
        Debug.Log("parent.rect.size.x:" + rectTransform.rect.size.x);
        float width = size.x * factor;
        gridLayoutGroup.cellSize = new Vector2(width, width);
    }
}
