using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pohon : MonoBehaviour
{

    [SerializeField] GameObject canvas;
    public TextMeshProUGUI canvasText;
    


    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
      
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //canvasText.text = "km telah menghilangkan pohon";
            canvas.GetComponent<AturText>().setText("km telah menghilangkan pohon");

            gameObject.SetActive(false);
        }
        //Debug.Log(collision.gameObject.name);
    }

    /*
    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
    }
    */

}
