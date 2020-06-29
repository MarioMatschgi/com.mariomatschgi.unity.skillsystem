using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillPanel : MonoBehaviour
{
    [Header("General")] 
    
    
    [Header("Outlets")]
    public GameObject cellPrefab;


    #region Callback Methodes
    /*
     *
     *  Callback Methodes
     * 
     */

    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
            Destroy(transform.GetChild(i));
        
        foreach (SkillType _skillType in Enum.GetValues(typeof(SkillType)))
            Instantiate(cellPrefab, transform).GetComponent<SkillCell>().Setup(_skillType);
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
