using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlotScript : MonoBehaviour
{
    bool _purchased = false;
    [SerializeField] int _plotCost = 5;
    GameObject _descriptor;
    bool _isUp = false;
    private void Start()
    {
        this.GetComponentInChildren<TMP_Text>().text = _plotCost.ToString();
        _descriptor= GameObject.FindGameObjectWithTag("Description");

    }
    private void OnMouseDown()
    {
        if (_purchased == false)
        {
            _purchased = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>().AddSpawnPoint(this.gameObject, _plotCost);
            if (_isUp)
            {
                _descriptor.GetComponent<Animator>().SetTrigger("Down");
                _isUp = false;

            }

        }
    }
    private void OnMouseOver()
    {
        if (_purchased == false)
        {
            if (_isUp == false)
            {
                _descriptor.GetComponent<Animator>().SetTrigger("Up");
                _isUp = true;
            }


            _descriptor.GetComponentInChildren<TMP_Text>().text = "Buy a plot of land to grow more trees for " + _plotCost.ToString() + " wood?";
        }
    }
    private void OnMouseExit()
    {
        if (_purchased == false)
        {
            if (_isUp)
            {
                _descriptor.GetComponent<Animator>().SetTrigger("Down");
                _isUp = false;

            }
        }
    }
}
