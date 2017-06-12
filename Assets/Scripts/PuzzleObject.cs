using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PuzzleObject
{
   
    TypeObject typeOfObject;
    int posX;
    int posY;
    private TypeObject typeObject;
    private int p1;
    private int p2;


    public PuzzleObject(TypeObject t, int x, int y)
    {
        this.typeOfObject = t;
        this.posX = x;
        this.posY = y;
    }


    public TypeObject TypeOfObject
    {
        get { return typeOfObject; }
        set { typeOfObject = value; }
    }

   
    
    public int PosY
    {
        get { return posY; }
        set { posY = value; }
    }

    public int PosX
    {
        get { return posX; }
        set { posX = value; }
    }
}
