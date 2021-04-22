using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveButtonAppearing : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Button;

    public void OnSettingsChange()
    {
        Button.SetActive(true);
    }
    public void OnButtonClick()
    {
        Button.SetActive(false);
    }
}