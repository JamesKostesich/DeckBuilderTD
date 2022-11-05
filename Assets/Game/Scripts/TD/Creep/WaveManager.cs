using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    // Start is called before the first frame update
    CreepBase creepBase;
    Creep creep;
    GridManager gridManager;
    [SerializeField] GameObject gameManager;

    private void Awake()
    {
        gridManager = gameManager.GetComponent<GridManager>();
        
    }
    void Start()
    {
        Invoke("spawnCreep", 10);
        
    }
    public void spawnCreep()
    {
        Vector3 startPos = gridManager.startCell.transform.position;
        creepBase = GameManager.Instance.Creep;
        creep = new Creep(creepBase);
        creep.creepObj = Instantiate(creep._base.CreepModel, new Vector3(startPos.x, 0.5f, startPos.z), Quaternion.identity) as GameObject;
        creep.pos.x = startPos.x;
        creep.pos.y = startPos.z;
    }

    // Update is called once per frame
    void Update()
    {
        moveCreeps();
        
    }
    private void moveCreeps()
    {
        if (creep.shouldMove())
        {
            int x = (int)creep.pos.x;
            int y = (int)creep.pos.y;
            print(creep.moveDir);
            if (gridManager.grid[x+1, y].tag == "path")
            {
                creep.creepObj.transform.Translate(1, 0, 0);
                creep.pos.x += 1;
                print("go forward");
                creep.moveDir = "forward";
            }
            if(gridManager.grid[x, y - 1].tag == "path")
            {
                if (creep.moveDir == "down")
                {
                    creep.creepObj.transform.Translate(0, 0, -1);
                    creep.pos.y -= 1;
                    print("go down" + gridManager.grid[x, y - 1].tag);
                }
                if (creep.moveDir == "forward")
                {
                    creep.moveDir = "down";
                }

            }
            if (gridManager.grid[x, y + 1].tag == "path")
            {
                if (creep.moveDir == "up")
                {
                    creep.creepObj.transform.Translate(0, 0, 1);
                    creep.pos.y += 1;
                    print("go up");
                }
                if (creep.moveDir == "forward")
                {
                    creep.moveDir = "up";
                }
            }
        }
    }
}
