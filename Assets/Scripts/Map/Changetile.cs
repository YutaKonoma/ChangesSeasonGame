using UnityEngine;
using UnityEngine.Tilemaps;

public class Changetile : MonoBehaviour
{
    [Header("ベース")]
    [SerializeField] private Tilemap _tilemap;
    [SerializeField] private Tilemap _treemap;
    [SerializeField] private Tilemap _wotermap;

    [Header("季節ごとのタイル")]
    [SerializeField] private TileBase _springtile;
    [SerializeField] private TileBase _summertile;
    [SerializeField] private TileBase _autumntile;
    [SerializeField] private TileBase _wintertile;

    [Header("季節ごとの木")]
    [SerializeField]
    private TileBase[] _treeTile;

    [Header("水のタイル")]
    [SerializeField]
    private TileBase _wotertile;

    [Header("氷のタイル")]
    [SerializeField]
    private TileBase _icetile;

    [Header("季節ごとのスプライト")]
    [SerializeField]
    private Sprite[] _seasonSprite;

    [Header("季節ごとの木のスプライト")]
    [SerializeField]
    private Sprite[] _treeSprite;

    [SerializeField]
    [Header("水のスプライト")]
    private Sprite _woterSprite;

    [SerializeField]
    [Header("氷のスプライト")]
    private Sprite _iceSprite;

    [SerializeField]
    private TilemapCollider2D _woterCollider2D;

    [SerializeField]
    [Header("セルのポジション")]
    private Vector3Int _cellPos;

    void GetCellPos(Vector3Int pos)
    {
        _cellPos = new Vector3Int(pos.x, pos.y, pos.z);
    }

    public void Spring()
    {
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
                    _tilemap.SetTile(_cellPos, _springtile);
                }
            }

            if (_treemap.HasTile(_cellPos))
            {
                if (_treemap.GetSprite(_cellPos) != _treeSprite[0])
                {
                    Debug.Log("Spring");
                    _treemap.SetTile(_cellPos, _treeTile[0]);
                }
            }
            CheckWoter();
        }
    }

    public void Summer()
    {
        foreach (var pos in _tilemap.cellBounds.allPositionsWithin)
        {
            GetCellPos(pos);
            if (_tilemap.HasTile(_cellPos))
            {
                if (_tilemap.GetSprite(_cellPos) == _seasonSprite[0] || _tilemap.GetSprite(_cellPos) == _seasonSprite[2] || _tilemap.GetSprite(_cellPos) == _seasonSprite[3])
                {
                    _tilemap.SetTile(_cellPos, _summertile);
                }
            }
            if (_treemap.HasTile(_cellPos))
            {
                if (_treemap.GetSprite(_cellPos) != _treeSprite[1])
                {
                    Debug.Log("Summer");
                    _treemap.SetTile(_cellPos, _treeTile[1]);
                }
            }
            CheckWoter();
        }
    }

    public void Autumn()
    {
        foreach (var pos in _tilemap.cellBounds.allPositionsWithin)
        {
            GetCellPos(pos);
            if (_tilemap.HasTile(_cellPos))
            {
                if (_tilemap.GetSprite(_cellPos) == _seasonSprite[0] || _tilemap.GetSprite(_cellPos) == _seasonSprite[1] || _tilemap.GetSprite(_cellPos) == _seasonSprite[3])
                {
                    _tilemap.SetTile(_cellPos, _autumntile);
                }
            }
            if (_treemap.HasTile(_cellPos))
            {
                if (_treemap.GetSprite(_cellPos) != _treeSprite[2])
                {
                    _treemap.SetTile(_cellPos, _treeTile[2]);
                    Debug.Log("Autumn");
                }
            }
            CheckWoter();
        }
    }
    public void Winter()
    {
        foreach (var pos in _tilemap.cellBounds.allPositionsWithin)
        {
            GetCellPos(pos);
            if (_tilemap.HasTile(_cellPos))
            {
                if (_tilemap.GetSprite(_cellPos) == _seasonSprite[0] || _treemap.GetSprite(_cellPos) == _seasonSprite[1] || _tilemap.GetSprite(_cellPos) == _seasonSprite[2])
                {
                    _tilemap.SetTile(_cellPos, _wintertile);
                }
            }
            if (_treemap.HasTile(_cellPos))
            {
                if (_treemap.GetSprite(_cellPos) != _treeSprite[3])
                {
                    Debug.Log("Winter");
                    _treemap.SetTile(_cellPos, _treeTile[3]);
                }
            }

            CheckWoter();
        }
    }

    public void CheckWoter()
    {
        if (_wotermap.HasTile(_cellPos))
        {
            if (_wotermap.GetSprite(_cellPos) == _woterSprite)
            {
                _woterCollider2D.enabled = true;
                _wotermap.SetTile(_cellPos, _icetile);
            }

            else if (_wotermap.GetSprite(_cellPos) == _iceSprite)
            {
                _woterCollider2D.enabled = false;
                _wotermap.SetTile(_cellPos, _wotertile);
            }
        }
    }
}
