using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    public ActorStats ActorStats;

    public string state;
    public int HP;
    public int currentHP;
    public float baseSpeed;
    public float sprintModifier;
}
