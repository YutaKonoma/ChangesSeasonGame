using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField]
    [Header("�G���ړ�����͈�")]
    GameObject[] _moveRange;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //var player = collision.gameObject.GetComponent<>();
        //if (player != null)
        {

        }
    }
}
