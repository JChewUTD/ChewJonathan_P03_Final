using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] GameObject _player;
    [SerializeField] GameObject _playerModel;
    [SerializeField] float _currentSpeed = .5f;
    Rigidbody _rb = null;
    float moveUp = 0.1f;
    float getTime;

    private void Start()
    {
        _rb = _player.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (!Input.GetKey(KeyCode.J))
        {
            MovePlayer();
        }
        
        MoveAnim();
    }

    private void MovePlayer()
    {
        float vertMovement = Input.GetAxis("Vertical") * _currentSpeed * Time.deltaTime;
        float horiMovement = Input.GetAxis("Horizontal") * _currentSpeed * Time.deltaTime;
        _player.transform.Translate(horiMovement, 0, vertMovement);
    }

    private void MoveAnim()
    {
        if (!Mathf.Approximately(Input.GetAxisRaw("Vertical"), 0) || !Mathf.Approximately(Input.GetAxisRaw("Horizontal"), 0))
        {
            if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
            {
                _playerModel.transform.forward = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            }
        }
    }
}
