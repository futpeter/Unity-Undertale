using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI bodyText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActTopLeftBtn()
    {
        bodyText.text = "Enemy thingy1";
    }
    public void ActMidLeftBtn()
    {
        bodyText.text = "Enemy thingy2";
    }
    public void ActLowLeftBtn()
    {
        bodyText.text = "Enemy thingy3";
    }
    public void ActTopRightBtn()
    {
        bodyText.text = "Enemy thingy4";
    }
    public void ActMidRightBtn()
    {
        bodyText.text = "Enemy thingy5";
    }
    public void ActLowRightBtn()
    {
        bodyText.text = "Enemy thingy6";
    }
}
