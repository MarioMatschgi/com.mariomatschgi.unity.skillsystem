using System;
using System.Collections;
using System.Collections.Generic;
using MM.Attributes;
using UnityEngine;

public class SkillCanvas : MonoBehaviour
{


    #region Callback Methodes
    /*
     *
     *  Callback Methodes
     * 
     */

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    #endregion

    #region Gameplay Methodes
    /*
     *
     *  Gameplay Methodes
     *
     */

    #endregion

    #region Helper Methodes
    /*
     *
     *  Helper Methodes
     * 
     */

    #endregion
}

public enum SkillType
{
    [StringValue("None")]
    None,
    [StringValue("Crafting")]
    Crafting,
    [StringValue("Building")]
    Building,
    [StringValue("Foraging")]
    Foraging,
    [StringValue("Farming")]
    Farming,
    [StringValue("Hunting")]
    Hunting,
    [StringValue("Experience")]
    Experience,
}
