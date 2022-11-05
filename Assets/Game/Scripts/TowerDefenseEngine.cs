using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerDefenseEngine : MonoBehaviour
{
    private Tower[] towers;
    GridManager gridManager;
    WaveManager waveManager;
    // Start is called before the first frame update
    void Start()
    {
        gridManager = new GridManager();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
