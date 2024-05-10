using UnityEngine;
using UnityEngine.Video;

public class ActivateVideo : MonoBehaviour
{
    public VideoPlayer videoPlayer1; // Assign the Video Player component in the Inspector
    public VideoPlayer videoPlayer2; // Assign the Video Player component in the Inspector

    private void OnTriggerEnter(MeshCollider other)
    {
        if (other.gameObject.CompareTag("Player")) // Replace with your player tag
        {
            videoPlayer1.Play();
            videoPlayer2.Play();
        }
    }

    private void OnTriggerExit(MeshCollider other)
    {
        if (other.gameObject.CompareTag("Player")) // Replace with your player tag
        {
            videoPlayer1.Stop();
            videoPlayer2.Stop();
        }
    }
}