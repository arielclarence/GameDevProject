using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class AturText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI waktu_txt;
    [SerializeField] TextMeshProUGUI info_txt;
    [SerializeField] GameObject proses_btn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setText(string param)
    {
        info_txt.text = param;
        StartCoroutine("delay1");
    }

    IEnumerator delay1()
    {
        yield return new WaitForSeconds(3f);
        info_txt.text = "";
    }

    public string getText()
    {
        string param = info_txt.text;
        return param;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }



}
