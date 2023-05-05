using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Daun : MonoBehaviour
{
    //cara pertama drag drop
    //[SerializeField] private GameObject pohon;
    [SerializeField] private GameObject kotak;

    //cara kedua
    GameObject pohon;
    //GameObject kotak;

    // Start is called before the first frame update
    void Awake()
    {
        //find
       pohon =  GameObject.Find("itembelakang/Pohon").gameObject;
       // kotak =  GameObject.Find("kotak1").gameObject;

    }

    void Start()
    {
    }




    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            pohon.SetActive(true);
            pohon.GetComponent<Rigidbody2D>().gravityScale = 1;

            kotak.SetActive(false);
        }
    }

}
