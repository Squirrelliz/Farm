using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Data/_Item")]
public class _Item : ScriptableObject
{
    public string Name;
    public bool stackable;
    public Sprite icon;
    public ToolAction TYPEAXE;
    public ToolAction TYPEHOE;
    public ToolAction TYPESWORD;
    public ToolAction TYPESEED;
    public Sprite plant;
    public GameObject product;
    public float timeToGrow;
}
