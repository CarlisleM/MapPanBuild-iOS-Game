using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GrassGame;

public class GridTracker : MonoBehaviour {
    
    public static int[,] tileLocation = new int[10, 10] {    // 10 Rows by 10 Columns
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,  
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,   
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
        {0, 0, 0, 0, 2, 2, 0, 0, 0, 0} ,
        {0, 0, 0, 0, 2, 2, 0, 0, 0, 0} ,
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
    };

    public static int GetEntityCount(Entities entity)
    {
        int count = 0;

        for (int i = 0; i < tileLocation.GetLength(0); i++)
        {
            for (int j = 0; j < tileLocation.GetLength(1); j++)
            {
                if (tileLocation[i, j] == (int) entity)
                {
                    count++;
                }
            }
        }

        return count;
    }

}
