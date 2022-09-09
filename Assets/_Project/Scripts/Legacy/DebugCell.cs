using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Legacy
{
    public class DebugCell : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI infoText;
        [SerializeField] private MeshRenderer meshRenderer;

        void Start()
        {
            meshRenderer.material = meshRenderer.material;
        }

        public void SetColor(Color color)
        {
            meshRenderer.material.color = color;
        }

        public void SetInfo(int step, float distance, float weight)
        {
            infoText.text = $"Step: {step}\nDistance: {distance}\nWeight: {weight}";
        }
    }
}
