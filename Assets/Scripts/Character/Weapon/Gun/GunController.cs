using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GunController : MonoBehaviour {
    [FormerlySerializedAs("WeaponHold")] public Transform weaponHold;
    public Gun[] allGun;
    Gun _equippedGun;
    
    public void EquidGun(Gun gunToEquip)
    {
        if (_equippedGun != null)
        {
            Destroy(_equippedGun.gameObject);
        }
        _equippedGun = Instantiate(gunToEquip,weaponHold.position,weaponHold.rotation)as Gun;
        _equippedGun.transform.parent = weaponHold;
    }

    public void EquipGun(int weaponIndex)
    {
        EquidGun(allGun[weaponIndex]);
    }

    public void OnTriggerHold()
    {
        if (_equippedGun != null)
        {
            _equippedGun.OnTriggerHold();
        }
    }

    public void OnTriggerRelease()
    {
        if (_equippedGun != null)
        {
            _equippedGun.OnTriggerRelease();
        }
    }

    public float GunHeight
    {
        get
        {
            return weaponHold.position.y;
        }
    }

    public void Aim(Vector3 aimPoint)
    {
        if (_equippedGun != null)
        {
            _equippedGun.Aim(aimPoint);
        }
    }

    public void Reload()
    {
        if (_equippedGun != null)
        {
            _equippedGun.Reload();
        }
    }
}
