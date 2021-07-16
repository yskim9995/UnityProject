using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public Scrollbar m_scrollbar;

    public AudioSource BGM_audioSource;
    // Start is called before the first frame update
    void Start()
    {
        m_scrollbar.value = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        BGM_audioSource.volume = m_scrollbar.value;
    }
}

