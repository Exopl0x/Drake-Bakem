using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Cakes Stats", menuName = "Cake")]
public class CakeStats : ScriptableObject
{
    public float cookedHits; //how many times it has to be hit to be cooked
    public int damage;
    public Sprite cookedBread;
    public Sprite rawBread;
}
