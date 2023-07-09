using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyScript : MonoBehaviour
{
    [SerializeField] float _destroyTime = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, _destroyTime);
    }
}
