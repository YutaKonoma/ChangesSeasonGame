using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSeason : MonoBehaviour
{
    [SerializeField]
    [Header("全体の画像")]
    private GameObject _image;

    [SerializeField]
    [Header("季節4つの画像")]
    private Image[] _seasonImag;

    public void SeasonChange()
    {
        _image.transform.DOMove(new Vector2(900, 500), 1);
        Debug.Log("dotween");
    }
}
