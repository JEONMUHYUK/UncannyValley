using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI DeadLogo1;
    [SerializeField] TextMeshProUGUI DeadLogo2;

    public void ShowDeadLogo(string name)
    {
        DeadLogo1.gameObject.SetActive(true);
        DeadLogo2.gameObject.SetActive(true);

        DeadLogo1.text = name;
    }

}