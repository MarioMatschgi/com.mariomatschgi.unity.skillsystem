using System.Collections;
using System.Collections.Generic;
using MM.Extentions;
using UnityEngine;
using MM.Libraries.UI;
using TMPro;
using UnityEngine.UI;

public class SkillCell : MonoBehaviour, IPrefabListChild
{
    [Header("General")]
    public SkillType skillType;

    [Header("Formatting")]
    public string nameTextFormat = "{name}";
    public string levelTextFormat = "Level: {cur}/{max}";
    
    [Header("Outlets")]
    public TMP_Text nameText;
    public TMP_Text levelText;
    public Slider slider;


    #region Callback Methodes
    /*
     *
     *  Callback Methodes
     * 
     */

    public void Setup()
    {
        UpdateCell();
    }

    public void SetupVariables(SkillType _skillType)
    {
        skillType = _skillType;
    }
    
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

    public void UpdateCell()
    {
        nameText.text = nameTextFormat.Replace("{name}", skillType.GetStringValue());
        levelText.text = levelTextFormat.Replace("{cur}", "1").Replace("{max}", "10");    // ToDo: Load stats
        slider.value = .43f;    // ToDo: Load stats
    }

    #endregion

    #region Helper Methodes
    /*
     *
     *  Helper Methodes
     * 
     */

    #endregion
}
