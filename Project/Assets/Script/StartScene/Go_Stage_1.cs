using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Go_Stage_1 : MonoBehaviour
{
    public Text StartText;
    bool asd;
    float startTime;
    // Start is called before the first frame update
    void Start()
    {
        asd = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(asd)
        {
            StartText.text = ">START<";
            if (startTime > 2)
            {
                SceneManager.LoadScene("SampleScene");
            }
            startTime += Time.deltaTime;
        }
    }

    public void SceneChange()
    {
        asd = true;
       
    }
}
