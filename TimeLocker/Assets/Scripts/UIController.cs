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
