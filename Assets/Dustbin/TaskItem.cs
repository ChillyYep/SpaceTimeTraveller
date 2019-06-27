using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskItem : MonoBehaviour {
    public float factor = 0.9f;
    private RectTransform rectTransform;
    private GridLayoutGroup gridLayoutGroup;
    private Vector2 size;
    private float sizeRatio = 0.2f;//长宽比

	// Use this for initialization
	void Awake () {
        rectTransform = GetComponent<RectTransform>();
        gridLayoutGroup = GetComponent<GridLayoutGroup>();
        //SetChildrenWidth();
    }
	
	// Update is called once per frame
	//void Update () {
 //       if (rectTransform.rect.size != size)//当父控件尺寸发生变化，更新子控件大小
 //       {
 //           SetChildrenWidth();
 //       }
 //   }

    //private void SetChildrenWidth()//设置子元素大小
    //{
    //    size = rectTransform.rect.size;
    //    float width = size.x * factor;
    //    gridLayoutGroup.cellSize = new Vector2(width, width * sizeRatio);
    //    //Debug.Log("gridLayoutGroup.cellSize:x " + gridLayoutGroup.cellSize.x + ",y " + gridLayoutGroup.cellSize.y);
    //}
}
