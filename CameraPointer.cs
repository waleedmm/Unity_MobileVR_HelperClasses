/*this is a modified version of the google cardboard class (CameraPointer.cs)
 * located at path: Assets\Samples\Google Cardboard XR Plugin for Unity\[Version]\Hello Cardboard\Scripts
 */


//-----------------------------------------------------------------------
// <copyright file="CameraPointer.cs" company="Google LLC">
// Copyright 2020 Google LLC
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
//-----------------------------------------------------------------------

using Assets.Scripts.Experiment_01.UI;
using System.Collections;
using UnityEngine;

/// <summary>
/// Sends messages to gazed GameObject.
/// </summary>
public class CameraPointer : MonoBehaviour
{
    public float _maxDistance = 100;
    private GameObject _gazedAtObject = null;
    public string m_TargetTag="VRTarget";
    public bool m_HighLightHitPoint, m_AligningLightMarkerWithNormal = false;
    public VRCameraMarkerHandler m_HitPointMarker;
    public Color m_MarkerHighLightColor = Color.green;
    private void Start()
    {
        //waleed https://docs.unity3d.com/ScriptReference/Screen-sleepTimeout.html
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }
    /// <summary>
    /// Update is called once per frame.
    /// </summary>
    public void Update()
    {
        // Casts ray towards camera's forward direction, to detect if a GameObject is being gazed
        // at.
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, _maxDistance))
        {
            if (m_HighLightHitPoint && m_HitPointMarker)
            {
                m_HitPointMarker.gameObject.SetActive(true);
                m_HitPointMarker.transform.position = hit.point;
                if(m_AligningLightMarkerWithNormal)
                    m_HitPointMarker.transform.up = hit.normal;

                //highlight marker if needed
                if (hit.transform.gameObject.tag == m_TargetTag)
                {
                    m_HitPointMarker.SetHighLight(true, m_MarkerHighLightColor);
                }
                else
                    m_HitPointMarker.ResetHighLight();
            }
            // GameObject detected in front of the camera.
            if (hit.transform.gameObject.tag == m_TargetTag )
            {
                if(_gazedAtObject != hit.transform.gameObject)
                    SelectObject(hit);

            }
            else
            {
                UnSelect();
            }
        }
        else
        {

            UnSelect();

            if (m_HighLightHitPoint && m_HitPointMarker)
            {
                m_HitPointMarker.gameObject.SetActive(false);
            }
        }

        // Checks for screen touches.
        if (Google.XR.Cardboard.Api.IsTriggerPressed)
        {
            if (_gazedAtObject != null)
            {
                _gazedAtObject?.SendMessage("OnPointerClick");
            }
        }
    }

    private void SelectObject(RaycastHit hit)
    {
        //old objects
        _gazedAtObject?.SendMessage("OnPointerExit");
        // New GameObject.   
        _gazedAtObject = hit.transform.gameObject;

        _gazedAtObject.SendMessage("OnPointerEnter");
    }

    private void UnSelect()
    {
        if (_gazedAtObject != null)
        {// No GameObject detected in front of the camera.
            _gazedAtObject?.SendMessage("OnPointerExit");
            _gazedAtObject = null;
        }
    }
}
