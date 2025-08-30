using UnityEngine;

public class FireSound : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    public void Fire()
    {
        _audioSource.Play();
    }
}
