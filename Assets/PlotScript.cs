using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlotScript : MonoBehaviour
{
    bool _purchased = false;
    [SerializeField] int _plotCost = 5;
    private void Start()
    {
        this.GetComponentInChildren<TMP_Text>().text = _plotCost.ToString();
    }
    private void OnMouseDown()
    {
        if(_purchased == false)
        {
            _purchased = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>().AddSpawnPoint(this.gameObject, _plotCost);
        }
    }
}
