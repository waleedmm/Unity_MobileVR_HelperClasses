using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Experiment_01.UI
{
    public class VRCameraMarkerHandler : MonoBehaviour
    {
        public Material m_DefaultMaterial,
            m_HighlightedMaterial;
        MeshRenderer m_Renderer;
        bool m_isHighLighted;
        Color m_StartingMaterialColor;
        // Use this for initialization
        void Start()
        {
            m_Renderer = GetComponent<MeshRenderer>();
            if (m_Renderer)
                m_StartingMaterialColor = m_Renderer.material.color;
        }
        public void SetHighLight(bool isHighLighted, Color NewColor)
        {
            m_isHighLighted = isHighLighted;
            if (m_Renderer)
            {
                m_Renderer.material = (isHighLighted) ? m_HighlightedMaterial : m_DefaultMaterial;
                SetMaterialColor(NewColor);
            }
        }
        public void SetMaterialColor(Color NewColor)
        {
            if (m_Renderer)
            {
                m_Renderer.material.color = NewColor;
            }
        }
        public void ResetHighLight()
        {
            SetHighLight(false, m_StartingMaterialColor);
        }
        // Update is called once per frame
        void Update()
        {

        }
    }
}