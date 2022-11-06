using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Changetile : MonoBehaviour
{
    [Header("ベース")]
    [SerializeField] private Tilemap _Tilemap; 
    [SerializeField] private Tilemap _Treemap; 
    [SerializeField] private Tilemap _Wotermap;

    [Header("季節ごとのタイル")]
    [SerializeField] private TileBase _springtile;
    [SerializeField] private TileBase _summertile; 
    [SerializeField] private TileBase _autumntile;
    [SerializeField] private TileBase _wintertile;

    [Header("季節ごとの木")]
    [SerializeField] private TileBase _springtreetile; 
    [SerializeField] private TileBase _summertreetile; 
    [SerializeField] private TileBase _autumntreetile; 
    [SerializeField] private TileBase _wintertreetile;

    [Header("水のタイル")]
    [SerializeField] private TileBase _wotertile;　

    [Header("氷のタイル")]
    [SerializeField] private TileBase _icetile; 

    [Header("季節ごとのスプライト")]
    [SerializeField] private Sprite _springsprite;
    [SerializeField] private Sprite _summersprite; 
    [SerializeField] private Sprite _autumnsprite; 
    [SerializeField] private Sprite _wintersprite;

    [Header("季節ごとの木のスプライト")]
    [SerializeField] private Sprite _springtreesprite;
    [SerializeField] private Sprite _summertreesprite;
    [SerializeField] private Sprite _autumntreesprite; 
    [SerializeField] private Sprite _wintertreesprite;

    [Header("水のスプライト")]
    [SerializeField] private Sprite _wotersprite;
    
    [Header("氷のスプライト")]
    [SerializeField] private Sprite _icesprite;　

    [SerializeField] private TilemapCollider2D _woterCollider2D;

    public Changetile(TilemapCollider2D woterCollider2D)
    {
        _woterCollider2D = woterCollider2D;
    }

    public void Spring()
    {
        foreach (var pos in _Tilemap.cellBounds.allPositionsWithin)
        {
            // 取り出した位置情報からタイルマップ用の位置情報(セル座標)を取得
            Vector3Int cellPosition = new Vector3Int(pos.x, pos.y, pos.z);

            // tilemap.HasTile -> タイルが設定(描画)されている座標であるか判定
            if (_Tilemap.HasTile(cellPosition))
            {
                // スプライトが一致しているか判定
                if (_Tilemap.GetSprite(cellPosition) == _summersprite || _Tilemap.GetSprite(cellPosition) == _autumnsprite || _Tilemap.GetSprite(cellPosition) == _wintersprite)
                {
                    // 特定のスプライトと一致している場合は別のタイルを設定する
                    _Tilemap.SetTile(cellPosition, _springtile);
                }
            }
            if (_Treemap.HasTile(cellPosition))
            {
                if (_Treemap.GetSprite(cellPosition) == _summertreesprite || _Tilemap.GetSprite(cellPosition) == _autumntreesprite || _Tilemap.GetSprite(cellPosition) == _wintertreesprite)
                {
                    Debug.Log("Spring");
                    _Treemap.SetTile(cellPosition, _springtreetile);
                }
            }
            if (_Wotermap.HasTile(cellPosition))
            {
                if (_Wotermap.GetSprite(cellPosition) == _icesprite)
                {
                    _woterCollider2D.enabled = false;
                    _Wotermap.SetTile(cellPosition, _wotertile);
                }
            }
        }
    }
    public void Summer()
    {
        foreach(var pos in _Tilemap.cellBounds.allPositionsWithin)
        {           
            Vector3Int cellPosition = new Vector3Int(pos.x, pos.y, pos.z);
            
            if (_Tilemap.HasTile(cellPosition))
            {
                if (_Tilemap.GetSprite(cellPosition) == _springsprite || _Tilemap.GetSprite(cellPosition) == _autumnsprite || _Tilemap.GetSprite(cellPosition) == _wintersprite)
                {
                    _Tilemap.SetTile(cellPosition, _summertile);
                }
            }
            if (_Treemap.HasTile(cellPosition))
            {
                if (_Treemap.GetSprite(cellPosition) == _springtreesprite || _Tilemap.GetSprite(cellPosition) == _autumntreesprite || _Tilemap.GetSprite(cellPosition) == _wintertreesprite)
                {
                    Debug.Log("Summer");
                    _Treemap.SetTile(cellPosition, _summertreetile);
                }
            }
            if (_Wotermap.HasTile(cellPosition))
            {
                if (_Wotermap.GetSprite(cellPosition) == _icesprite)
                {
                    _woterCollider2D.enabled = false;
                    _Wotermap.SetTile(cellPosition, _wotertile);
                }
            }
        }
    }
    public void Autumn()
    {
        foreach (var pos in _Tilemap.cellBounds.allPositionsWithin)
        {       
            Vector3Int cellPosition = new Vector3Int(pos.x, pos.y, pos.z);

            if (_Tilemap.HasTile(cellPosition))
            {
                if (_Tilemap.GetSprite(cellPosition) == _springsprite || _Tilemap.GetSprite(cellPosition) == _summersprite || _Tilemap.GetSprite(cellPosition) == _wintersprite)
                {
                    _Tilemap.SetTile(cellPosition, _autumntile);
                }
            }
            if (_Treemap.HasTile(cellPosition))
            {
                if (_Treemap.GetSprite(cellPosition) == _springtreesprite || _Tilemap.GetSprite(cellPosition) == _summertreesprite || _Tilemap.GetSprite(cellPosition) == _wintertreesprite)
                {
                    _Treemap.SetTile(cellPosition, _autumntreetile);
                    Debug.Log("Autumn");
                }
            }
            if (_Wotermap.HasTile(cellPosition))
            {
                if (_Wotermap.GetSprite(cellPosition) == _icesprite)
                {
                    _woterCollider2D.enabled = false;
                    _Wotermap.SetTile(cellPosition, _wotertile);
                }
            }
        }
    }
    public void Winter()
    {
        foreach (var pos in _Tilemap.cellBounds.allPositionsWithin)
        {
            Vector3Int cellPosition = new Vector3Int(pos.x, pos.y, pos.z);

            if (_Tilemap.HasTile(cellPosition))
            {
                if (_Tilemap.GetSprite(cellPosition) == _springsprite || _Tilemap.GetSprite(cellPosition) == _summersprite || _Tilemap.GetSprite(cellPosition) == _autumnsprite)
                {
                    _Tilemap.SetTile(cellPosition, _wintertile);
                }
            }
            if (_Treemap.HasTile(cellPosition))
            {
                if (_Treemap.GetSprite(cellPosition) == _springtreesprite || _Tilemap.GetSprite(cellPosition) == _summertreesprite || _Tilemap.GetSprite(cellPosition) == _autumntreesprite)
                {
                    Debug.Log("Winter");
                    _Treemap.SetTile(cellPosition, _wintertreetile);
                }
            }

            if (_Wotermap.HasTile(cellPosition))
            {
                if (_Wotermap.GetSprite(cellPosition) == _wotersprite )
                {
                    _woterCollider2D.enabled = true;
                    _Wotermap.SetTile(cellPosition, _icetile);
                }
            }
        }
    }
}
