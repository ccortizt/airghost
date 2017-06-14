using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardCreator : MonoBehaviour
{

    [SerializeField]
    GameObject ghostPortal;

    [SerializeField]
    GameObject mobileBox;

    //[SerializeField]
    //GameObject staticBox; gameObject.layer = 0; //getcomponent<MobileBoxController>().enable = false;

    [SerializeField]
    GameObject fearGhost;

    [SerializeField]
    GameObject rageGhost;

    [SerializeField]
    GameObject sadnessGhost;

    int portals = 3;
    int clearedPortals = 0;

    //bool autoCreate = false;

    float offset = 0.5f;

    List<PuzzleObject> puzzle;

    void Awake()
    {
        puzzle = new List<PuzzleObject>();

        puzzle.Add(new PuzzleObject(TypeObject.StaticBox, 0, 15));
        puzzle.Add(new PuzzleObject(TypeObject.StaticBox, 1, 13));
        puzzle.Add(new PuzzleObject(TypeObject.StaticBox, 2, 14));
        puzzle.Add(new PuzzleObject(TypeObject.StaticBox, 5, 5));
        puzzle.Add(new PuzzleObject(TypeObject.StaticBox, 14, 4));

        puzzle.Add(new PuzzleObject(TypeObject.MovileBox, 6, 15));
        puzzle.Add(new PuzzleObject(TypeObject.MovileBox, 7, 6));
        puzzle.Add(new PuzzleObject(TypeObject.MovileBox, 1, 3));
        puzzle.Add(new PuzzleObject(TypeObject.MovileBox, 5, 4));
        puzzle.Add(new PuzzleObject(TypeObject.MovileBox, 7, 4));

        puzzle.Add(new PuzzleObject(TypeObject.Portal, 15, 15));
        puzzle.Add(new PuzzleObject(TypeObject.Portal, 15, 4));
        puzzle.Add(new PuzzleObject(TypeObject.Portal, 2, 13));
        
    }
    void Start()
    {
        CreateStage(puzzle);
    }


    private void CreatePortals()
    {
        for (int i = 0; i < portals; i++)
        {
            int x = Random.Range(-8,7);
            int z = Random.Range(-8,7);
            
            var p = Instantiate(ghostPortal,new Vector3(x + offset,0,z+offset),Quaternion.identity);

            p.transform.parent = transform;
            p.GetComponent<GhostPortal>().SetType(1);
        }
    }

    void Update()
    {
        if (clearedPortals == portals)
        {
            Debug.Log("VICTORY");
        }
    }

    public void PlusClearedPortals()
    {
        clearedPortals++;
    }

    private void CreateStage(List<PuzzleObject> puzzle)
    {
        
        foreach(PuzzleObject o in puzzle){
            if (o.TypeOfObject == TypeObject.Portal)
            {
                GameObject p = (GameObject)Instantiate(ghostPortal, new Vector3(o.PosX + offset, -0.12f, o.PosY + offset), Quaternion.identity);
                p.transform.parent = transform;
                p.GetComponent<GhostPortal>().SetType(Random.Range(1,3));
                portals++;
            }

            if (o.TypeOfObject == TypeObject.MovileBox)
            {
                GameObject m = (GameObject)Instantiate(mobileBox, new Vector3(o.PosX + offset, offset, o.PosY + offset), Quaternion.identity);
                m.transform.parent = transform;
                m.GetComponent<MeshRenderer>().material.color = Color.red;

            }

            if (o.TypeOfObject == TypeObject.StaticBox)
            {
                GameObject m = (GameObject)Instantiate(mobileBox, new Vector3(o.PosX + offset, offset, o.PosY + offset), Quaternion.identity);
                m.transform.parent = transform;
                m.gameObject.layer = 0;
                m.GetComponent<MobileBoxController>().enabled = false;
                m.GetComponent<MeshRenderer>().material.color = Color.green;
            }


        }
        
            
    }


}
