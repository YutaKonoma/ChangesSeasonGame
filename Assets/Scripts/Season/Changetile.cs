using UnityEngine;
using UnityEngine.Tilemaps;

public enum Season
{
    spring,
    summer,
    autum,
    winter
}

public class ChangeTile : MonoBehaviour
{
    [Header("ベース")]
    [SerializeField]
    private Tilemap _tilemap;
    [SerializeField]
    private Tilemap _treemap;
    [SerializeField]
    private Tilemap _wotermap;

    [SerializeField]
    [Header("季節ごとのタイル")]
    private TileBase[] _seasonTile;

    [SerializeField]
    [Header("季節ごとの木")]
    private TileBase[] _treeTile;

    [SerializeField]
    [Header("水のタイル")]
    private TileBase _wotertile;

    [SerializeField]
    [Header("氷のタイル")]
    private TileBase _icetile;

    [SerializeField]
    [Header("季節ごとのスプライト")]
    private Sprite[] _seasonSprite;

    [SerializeField]
    [Header("季節ごとの木のスプライト")]
    private Sprite[] _treeSprite;

    [SerializeField]
    [Header("水のスプライト")]
    private Sprite _woterSprite;

    [SerializeField]
    [Header("氷のスプライト")]
    private Sprite _iceSprite;

    [SerializeField]
    [Header("水、氷のコライダー")]
    private TilemapCollider2D _woterCollider2D;

    [Tooltip("セルのポジション")]
    private Vector3Int _cellPos;

    Season _season;

    private void GetCellPos(Vector3Int pos) 
    {
        _cellPos = new Vector3Int(pos.x, pos.y, pos.z);
    }

    #region spring
    public void Spring()
    {
        _season = Season.spring;
        foreach (var pos in _tilemap.cellBounds.allPositionsWithin)
        {
            GetCellPos(pos);
            // tilemap.HasTileでタイルが設定(描画)されている座標であるか判定
            if (_tilemap.HasTile(_cellPos))
            {
                // スプライトが一致しているか判定をとる
                if (_tilemap.GetSprite(_cellPos) == _seasonSprite[1] || _tilemap.GetSprite(_cellPos) == _seasonSprite[2] || _tilemap.GetSprite(_cellPos) == _seasonSprite[3])
                {
                    // スプライトが一致している場合は別のタイルを設定する
                    _tilemap.SetTile(_cellPos, _seasonTile[0]);
                }
            }

            if (_treemap.HasTile(_cellPos))
            {
                if (_treemap.GetSprite(_cellPos) != _treeSprite[0])
                {
                    _treemap.SetTile(_cellPos, _treeTile[0]);
                }
            }

            CheckWoter();
        }
    }
    #endregion

    #region Summer
    public void Summer()
    {
        _season = Season.summer;
        foreach (var pos in _tilemap.cellBounds.allPositionsWithin)
        {
            GetCellPos(pos);
            if (_tilemap.HasTile(_cellPos))
            {
                if (_tilemap.GetSprite(_cellPos) == _seasonSprite[0] || _tilemap.GetSprite(_cellPos) == _seasonSprite[2] || _tilemap.GetSprite(_cellPos) == _seasonSprite[3])
                {
                    _tilemap.SetTile(_cellPos, _seasonTile[1]);
                }
            }

            if (_treemap.HasTile(_cellPos))
            {
                if (_treemap.GetSprite(_cellPos) != _treeSprite[1])
                {
                    _treemap.SetTile(_cellPos, _treeTile[1]);
                }
            }

            CheckWoter();
        }
    }
    #endregion

    #region Autumu
    public void Autumn()
    {
        _season = Season.autum;
        foreach (var pos in _tilemap.cellBounds.allPositionsWithin)
        {
            GetCellPos(pos);
            if (_tilemap.HasTile(_cellPos))
            {
                if (_tilemap.GetSprite(_cellPos) == _seasonSprite[0] || _tilemap.GetSprite(_cellPos) == _seasonSprite[1] || _tilemap.GetSprite(_cellPos) == _seasonSprite[3])
                {
                    _tilemap.SetTile(_cellPos, _seasonTile[2]);
                }
            }

            if (_treemap.HasTile(_cellPos))
            {
                if (_treemap.GetSprite(_cellPos) != _treeSprite[2])
                {
                    _treemap.SetTile(_cellPos, _treeTile[2]);
                }
            }

            CheckWoter();
        }
    }
    #endregion

    #region Winter
    public void Winter()
    {
        _season = Season.winter;
        foreach (var pos in _tilemap.cellBounds.allPositionsWithin)
        {
            GetCellPos(pos);
            if (_tilemap.HasTile(_cellPos))
            {
                if (_tilemap.GetSprite(_cellPos) == _seasonSprite[0] || _tilemap.GetSprite(_cellPos) == _seasonSprite[1] || _tilemap.GetSprite(_cellPos) == _seasonSprite[2])
                {
                    _tilemap.SetTile(_cellPos, _seasonTile[3]);
                }
            }

            if (_treemap.HasTile(_cellPos))
            {
                if (_treemap.GetSprite(_cellPos) != _treeSprite[3])
                {
                    _treemap.SetTile(_cellPos, _treeTile[3]);
                }
            }

            CheckWoter();
        }
    }
    #endregion

    #region Woter
    private void CheckWoter()
    {
        if (_wotermap.HasTile(_cellPos))
        {
            if (_wotermap.GetSprite(_cellPos) == _woterSprite && _season == Season.winter)
            {
                _woterCollider2D.enabled = true;
                _wotermap.SetTile(_cellPos, _icetile);
            }

            else if (_wotermap.GetSprite(_cellPos) == _iceSprite && _season != Season.winter)
            {
                _woterCollider2D.enabled = false;
                _wotermap.SetTile(_cellPos, _wotertile);
            }
        }
    }
    #endregion
}
