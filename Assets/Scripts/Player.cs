using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speedPlayer = 0.5f;
    [SerializeField] float xMin = -4.5f;
    [SerializeField] float xMax = 4.5f;


    [Header("Explosion")]
    [SerializeField] float durationExplosion = 1f;
    [SerializeField] GameObject deathVFX;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        MovePlayer();
    }
        private void MovePlayer(){
        float xAxis = Input.GetAxis("Horizontal") * Time.deltaTime * speedPlayer;
        float yAxis = Input.GetAxis("Vertical") * Time.deltaTime * speedPlayer;
        
        xAxis = Mathf.Clamp(transform.position.x + xAxis, xMin, xMax);

        transform.position = new Vector2(xAxis, transform.position.y);  

    }
    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Collision");
        if(other.tag=="Obstacles"){
            Destroy(gameObject);
            GameObject explosion = Instantiate(deathVFX, transform.position, transform.rotation);
            Destroy(explosion, durationExplosion);
        }
        else{
            if(other.transform.parent.GetComponent<BlockMove>())
                other.transform.parent.GetComponent<BlockMove>().DisalbeAlleMovement();
            other.transform.parent.parent = transform;
        }
    }
}
