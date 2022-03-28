using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{

    public GameObject EndView;


    public void HideEndView()
    {
        EndView.SetActive(false);
    }

    internal void ShowEndView()
    {
        EndView.SetActive(true);
    }
}
