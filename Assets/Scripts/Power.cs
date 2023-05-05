using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour
{
    [SerializeField] GameObject canvas;
    GameObject platform;
    GameObject boulder;
    GameObject lever1;
    GameObject lever2;
    GameObject gate1;
    GameObject teleporter2;
    
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Awake()
    {
        //find
        platform = GameObject.Find("platform").gameObject;
        boulder = GameObject.Find("boulder").gameObject;
        lever1 = GameObject.Find("lever1").gameObject;
        lever2 = GameObject.Find("lever2").gameObject;
        gate1 = GameObject.Find("gate1").gameObject;
        teleporter2 = GameObject.Find("teleporter2").gameObject;


    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (this.tag =="promptmove") 
            {
                canvas.GetComponent<AturText>().setText("Tekan A dan D untuk bergerak ke kanan dan kiri");
                gameObject.SetActive(false);
            };
            if (this.tag == "promptjump")
            {
                canvas.GetComponent<AturText>().setText("Tekan spacebar untuk melompat");
                gameObject.SetActive(false);
            };
            
            if (this.tag == "prompttrampoline")
            {

                canvas.GetComponent<AturText>().setText("Gunakan trampoline untuk melompat tinggi");
                gameObject.SetActive(false);
            };
            if (this.tag == "promptclue")
            {

                canvas.GetComponent<AturText>().setText("Jalan buntu, aku harus mencari jalan lain");
                gameObject.SetActive(false);
            };
            
            if (this.tag == "promptlever")
            {
                canvas.GetComponent<AturText>().setText("Lever untuk apa itu ?");
                gameObject.SetActive(false);
                
            };
            if (this.tag == "triggerplatform")
            {

                lever1.GetComponent<Animator>().enabled = true;
                platform.GetComponent<Animator>().enabled = true;
            };
            if (this.tag == "triggerpintu")
            {

                lever2.GetComponent<Animator>().enabled = true;
                gate1.GetComponent<Animator>().enabled = true;
                
            };
            if (this.tag == "triggerboulder")
            {

                boulder.SetActive(true);
                gameObject.SetActive(false);

            }; 
            if (this.tag == "teleporter1")
            {
                GameObject player = collision.gameObject;
                player.transform.position = teleporter2.transform.position;

            }

        }
    }
}
