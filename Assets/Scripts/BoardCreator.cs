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

    bool autoCreate = false;

    void Start()
    {
        if (autoCreate)
        {
            CreatePortals();
            
            //
            //
            //
            //
        }
    }

    private void CreatePortals()
    {
        for (int i = 0; i < portals; i++)
        {
            int x = Random.Range(-8,7);
            int z = Random.Range(-8,7);
            
            var p = Instantiate(ghostPortal,new Vector3(x + .5f,0,z+.5f),Quaternion.identity);
            p.transform.parent = transform;
            p.GetComponent<GhostPortal>().SetType(1);
        }
    }

    // Update is called once per frame
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


}
