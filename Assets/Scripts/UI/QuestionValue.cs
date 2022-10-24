using ScriptableObjects;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace UI
{
    public class QuestionValue : MonoBehaviour
    {

        [FormerlySerializedAs("floatValueBase")] [SerializeField] private FloatValue floatValue;
        [SerializeField] private TMP_InputField currentValueText;
        private bool _isFloatValueNull;

        private void Start() => _isFloatValueNull = floatValue == null;
    
        void Update() => SetValues();

        void SetValues()
        {
            if (_isFloatValueNull)
                return;

            if (currentValueText.text == "")
                return;
        
            floatValue.Value = float.Parse(currentValueText.text);
        }
    }
}
