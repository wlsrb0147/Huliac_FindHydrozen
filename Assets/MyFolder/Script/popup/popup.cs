using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class popup : MonoBehaviour
{
    private RectTransform rectTransform;
    private Vector2 originalPosition;
    [SerializeField] private Image image;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        originalPosition = rectTransform.anchoredPosition;
        gameObject.SetActive(false);
    }
    
    private void OnEnable()
    {
        rectTransform.DOAnchorPos(Vector2.zero, 0.5f).SetEase(Ease.OutSine);
    }

    public void DisableObject()
    {
        rectTransform.DOAnchorPos(originalPosition, 0.5f) // 0.5초 동안 애니메이션 실행
            .SetEase(Ease.InSine)                         // Ease 설정
            .OnComplete(() =>                            // 애니메이션 완료 후 실행
            {
                gameObject.SetActive(false);             // GameObject 비활성화
            });
    }

    private void OnDisable()
    {
        rectTransform.anchoredPosition = originalPosition;
    }

    public void SetImage(Sprite sprite)
    {
        image.sprite = sprite;
    }
}
