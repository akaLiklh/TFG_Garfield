using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int totalPoints;
    public int TotalPoints { get { return totalPoints; } }
      
 
    public void AddPoints(int pointToAdd)
    {
        totalPoints += pointToAdd;
        Debug.Log(totalPoints);
    }
}
