using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayer : MonoBehaviour
{
    [SerializeField] int number;
    // Start is called before the first frame update
    private void Start()
    {
        transform.position = FindObjectOfType<GameManager>().GetComponent<GameManager>().GetPlayerPos(number);
    }
}
