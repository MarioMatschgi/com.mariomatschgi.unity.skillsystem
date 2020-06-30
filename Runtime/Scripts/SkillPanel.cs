using System;
using System.Collections;
using System.Collections.Generic;
using MM.Libraries.UI;
using UnityEngine;

[ExecuteAlways]
[RequireComponent(typeof(PrefabListPanel))]
public class SkillPanel : MonoBehaviour
{
    // [Header("General")] 
    //
    //
    // [Header("Outlets")]


    #region Callback Methodes
    /*
     *
     *  Callback Methodes
     * 
     */

    void Start()
    {
        GetComponent<PrefabListPanel>().amount = Enum.GetValues(typeof(SkillType)).Length - 1;

        if (!Application.isPlaying)    // BC: ExecuteAllways
            return;

        // for (int i = 0; i < transform.childCount; i++)
        //     Destroy(transform.GetChild(i));
        //
        // foreach (SkillType _skillType in Enum.GetValues(typeof(SkillType)))
        //     Instantiate(cellPrefab, transform).GetComponent<SkillCell>().Setup(_skillType);
    }

    void OnEnable()
    {
        GetComponent<PrefabListPanel>().OnStartSetup += OnStartSetup;
        
        if (!Application.isPlaying)    // BC: ExecuteAllways
            return;
    }

    void OnDisable()
    {
        GetComponent<PrefabListPanel>().OnStartSetup -= OnStartSetup;
        
        if (!Application.isPlaying)    // BC: ExecuteAllways
            return;
    }

    void OnStartSetup(IPrefabListChild[] _children)
    {
        for (int i = 0; i < _children.Length; i++)
            ((SkillCell) _children[i]).SetupVariables((SkillType)(i + 1));
    }

    void Update()
    {
        if (!Application.isPlaying)    // BC: ExecuteAllways
            return;
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
