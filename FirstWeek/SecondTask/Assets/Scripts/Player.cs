using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private BulletPool _standardBulletPool;
    [SerializeField] private BulletPool _sinBulletPool;
    [SerializeField] private Transform _initialPosition;
    [SerializeField] private PlayerAnimations _animations;
    [SerializeField] private GunsOutput _gunOutput;

    private IGun CurrentGun => _gunEnumerator.Current;

    private List<IGun> _guns = new();
    private IEnumerator<IGun> _gunEnumerator;

    private void Awake()
    {
        _guns.Add(new StandardGun(_standardBulletPool, _initialPosition, 7));
        _guns.Add(new Shotgun(_standardBulletPool, _initialPosition, 30, 5));
        _guns.Add(new RocketGun(_sinBulletPool, _initialPosition, 7));

        _gunEnumerator = _guns.GetEnumerator();
        _gunEnumerator.MoveNext();
        UpdateAmmo();
        UpdateIcon();
    }

    void Update()
    {
        if (Input.GetKey("x"))
        {
            CurrentGun.Shoot();
            UpdateAmmo();
        }

        if (Input.GetKeyDown("z"))
        {
            if (!_gunEnumerator.MoveNext())
            {
                _gunEnumerator.Reset();
                _gunEnumerator.MoveNext();
            }
            UpdateIcon();
            UpdateAmmo();
        }

        if (Input.GetKeyDown("x"))
            _animations.SetFire(true);
        else if (Input.GetKeyUp("x"))
            _animations.SetFire(false);

        if (Input.GetKeyDown(KeyCode.UpArrow))
            _animations.SetUp(true);
        else if (Input.GetKeyUp(KeyCode.UpArrow))
            _animations.SetUp(false);

        if (Input.GetKeyDown(KeyCode.DownArrow))
            _animations.SetDown(true);
        else if (Input.GetKeyUp(KeyCode.DownArrow))
            _animations.SetDown(false);

        if (Input.GetKeyDown(KeyCode.RightArrow))
            _animations.SetWalk(true);
        else if (Input.GetKeyUp(KeyCode.RightArrow))
            _animations.SetWalk(false);
    }

    private void UpdateIcon()
    {
        int currentIndex = _guns.IndexOf(CurrentGun);
        if (currentIndex == 0)
            _gunOutput.SetFirstGun();
        else if (currentIndex == 1)
            _gunOutput.SetSecondGun();
        else
            _gunOutput.SetThirdGun();
    }

    private void UpdateAmmo()
    {
        _gunOutput.SetAmmo(CurrentGun.Ammo());
    }
}
