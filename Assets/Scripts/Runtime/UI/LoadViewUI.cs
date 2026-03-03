using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class LoadViewUI : MonoBehaviour
{
    [SerializeField] private Image _loadingIcon;

    private Tween _rotateTween;

    private void OnEnable()
    {
        StartRotation();
    }

    private void OnDisable()
    {
        _rotateTween?.Kill();
    }

    private void StartRotation()
    {
        _rotateTween = _loadingIcon.rectTransform
            .DORotate(new Vector3(0, 0, -360f), 1f, RotateMode.FastBeyond360)
            .SetEase(Ease.Linear)
            .SetLoops(-1, LoopType.Restart);
    }
}
