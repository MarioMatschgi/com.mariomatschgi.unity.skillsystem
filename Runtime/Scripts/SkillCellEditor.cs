#if UNITY_EDITOR

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CanEditMultipleObjects]
[CustomEditor(typeof(SkillCell))]
public class SkillCellEditor : Editor
{
    SkillCell skillCell;


    #region Callback Methodes
    /*
     *
     *  Callback Methodes
     * 
     */

    void Awake()
    {
        skillCell = (SkillCell)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        skillCell.UpdateCell();
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

#endif