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
    [Header("�x�[�X")]
    [SerializeField]
    private Tilemap _tilemap;
    [SerializeField]
    private Tilemap _treemap;
    [SerializeField]
    private Tilemap _wotermap;

    [SerializeField]
    [Header("�G�߂��Ƃ̃^�C��")]
    private TileBase[] _seasonTile;

    [SerializeField]
    [Header("�G�߂��Ƃ̖�")]
    private TileBase[] _treeTile;

    [SerializeField]
    [Header("���̃^�C��")]
    private TileBase _wotertile;

    [SerializeField]
    [Header("�X�̃^�C��")]
    private TileBase _icetile;

    [SerializeField]
    [Header("�G�߂��Ƃ̃X�v���C�g")]
    private Sprite[] _seasonSprite;

    [SerializeField]
    [Header("�G�߂��Ƃ̖؂̃X�v���C�g")]
    private Sprite[] _treeSprite;

    [SerializeField]
    [Header("���̃X�v���C�g")]
    private Sprite _woterSprite;

    [SerializeField]
    [Header("�X�̃X�v���C�g")]
    private Sprite _iceSprite;

    [SerializeField]
    [Header("���A�X�̃R���C�_�[")]
    private TilemapCollider2D _woterCollider2D;

    [Tooltip("�Z���̃|�W�V����")]
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
            // tilemap.HasTile�Ń^�C�����ݒ�(�`��)����Ă�����W�ł��邩����
            if (_tilemap.HasTile(_cellPos))
            {
                // �X�v���C�g����v���Ă��邩������Ƃ�
                if (_tilemap.GetSprite(_cellPos) == _seasonSprite[1] || _tilemap.GetSprite(_cellPos) == _seasonSprite[2] || _tilemap.GetSprite(_cellPos) == _seasonSprite[3])
                {
                    // �X�v���C�g����v���Ă���ꍇ�͕ʂ̃^�C����ݒ肷��
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
