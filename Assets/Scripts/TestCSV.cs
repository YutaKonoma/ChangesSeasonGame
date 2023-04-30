using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TestCSV : MonoBehaviour
{
    [SerializeField]
    string _csvFile;

    [SerializeField]
    Tilemap _tile;

    private System.IO.StreamWriter _sw;

    List<Sprite> _csvData = new List<Sprite>();
    void Start()
    {
        _sw = new System.IO.StreamWriter(@"SaveData.csv", true, Encoding.GetEncoding("Shift_JIS"));
        CheckTile();
    }

    public void CheckTile()
    {
        var bound = _tile.cellBounds;
        for (int y = bound.max.y - 1; y >= bound.min.y; --y)
        {
            for (int x = bound.min.x; x < bound.max.x; ++x)
            {
                var tile = _tile.GetTile<Tile>(new Vector3Int(x, y, 0));
                if (tile != null && !_csvData.Contains(tile.sprite))
                {
                    _csvData.Add(tile.sprite);
                }
            }
        }

        // どの場所でそのSpriteが使われているかを出力
        var builder = new StringBuilder();
        for (int y = bound.max.y - 1; y >= bound.min.y; --y)
        {
            for (int x = bound.min.x; x < bound.max.x; ++x)
            {
                var tile = _tile.GetTile<Tile>(new Vector3Int(x, y, 0));
                if (tile == null)
                {
                    builder.Append("_");
                }
                else
                {
                    var index = _csvData.IndexOf(tile.sprite);
                    builder.Append(index);
                }
            }
            builder.Append("\n");
        }
        _sw.WriteLine(builder.ToString());
        _sw.Close();
        //Debug.Log(builder.ToString());
    }

    void DataSave(string builder)
    {
        _sw.WriteLine(builder);
        _sw.Close();
        Debug.Log(_sw);
    }

    public bool CheckExixtCSV(string path)
    {
        if (System.IO.File.Exists(path))
        {
            Debug.Log("CSVファイルが存在するので追記します");
            return true;
        }
        else
        {
            Debug.Log("CSVファイルが存在しないので作成します");
            return false;
        }
    }
}
