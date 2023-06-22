using Cysharp.Threading.Tasks;
using System.Collections;
using UniRx;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Player : MonoBehaviour
{
    [SerializeField]
    [Header("プレイヤーのリスポーン地点")]
    GameObject _spawnPoint;

    [SerializeField]
    [Header("プレイヤーのRigidbody2D")]
    Rigidbody2D _rb2;

    [SerializeField]
    [Header("プレイヤーの移動速度")]
    float _speed;

    [SerializeField]
    [Header("ジャンプの高さ")]
    float _junpPower;

    [SerializeField]
    Vector2 _vector;

    [SerializeField]
    [Header("地面の着地判定")]
    bool _isGrounded;

    [SerializeField]
    [Header("プレイヤーが操作可能ならtrue")]
    bool _player = true;

    bool _sprite;

    [SerializeField]
    [Header("Rayの長さ")]
    float _rayDistance = 0.1f;

    [SerializeField]
    [Header("Rayで取得するレイヤー")]
    LayerMask  _layerMask;

    [SerializeField]
    Animator _animator;

    private void FixedUpdate()
    {
        _isGrounded = Physics2D.Raycast(transform.position, Vector2.down, _rayDistance, _layerMask);

        _animator.SetBool("grounded", _isGrounded);
        _animator.SetFloat("velocityX", Mathf.Abs(_vector.x) / _speed);
    }

    public void Move(float moveInput)
    {
        if (!_player) return;

        if (moveInput != 0)
        {
            _vector.x = moveInput;
            _sprite = moveInput < 0;
            transform.rotation = _sprite ? Quaternion.Euler(0, 160, 0) : Quaternion.Euler(0, 0, 0);
        }
        else _vector.x = 0;

        _rb2.velocity = new Vector2(_vector.x * _speed, 0);
    }

    public void Jump()
    {
        if (!_player) return;
        if (_isGrounded)
        {
            _rb2.AddForce(new Vector2(0, _junpPower), ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Destroy"))
        {
            _player = false;
            _vector.x = 0;
            _animator.SetTrigger("hurt");
            _animator.SetBool("dead", true);
            Observable.TimerFrame(300).Subscribe(_ => ReStart()).AddTo(this);
        }
    }

    private void ReStart()
    {
        _animator.SetBool("dead", false);
        transform.position = _spawnPoint.transform.position;
        _player = true;
    }
}
