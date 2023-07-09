using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManagerScript : MonoBehaviour
{
    [SerializeField] int _woodCollected = 0;
    [SerializeField] TMP_Text _woodAmountText;
    [SerializeField] List<GameObject> _TreeSpawnLocations = new List<GameObject>();
    [SerializeField] List<bool> _TreeSpawnLocationsFull = new List<bool>();

    [SerializeField] GameObject _baseTreePrefab;

    int _occupiedSpawnLocations = 0;

    [SerializeField] float _treeSpawnTime = 5f;
    float _treeSpawnCtr = 0;
    [SerializeField] Color32 _purchasedPlotColour;
    [SerializeField] TMP_Text _SpawnTimeText;

    // Start is called before the first frame update
    void Start()
    {
        _woodAmountText.text = "Wood: " + _woodCollected.ToString();
    }
    public void CollectWood(int m_woodAmount)
    {
        _woodCollected += m_woodAmount;
        _woodAmountText.text = "Wood: " + _woodCollected.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        if(_occupiedSpawnLocations < _TreeSpawnLocations.Count)
        {
            _treeSpawnCtr += Time.deltaTime;
            _SpawnTimeText.text = "Next Tree:" + (_treeSpawnTime - _treeSpawnCtr).ToString("F2") +"s";
        }
        else
        {
            _SpawnTimeText.text = "Next Tree: FULL";

        }
        if (_treeSpawnCtr >= _treeSpawnTime && _occupiedSpawnLocations < _TreeSpawnLocations.Count)
        {

            TreeSpawn();
            _treeSpawnCtr = 0;

        }
    }
    public bool AddSpawnPoint(GameObject m_newSpawnPoint, int m_cost)
    {
        if(_woodCollected >= m_cost)
        {

            _TreeSpawnLocations.Add(m_newSpawnPoint);
            m_newSpawnPoint.GetComponent<SpriteRenderer>().color = _purchasedPlotColour;
            Destroy(m_newSpawnPoint.transform.GetChild(0).gameObject);
            _TreeSpawnLocationsFull.Add(false);
            CollectWood(-m_cost);
            return true;
        }
        return false;

    }

    void TreeSpawn()
    {
        bool m_canSpawn = false;
        int m_spawnPoint = Random.Range(0, _TreeSpawnLocations.Count);
        do
        {
            if (_TreeSpawnLocationsFull[m_spawnPoint] != true)
            {
               GameObject m_tree =  Instantiate(_baseTreePrefab, _TreeSpawnLocations[m_spawnPoint].transform.position, Quaternion.identity);
                m_tree.GetComponent<TreeScript>().SpawnTreeProperties(1, 100, 1, m_spawnPoint);
                 _occupiedSpawnLocations++;
                _TreeSpawnLocationsFull[m_spawnPoint] = true;
                m_canSpawn = true;
            }
            else
            {
                m_spawnPoint = Random.Range(0, _TreeSpawnLocations.Count);
            }

        } while (m_canSpawn == false);
    }
    public void TreeChopped(int m_spawnLocNum)
    {
        _occupiedSpawnLocations--;
        _TreeSpawnLocationsFull[m_spawnLocNum] = false;

    }
}
