using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MouseCousor : MonoBehaviour
{

    Image m_MouseCursor;
    Canvas m_RootCanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Update_Mouse()
    {

        Vector3 vPos = Input.mousePosition;
        Camera KCamera = m_RootCanvas.worldCamera;

        Vector3 vWorld;
        RectTransformUtility.ScreenPointToWorldPointInRectangle(
            m_RootCanvas.transform as RectTransform, vPos, KCamera, out vWorld);

        m_MouseCursor.transform.position = vWorld;


    }
}
