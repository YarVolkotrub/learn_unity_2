using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AlarmSystem : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private float _minVolume = 0.0f;
    private float _deltaVolume = 0.2f;
    private float _delayUpVolume = 2.0f;
    private float _maxVolume = 1.0f;
    private Coroutine _coroutine;

    private void Awake()
    {
        _audioSource.volume = _minVolume;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Rogue>() == false)
        {
            return;
        }

        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _audioSource.Play();
        _coroutine = StartCoroutine(VolumeBoost(_maxVolume));
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Rogue>() == false)
        {
            return;
        }

        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(VolumeBoost(_minVolume));
    }

    private IEnumerator VolumeBoost(float targetVolume)
    {
        WaitForSeconds wait = new(_delayUpVolume);

        while (_audioSource.volume != targetVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolume, _deltaVolume);

            yield return wait;
        }

        if (_audioSource.volume == _minVolume)
        {
            _audioSource.Stop();
        }
    }
}