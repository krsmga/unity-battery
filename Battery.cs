/**
 * @author Kleber Ribeiro da Silva
 * @email krsmga@gmail.com
 * @create date 2020-06-15 18:41:27
 * @modify date 2020-06-16 18:51:43
 * @desc This class provides resources for implementing an interface that shows the device's battery level and status.
 * @github https://github.com/krsmga
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This class provides resources for implementing an interface that shows the device's battery level and status.
/// </summary>
/// <remarks>
/// <param name="batteryImage">Attach an Image component to the battery image.</param>
/// <param name="fillLevelImage">Attach an Image component to work as a battery level.</param>
///
/// For the colors we have 3 color levels, Normal, Attention and Alert.
/// In tests you can use to test the feature with the Editor running.
/// </remarks>
public class Battery : MonoBehaviour
{
    [SerializeField] private Image batteryImage = default;
    [SerializeField] private Image fillLevelImage = default;
    [Header("Colors")]
    [SerializeField] private Color normalLevel = new Color(255f,255f,255f);
    [SerializeField] private Color attentionLevel = new Color(255f,255f,255f);
    [SerializeField] private Color alertLevel = new Color(255f,255f,255f);

    [Header("Tests")]
    [Range(0f,1f)]
    [SerializeField] private float levelTest = 1;
    [SerializeField] private bool chargingTest = false;

    private float _batteryLevel; 
    
    /// <summary>
    /// Shows the battery level
    /// </summary>
    /// <remarks>
    /// In editor mode it returns the test value
    /// </remarks>
    /// <returns>
    /// (float) -> _batteryLevel
    /// </returns>
    public float batteryLevel
    {
        get
        {
            return _batteryLevel;
        }

        set
        {
            if (_batteryLevel == value && _batteryLevel == levelTest) 
            {
                return;
            }

            #if UNITY_EDITOR
                _batteryLevel = levelTest;
            #else
                _batteryLevel = value;
            #endif
        }
    }

    void Start()
    {
        if (batteryImage != null && fillLevelImage != null)
        {
            InvokeRepeating("BatteryUpdate", 0f, 1f);
        }
    }

    private void BatteryUpdate()
    {
        batteryLevel = SystemInfo.batteryLevel;

        if ((SystemInfo.batteryStatus == BatteryStatus.Unknown || SystemInfo.batteryStatus == BatteryStatus.Discharging) && !chargingTest)
        {
            fillLevelImage.fillAmount = batteryLevel;
        }
        else if (SystemInfo.batteryStatus == BatteryStatus.Charging || chargingTest)
        {
            if (fillLevelImage.fillAmount >= 1)
            {
                fillLevelImage.fillAmount = 0;
            }
            fillLevelImage.fillAmount += 0.1f;
        }

        if (batteryLevel >= 0.6f || SystemInfo.batteryStatus == BatteryStatus.Charging || chargingTest)
        {
            batteryImage.color = normalLevel;
            fillLevelImage.color = normalLevel;
        }
        else if (batteryLevel < 0.6f && batteryLevel >= 0.20f)
        {
            batteryImage.color = attentionLevel;
            fillLevelImage.color = attentionLevel;           
        }
        else
        {
            batteryImage.color = alertLevel;
            fillLevelImage.color = alertLevel;  
        }
    }
}