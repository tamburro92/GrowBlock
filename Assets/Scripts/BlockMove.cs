using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMove : MonoBehaviour
{

    [Header("Rotation Discrete")]
    [SerializeField] float rotationStep = 90f;
    [SerializeField] float secondsOfStep = 2f;
    [SerializeField] float offsetInSeconds = 0f;
    [SerializeField] public bool doRotation = false;

    [Header("Translation Horizontal")]
    [SerializeField] float translationOffsetH = 2f;
    [SerializeField] float translationVelocityH = 2f;
    [SerializeField] public bool doTranslationH = false;

    [Header("Translation Vertical")]
    [SerializeField] float translationOffsetV = 2f;
    [SerializeField] float translationVelocityV = 2f;
    [SerializeField] public bool doTranslationV = false;


    private Vector2 startingLocalPosition;
    private int signTranslationH = 1;
    private int signTranslationV = 1;


    // Start is called before the first frame update
    void Start()
    {
        startingLocalPosition = transform.localPosition;
        StartCoroutine(RotateStep());
        
    }

    // Update is called once per frame
    void Update()
    {
        Translate();
        
    }

    IEnumerator RotateStep(){
        while(doRotation){
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x,transform.localEulerAngles.y,transform.localEulerAngles.z + rotationStep);
            yield return new WaitForSeconds(secondsOfStep);
        }
    }
    void Translate(){
        if(doTranslationH){
            if(Mathf.Abs(startingLocalPosition.x - transform.localPosition.x) > translationOffsetH){
                signTranslationH = -signTranslationH;
            }
            transform.localPosition = new Vector2(transform.localPosition.x + translationVelocityH * Time.deltaTime * signTranslationH, transform.localPosition.y);
        }

        if(doTranslationV){
            if(Mathf.Abs(startingLocalPosition.y - transform.localPosition.y) > translationOffsetV){
                signTranslationV = -signTranslationV;
            }
            
            transform.localPosition = new Vector2(transform.localPosition.x, translationVelocityV * Time.deltaTime * signTranslationV + transform.localPosition.y);
        }
    }

    public void DisalbeAlleMovement(){
        doRotation = false;
        doTranslationH = false;
        doTranslationV = false;
    }
}
