using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour {

    public enum FireMode { Auto,Burst,Singer};
    public FireMode fireMode;

    public Transform[] projectileSpawn;
    public Projectile projectile;
    public float msBetweenShots = 100;
    public float muzzleVelocity =  35;
    public int burstCount;
    public int projectilesPerMag;
    public float reloadTime = .3f;

    [Header("Recoil")]
    public Vector2 kickMinMax = new Vector2(.05f,.2f);
    public Vector2 recoilAngleMinMax = new Vector2(3,5);
    public float recoilMoveSettleTime = .1f;
    public float recoilRotationSettleTime = .1f;

    [Header("Effects")]
    public Transform shell;
    public Transform shellEjection;
    public AudioClip shootAudio;
    public AudioClip reloadAudio;
    MuzzleFlash _muzzleFlash;
    float _nextShotTime;

    bool _triggerReleasedSinceLastShot;
    int _shotRemainingInBurst;
    int _projectilesRemainingInMag;
    bool _isReloading;

    Vector3 _recoilSmoothDampVelocity;
    float _recoilRotSmoothDampVelocity;
    float _recoilAngle;
    Text _bulletNumber;

    private void Start()
    {
        // muzzleFlash = GetComponent<MuzzleFlash>();
        _shotRemainingInBurst = burstCount;
        _projectilesRemainingInMag = projectilesPerMag;
        // bulletNumber = GameObject.FindGameObjectsWithTag("UI_Text")[0].GetComponent<Text>();
        // bulletNumber.text = "Bullet balance: " + projectilesPerMag;
    }

    private void LateUpdate()
    {
        //animate recoil
        if (!_isReloading)
        {
            transform.localPosition = Vector3.SmoothDamp(transform.localPosition, Vector3.zero, ref _recoilSmoothDampVelocity, recoilMoveSettleTime);
            _recoilAngle = Mathf.SmoothDamp(_recoilAngle, 0, ref _recoilRotSmoothDampVelocity, recoilRotationSettleTime);
            transform.localEulerAngles = Vector3.left * _recoilAngle;
        }
       
        if(!_isReloading && _projectilesRemainingInMag == 0)
        {
            Reload();
        }
    }

    void Shoot()
    {
        if (!_isReloading && Time.time > _nextShotTime&& _projectilesRemainingInMag > 0)
        {
            if(fireMode == FireMode.Burst)
            {
                if(_shotRemainingInBurst == 0)
                {
                    return;
                }
                _shotRemainingInBurst--;
            }
            else if(fireMode == FireMode.Singer)
            {
                if (!_triggerReleasedSinceLastShot)
                {
                    return;
                }
            }

            for (int i = 0; i <projectileSpawn.Length; i++)
            {
                if (_projectilesRemainingInMag == 0)
                {
                    break;
                }
                _projectilesRemainingInMag--;
                
                _nextShotTime = Time.time + msBetweenShots / 1000;
                Projectile newProjectile = Instantiate(projectile, projectileSpawn[i].position, projectileSpawn[i].rotation) as Projectile;
                newProjectile.setSpeed(muzzleVelocity);
                ContextHelper.playerMood -= newProjectile.needMood;
            }

            // bulletNumber.text = "Bullet balance: " + projectilesRemainingInMag;
            // Instantiate(shell, shellEjection.position, shellEjection.rotation);
            // muzzleFlash.Activate();

            transform.localPosition -= Vector3.forward * Random.Range(kickMinMax.x,kickMinMax.y);
            _recoilAngle += Random.Range(recoilAngleMinMax.x,recoilAngleMinMax.y);
            _recoilAngle = Mathf.Clamp(_recoilAngle, 0f, 30f);

            // AudioManager.instance.PlaySound(shootAudio,transform.position);
        }
    }

    public void Reload()
    {
        if(!_isReloading && _projectilesRemainingInMag != projectilesPerMag)
        {
            StartCoroutine(AnimateReload());
            // AudioManager.instance.PlaySound(shootAudio, transform.position);
        }
    }

    IEnumerator AnimateReload()
    {
        _isReloading = true;
        yield return new WaitForSeconds(.2f);

        float reloadSpeed = 1f / reloadTime;
        float percent = 0;
        Vector3 initialRot = transform.localEulerAngles;
        float maxReloadAngle = 30;
        while (percent < 1)
        {
            percent += Time.deltaTime * reloadSpeed;
            float interpolation = (-Mathf.Pow(percent, 2) + percent) * 4;
            float reloadAngle = Mathf.Lerp(0, maxReloadAngle, interpolation);
            transform.localEulerAngles = initialRot + Vector3.left * reloadAngle;

            yield return null;
        }
        _isReloading = false;
        _projectilesRemainingInMag = projectilesPerMag;
        // bulletNumber.text = "Bullet balance: " + projectilesPerMag;
    }

    public void Aim(Vector3 aimPoint)
    {
        if (!_isReloading)
        {
            transform.LookAt(aimPoint);
        }
    }

    public void OnTriggerHold()
    {
        Shoot();
        _triggerReleasedSinceLastShot = false;
    }

    public void OnTriggerRelease()
    {
        _triggerReleasedSinceLastShot = true;
        _shotRemainingInBurst = burstCount;
    }
}
