using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gridTracker : MonoBehaviour {

    private Vector2 pos;
    private Vector2 spawnPos;

    public static int[,] tileLocation = new int[10, 10] {    // 10 Rows by 10 Columns
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,  
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,   
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
        {0, 0, 0, 0, 1, 1, 0, 0, 0, 0} ,
        {0, 0, 0, 0, 1, 1, 0, 0, 0, 0} ,
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ,
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
    };

}
