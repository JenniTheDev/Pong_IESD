using UnityEngine;

public class SoundManager : MonoBehaviour {
    [SerializeField] private bool randomizeWallHits = true;
    [SerializeField] private AudioSource wallHit;
    [SerializeField] private AudioClip[] wallHits;

    [SerializeField] private bool randomizePlayerWallHits = true;
    [SerializeField] private AudioSource playerWallHit;
    [SerializeField] private AudioClip[] playerWallHits;

    [SerializeField] private bool randomizePlayerPaddleHits = true;
    [SerializeField] private AudioSource playerPaddleWallHit;
    [SerializeField] private AudioClip[] playerPaddleWallHits;

    #region MonoBehaviour
    private void Start() {
        Subscribe();
    }

    private void OnEnable() {
        Subscribe();
    }

    private void OnDisable() {
        Unsubscribe();
    }
    #endregion

    #region Methods
    private void PlayWallHit() {
        if(wallHits.Length > 0) {
            int clipNumToPlay = (randomizeWallHits) ? Random.Range(0, wallHits.Length) : 0;
            wallHit.clip = wallHits[clipNumToPlay];
            wallHit.Play();
        }
    }

    private void PlayPlayerWallHit(Player p) {
        if(playerWallHits.Length > 0) {
            int clipNumToPlay = (randomizePlayerWallHits) ? Random.Range(0, playerWallHits.Length) : 0;
            playerWallHit.clip = playerWallHits[clipNumToPlay];
            playerWallHit.Play();
        }
    }

    private void Subscribe() {
        Unsubscribe();
        EventController.Instance.OnWallHit += PlayWallHit;
        EventController.Instance.OnPlayerWallHit += PlayPlayerWallHit;
    }

    private void Unsubscribe() {
        EventController.Instance.OnWallHit -= PlayWallHit;
        EventController.Instance.OnPlayerWallHit -= PlayPlayerWallHit;
    }
    #endregion
}
