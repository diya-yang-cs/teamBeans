using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightCamera : MonoBehaviour
{

    private Vector3 _cameraStartingPosition = new Vector3(0, 1, -10);
    private GameObject _fightCamera;
    private float _cameraValueXaxis;
    private float _cameraValueYaxis;
    private float _cameraValueZaxis;

    private float _cameraValueZaxisModifier = -8;
    public GameObject _playerOne;
    public GameObject _playerTwo;

    private Vector3 _player1Position;
    private Vector3 _player2Position;

    // Start is called before the first frame update
    void Start()
    {
        _fightCamera = GameObject.FindGameObjectWithTag("MainCamera");
        _fightCamera.transform.position = _cameraStartingPosition;
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePlayer1Position();
        UpdatePlayer2Position();
        UpdateCameraPosotion();
    }

    private void UpdatePlayer1Position()
    {
        Debug.Log("UpdatePlayer1Position");

        _player1Position = new Vector3(
            _playerOne.transform.position.x,
            _playerOne.transform.position.y,
            _playerOne.transform.position.z);
    }
    private void UpdatePlayer2Position()
    {
        Debug.Log("UpdatePlayer2Position");

        _player2Position = new Vector3(
            _playerTwo.transform.position.x,
            _playerTwo.transform.position.y,
            _playerTwo.transform.position.z);
    }

    private void UpdateCameraPosotion()
    {
        Debug.Log("UpdateCameraPosotion");

        _cameraValueXaxis = ((_player1Position.x + _player2Position.x) / 2);

        if (_playerOne.transform.position.x < _playerTwo.transform.position.x)
            _cameraValueZaxis = _player1Position.x - _player2Position.x;

        if (_playerOne.transform.position.x > _playerTwo.transform.position.x)
            _cameraValueZaxis = _player2Position.x - _player1Position.x;

        if (_cameraValueZaxis > -1) _cameraValueZaxis = -1;
        if (_cameraValueZaxis < -7) _cameraValueZaxis = -7;
        _fightCamera.transform.position = new Vector3(_cameraValueXaxis, 1, _cameraValueZaxis + _cameraValueZaxisModifier);
    }
}
