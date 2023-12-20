using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public AudioClip[] songs; // Массив для хранения песен
    private AudioSource audioSource;
    private int currentSongIndex = 0;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Проверка наличия песен в массиве
        if (songs.Length > 0)
        {
            // Начать воспроизведение первой песни
            PlayNextSong();
        }
        else
        {
            Debug.LogError("Добавьте аудиофайлы в массив 'songs'");
        }
    }

    void Update()
    {
        // Проверка завершения воспроизведения текущей песни
        if (!audioSource.isPlaying)
        {
            // Проиграть следующую песню
            PlayNextSong();
        }
    }

    void PlayNextSong()
    {
        // Выбор следующей песни из массива
        audioSource.clip = songs[currentSongIndex];
        // Воспроизведение песни
        audioSource.Play();

        // Увеличение индекса текущей песни для циклического проигрывания
        currentSongIndex = (currentSongIndex + 1) % songs.Length;
    }
}
