using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpdateUI : MonoBehaviour
{

    public TextMeshProUGUI text;

    private int num;

    private IntPtr _invoke;
    
    // Start is called before the first frame update
    void Start()
    {
        _invoke = CppInterface.GenerateInvoke();
        
        StartCoroutine(UpdateNumber());
        
        CppInterface.ReleaseInvoke(_invoke);
        
    }

    IEnumerator UpdateNumber()
    {
        text.text = num.ToString();
        // num = _invoke.
         yield return new WaitForSeconds(2f);
        
        
    }
    
    // Update is called once per frame
    void Update()
    {
       
    }
}
