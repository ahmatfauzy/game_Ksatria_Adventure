
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gerak : MonoBehaviour
{
    public float speed;

    Vector3 jalan;

    public Animator anime;
    private void Start(){

    }

    void Update(){
        jalan.x = Input.GetAxisRaw("Horizontal");
        jalan.y = Input.GetAxisRaw("Vertical");
        transform.position += jalan * speed * Time.deltaTime;

        if(jalan != Vector3.zero){
            anime.SetBool("lari", true);
        } else{
            anime.SetBool("lari", false);
        }
        

        
    }
}