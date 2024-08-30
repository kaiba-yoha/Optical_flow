using UnityEngine;
using UnityEngine.UI;
using Meta.XR;

public class CountDown : MonoBehaviour
{
    public TMPro.TextMeshProUGUI countdownText;
    public SphereGenerator sphereGenerator;

    private bool isCountingDown = false;
    private float countdownTime = 3f;

    void Start()
    {
        sphereGenerator.enabled = false;
        countdownText.gameObject.SetActive(false);
    }

    void Update()
    {
        // Meta Quest 3のAボタンの入力を検出
        if (!isCountingDown && OVRInput.GetDown(OVRInput.Button.One))
        {
            StartCountdown();
        }

#if UNITY_EDITOR

        // キーボードのAボタンの入力を検出
        if (!isCountingDown && Input.GetKeyDown(KeyCode.A))
        {
            StartCountdown();
        }
#endif

        if (isCountingDown)
        {
            countdownTime -= Time.deltaTime;
            int countdownValue = Mathf.CeilToInt(countdownTime);
            countdownText.text = countdownValue.ToString();

            if (countdownTime <= 0)
            {
                EndCountdown();
            }
        }
    }

    void StartCountdown()
    {
        isCountingDown = true;
        countdownTime = 3f;
        countdownText.gameObject.SetActive(true);
    }

    void EndCountdown()
    {
        isCountingDown = false;
        countdownText.gameObject.SetActive(false);
        sphereGenerator.enabled = true;
    }
}
