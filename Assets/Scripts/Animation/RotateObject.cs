using DG.Tweening;
using UnityEngine;

namespace Animation
{
    public class RotateObject : MonoBehaviour
    {
        [Range(0,1)]
        [SerializeField] private float speed;
    
        void Start()
        {
            var rotation = this.transform.rotation;
            transform
                .DOLocalRotate(new (0,0, 360f), speed, RotateMode.FastBeyond360)
                .SetLoops(-1, LoopType.Incremental)
                .SetEase(Ease.Linear);
        }
    }
}
