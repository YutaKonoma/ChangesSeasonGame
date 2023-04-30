using UnityEngine;
using UnityEngine.Tilemaps;

public class Changetile : MonoBehaviour
{
    [Header("�x�[�X")]
    [SerializeField] private Tilemap _tilemap;
    [SerializeField] private Tilemap _treemap;
    [SerializeField] private Tilemap _wotermap;

    [Header("�G�߂��Ƃ̃^�C��")]
    [SerializeField] private TileBase _springtile;
    [SerializeField] private TileBase _summertile;
    [SerializeField] private TileBase _autumntile;
    [SerializeField] private TileBase _wintertile;

    [Header("�G�߂��Ƃ̖�")]
    [SerializeField]
    private TileBase[] _treeTile;

    [Header("���̃^�C��")]
    [SerializeField]
    private TileBase _wotertile;

    [Header("�X�̃^�C��")]
    [SerializeField]
    private TileBase _icetile;

    [Header("�G�߂��Ƃ̃X�v���C�g")]
    [SerializeField]
    private Sprite[] _seasonSprite;

    [Header("�G�߂��Ƃ̖؂̃X�v���C�g")]
    [SerializeField]
    private Sprite[] _treeSprite;

    [SerializeField]
    [Header("���̃X�v���C�g")]
    private Sprite _woterSprite;

    [SerializeField]
    [Header("�X�̃X�v���C�g")]
    private Sprite _iceSprite;

    [SerializeField]
    private TilemapCollider2D _woterCollider2D;

    [SerializeField]
    [Header("�Z���̃|�W�V����")]
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
            // tilemap.HasTile�Ń^�C�����ݒ�(�`��)����Ă�����W�ł��邩����
            if (_tilemap.HasTile(_cellPos))
            {
                // �X�v���C�g����v���Ă��邩������Ƃ�
                if (_tilemap.GetSprite(_cellPos) == _seasonSprite[1] || _tilemap.GetSprite(_cellPos) == _seasonSprite[2] || _tilemap.GetSprite(_cellPos) == _seasonSprite[3])
                {
                    // �X�v���C�g����v���Ă���ꍇ�͕ʂ̃^�C����ݒ肷��
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
