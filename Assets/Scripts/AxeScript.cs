using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeScript : MonoBehaviour
{
    GameObject _axeObj;
    bool _canSwing = false;
    [SerializeField] Animator _axeAnimator;
    bool SwingingNow = false;
    GameObject _currentTree = null;
    [SerializeField] int _axeDmg = 10;
    [SerializeField] GameObject _slashParticlePrefab;
    [SerializeField] Transform _slashSpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        _axeObj = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            SWING();
        }
        if (Input.GetMouseButtonUp(0))
        {
            CanSwing(false);
        }
    }
    public void SWING()
    {
        if (_canSwing && SwingingNow == false && _currentTree.gameObject != null)
        {
            //start animation
            _axeAnimator.SetTrigger("AxeSwing");
            SwingingNow = true;
        }
    }
    public void AxeSwung()
    {
        Debug.Log("got wood");
        SwingingNow = false;
        _currentTree.GetComponent<TreeScript>().DamageTree(_axeDmg);
        Instantiate(_slashParticlePrefab, _slashSpawnPoint.position, _slashParticlePrefab.transform.rotation);

    }
    public void CanSwing(bool m_canSwing) //am i allowed to swing (sent from tree)
    {
        _canSwing = m_canSwing;
        if (_canSwing == false && SwingingNow == true)
        {
            _axeAnimator.SetTrigger("StopAxe");
            SwingingNow = false;

        }
    }
    public void TreeSelected(GameObject m_tree)
    {
        _currentTree = m_tree;
    }
}
