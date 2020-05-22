using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class BlockPosition : MonoBehaviour
{

[SerializeField] float xOffset = 0.5f;
[SerializeField] float yOffset = -0.4f;

    float width;
    float height;
    float blockSize;
    Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        blockSize = transform.localScale.x;
        height = camera.orthographicSize * 2;
        width = camera.aspect*height;  
    }
    // Update is called once per frame
    void Update()
    {
        float xPosition = transform.position.x;
        float yPosition = transform.position.y;
        if (!Mathf.Approximately(xOffset, Mathf.Abs(transform.position.x % blockSize))){
            Debug.Log("X: " + transform.position.x % blockSize);
            xPosition = Mathf.RoundToInt(transform.position.x) + xOffset;
        }
        if (!Mathf.Approximately(yOffset, Mathf.Abs(transform.position.y % blockSize))){
            Debug.Log("Y: " + transform.position.y % blockSize);
            yPosition = Mathf.RoundToInt(transform.position.y) + yOffset;
        }
       
        
        transform.position = new Vector2(xPosition, yPosition);
        
    }
}
