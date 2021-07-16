using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Guide : MonoBehaviour
{
    public GameObject panel;

    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GuideShow()
    {
        if(panel.activeSelf)
        {
            panel.SetActive(false);
            return;
        }
        else
        {
            panel.SetActive(true);
        }
    }
}
