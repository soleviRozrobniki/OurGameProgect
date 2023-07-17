using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class WeaponData : ScriptableObject
{
    [Header("Turret Stats")]
    [SerializeField] private int _damage, _price;
    [SerializeField] private float _fireRate, _speedOfBullet;
    [SerializeField] private string _turretName;
    [SerializeField] private GameObject _model;
    [SerializeField] private Sprite _sprite;

    public int Damage
    {
        get { return _damage; }
        set { _damage = value; }
    }
    public int Price
    {
        get { return _price; }
        set { _price = value; }
    }
    public string TurretName
    {
        get { return _turretName; }
        set { _turretName = value; }
    }
    public float FireRate
    {
        get { return _fireRate; }
        set { _fireRate = value; }
    }
    public float SpeedOfBullet
    {
        get { return _speedOfBullet; }
        set { _speedOfBullet = value; }
    }
    public Sprite Sprite
    {
        get { return _sprite; }
        set { _sprite = value; }
    }
    public GameObject Model
    {
        get { return _model; }
        set { _model = value; }
    }
}
