using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    // Start is called before the first frame update
    CreepBase creepBase;
    GridManager gridManager;
    [SerializeField] GameObject gameManager;
    List<Creep> creeps = new List<Creep>();
    [SerializeField] List<WaveBase> waveBases;


    private void Awake()
    {
        gridManager = gameManager.GetComponent<GridManager>();
    }
    void Start()
    {
        //Invoke("spawnCreep", 10);
        //StartCoroutine(spawnWave(waveBases[0].CreepBases, 2));
        
    }
    public void spawnCreep()
    {
        Vector3 startPos = gridManager.StartCell.transform.position;
        creepBase = GameManager.Instance.Creep;
        Creep creep = new Creep(creepBase);
        creep.creepObj = Instantiate(creep._base.CreepModel, new Vector3(startPos.x, 0.5f, startPos.z), Quaternion.identity) as GameObject;
        creep.pos.x = startPos.x;
        creep.pos.y = startPos.z;
        creeps.Add(creep);
    }
    public void spawnCreep(CreepBase creepBase)
    {
        Vector3 startPos = gridManager.StartCell.transform.position;
        Creep creep = new Creep(creepBase);
        creep.creepObj = Instantiate(creep._base.CreepModel, new Vector3(startPos.x, 0.5f, startPos.z), Quaternion.identity) as GameObject;
        creep.pos.x = startPos.x;
        creep.pos.y = startPos.z;
        creeps.Add(creep);
    }
    public IEnumerator spawnWave(List<CreepBase> wave, float delay)
    {
        if (wave.Count > 0) {
            spawnCreep(wave[0]);
            wave.RemoveAt(0);
            yield return new WaitForSeconds(delay);
            yield return spawnWave(wave, delay);
        }
        else { yield return null; }
    }
    // Update is called once per frame
    void Update()
    {
        moveCreeps();
        
    }
    private void onLeak(Creep creep)
    {
        Destroy(creep.creepObj);
        
    }
    private void moveCreeps()
    {
        List<GameObject> cp = gridManager.creepPath;
        for (int i = 0; i < creeps.Count; i++)
        {
            Creep creep = creeps[i];
            Vector3 des = cp[creep.currentPath + 1].transform.position;
            Vector3 start = creep.creepObj.transform.position;
            des.y += .5f;
            if (start == des){
                if (creep.currentPath < cp.Count-2)
                {
                    creep.currentPath += 1;
                }
                else
                {
                    onLeak(creep);
                    creeps.Remove(creep);
                    break;
                }
            }
            Vector3 end = cp[creep.currentPath + 1].transform.position;
            end.y += .5f;
            float moveSpeed = creep.MoveSpeed/1000;
            creep.creepObj.transform.position = Vector3.MoveTowards(start, end, moveSpeed);
        }
    }
    public List<WaveBase> WaveBases
    {
        get { return waveBases; }
    }
}
