using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI canvasText;
    float waktu;
    // Start is called before the first frame update
    void Start()
    {
        waktu = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        waktu = waktu + 1 * Time.deltaTime;
        canvasText.text = waktu + "";
    }

}
