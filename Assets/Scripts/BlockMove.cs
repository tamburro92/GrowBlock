using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMove : MonoBehaviour
{

    [Header("Rotation")]
    [SerializeField] float rotationStep = 90f;
    [SerializeField] float secondsOfStep = 2f;
    [SerializeField] float offsetInSeconds = 0f;
    [SerializeField] public bool doRotation = true;

    [Header("Translation")]
    [SerializeField] float translationOffset = 4f;
    [SerializeField] float translationVelocity = 0.5f;
    [SerializeField] public bool doTranslation = false;


    private Vector2 startingPosition;
    private int signTranslation = 1;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
        StartCoroutine(RotateStep());
        
    }

    // Update is called once per frame
    void Update()
    {
        Translate();
        
    }

    IEnumerator RotateStep(){
        while(doRotation){
            transform.eulerAngles = new Vector3(transform.eulerAngles.x,transform.eulerAngles.y,transform.eulerAngles.z + rotationStep);
            yield return new WaitForSeconds(secondsOfStep);
        }
    }
    void Translate(){
        if(doTranslation){
            if(Mathf.Abs(startingPosition.x - transform.position.x) > translationOffset){
                signTranslation = -signTranslation;
            }
            transform.position = new Vector2(transform.position.x + translationVelocity * Time.deltaTime * signTranslation, transform.position.y);
        }
    }

    public void DisalbeAlleMovement(){
        doRotation = false;
        doTranslation = false;
    }
}
