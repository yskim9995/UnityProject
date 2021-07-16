using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Story : MonoBehaviour
{

    public Text Story_text;
    public Text Story_text2;
    public Text Story_text3;

    public Text text123;
    public GameObject Root;
    public Image ima;

    public float StoryTime;
    // Start is called before the first frame update
    void Start()
    {
        Root.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Story_pop();
         StoryTime += Time.deltaTime;
        
         if(StoryTime > 4)
         {
             Story_pop();
         }
         if(StoryTime > 8)
         {
            Story_pop2();
         }
         if (StoryTime > 12)
         {
             Story_pop3();
         }
        
         if(StoryTime > 16)
         {
             Story_text3.transform.position = new Vector3(27.8f, 120, 0);
             Root.SetActive(true);
             Story_text2.transform.position = new Vector3(999, 999, 999);
             Story_text.transform.position = new Vector3(999, 999, 999);
            ima.gameObject.SetActive(false);
         }

    }

    public void Story_pop()
    {
        Story_text.color -= new Color(0.2f, 0.2f, 0.2f)* Time.deltaTime;
        text123.color -= new Color(0.2f, 0.2f, 0.2f)* Time.deltaTime;
   
    }
    public void Story_pop2()
    {
        Story_text2.color -= new Color(0.2f, 0.2f, 0.2f) * Time.deltaTime;
    }
    public void Story_pop3()
    {
        Story_text3.color -= new Color(0.2f, 0.2f, 0.2f) * Time.deltaTime;
    }
}
