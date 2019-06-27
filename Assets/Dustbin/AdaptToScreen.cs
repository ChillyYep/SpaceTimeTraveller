using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdaptToScreen : MonoBehaviour {
    private Vector3 scale;
    private float cameraHeight;
    private float cameraWidth;
    private SpriteRenderer spriteRenderer;
	// Use this for initialization
	void Start () {
        AdaptToCamera();
    }

    // Update is called once per frame
    void Update () {
        AdaptToCamera();
    }
    private void AdaptToCamera()
    {
        cameraHeight = Camera.main.orthographicSize * 2;
        cameraWidth = cameraHeight * Camera.main.aspect;
        spriteRenderer = GetComponent<SpriteRenderer>();
        scale = spriteRenderer.transform.localScale;

        if (cameraHeight >= cameraWidth)
        {
            scale *= cameraHeight / spriteRenderer.bounds.size.y;
        }
        else
        {
            scale *= cameraWidth / spriteRenderer.bounds.size.x;
        }
        spriteRenderer.transform.localScale = scale;
        spriteRenderer.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, spriteRenderer.transform.position.z);

    }
}
