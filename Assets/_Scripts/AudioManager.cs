using UnityEngine;
using UnityEngine.Audio;



public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioMixer musicMixer;
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource Uisource;
    [SerializeField] private AudioClip levelMusic;
    [SerializeField] private float LfoCycle = 1f;
    [SerializeField] private AnimationCurve LfoCurve;
    private float modStrength;

    private void Awake()
    {
        musicSource.clip = levelMusic;
    }
    private void Start()
    {
        Weapon.WeaponFired.AddListener(PlayWeaponSound);
        Enemy.EnemyDied.AddListener(PlayEnemyDiedSound);

        //PlayMusic();
    }

    private void Update()
    {
        float t = Time.time - (int)Time.time;
        float modulation = LfoCurve.Evaluate(t);
        //musicMixer.SetFloat("pitch", modulation * modStrength);
        musicSource.pitch = modulation * modStrength + 1;

    }

    private void OnDisable()
    {
        Weapon.WeaponFired.RemoveListener(PlayWeaponSound);
        Enemy.EnemyDied.RemoveListener(PlayEnemyDiedSound);
        
    }
    public void PlayMusic()
    {
        //print("PlayMusic");
        musicSource.Play();
    }

    public void PlayWeaponSound (Weapon weapon)
    {
        AudioSource.PlayClipAtPoint(weapon.WeaponSound, weapon.transform.position);
         
    }

    public void PlayEnemyDiedSound(Enemy enemy)
    {
        AudioSource.PlayClipAtPoint(enemy.EnemyDiedSound, enemy.transform.position);
    }

    public void PauseEffect(bool isPaused)
    {

        if (isPaused)
        {
            musicMixer.SetFloat("Cutoff", 481);
        }
        else
        {
            musicMixer.SetFloat("Cutoff", 22000);
        }
        
    }

    public void DramaEffect(float strengh)
    {
        modStrength = strengh;

        musicMixer.SetFloat("Wet", strengh);
    }
}
