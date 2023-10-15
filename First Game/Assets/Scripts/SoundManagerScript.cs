using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip jumpSound, deathSound;
    static AudioSource audioSource;
    void Start()
    {
        jumpSound = Resources.Load<AudioClip>("jumpSound");
        deathSound = Resources.Load<AudioClip>("deathSound");

        audioSource = GetComponent<AudioSource>();
    }

    public static void PlayJumpSound()
    {
        audioSource.PlayOneShot(jumpSound);
    }
    public static void PlayDeathSound()
    {
        audioSource.PlayOneShot(deathSound);
    }
}
