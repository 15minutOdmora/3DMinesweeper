using System.Collections;
using UnityEngine;
using System;
using TMPro;

/// <summary>
/// Stopwatch for measuring in game time using delta time. 
/// Acts as a singleton, time scaling should apply.
/// Stores last ended time (elapsed time at call of End()) in the
/// LastEndedTime variable.
/// Optionally text can be set (using SetText), class will then auto-update 
/// its value.
/// </summary>
public class Timer : MonoBehaviourSingleton<Timer>
{
    public float ElapsedTime => elapsedTime;
    public string ElapsedTimeFormated => FormatTime(elapsedTime, FORMAT);
    public float LastEndedTime => lastEnded;
    public string LastEndedTimeFormated => FormatTime(lastEnded, FORMAT);
    public bool IsRunning => isRunning;

    private float elapsedTime = 0f;

    private bool isRunning = false;

    private float lastEnded = 0f;

    private static readonly string FORMAT = "mm':'ss'.'ff";

    private TMP_Text text;
    private bool textSet = false;

    /// <summary>
    /// Starts timer and resets current value to 0.
    /// </summary>
    public void Begin()
    {
        isRunning = true;
        Restart();
        StartCoroutine(UpdateTimer());
    }

    /// <summary>
    /// Ends timer, saves current value as LastEndedTime, resets value to 0.
    /// </summary>
    public void End()
    {
        isRunning = false;
        lastEnded = elapsedTime;
        Restart();
    }

    /// <summary>
    /// Pauses timer until Resume is called and updates text.
    /// </summary>
    public void Pause()
    {
        isRunning = false;
        UpdateText();
    }

    /// <summary>
    /// Resumes timer.
    /// </summary>
    public void Resume()
    {
        isRunning = true;
        StartCoroutine(UpdateTimer());
    }

    /// <summary>
    /// Resets elapsed time and updates text.
    /// </summary>
    public void Restart()
    {
        elapsedTime = 0f;
        UpdateText();
    }

    /// <summary>
    /// Sets object reference for text, if set it will auto-update its value
    /// using default formating.
    /// </summary>
    /// <param name="text">TMP_Text object</param>
    public void SetText(TMP_Text text)
    {
        this.text = text;
        textSet = true;
    }

    /// <summary>
    /// Formats passed time (in seconds). Uses default formating if format not
    /// specified.
    /// </summary>
    /// <param name="elapsedTime">Time value to format</param>
    /// <param name="format">Optional format</param>
    /// <returns>Formated time as a string object</returns>
    public static string FormatTime(float elapsedTime, string format = null)
    {
        format ??= FORMAT;
        TimeSpan timeSpan = TimeSpan.FromSeconds(elapsedTime);
        return timeSpan.ToString(format);
    }

    private IEnumerator UpdateTimer()
    {
        while (isRunning)
        {
            elapsedTime += Time.deltaTime;

            UpdateText();

            yield return null;
        }
    }

    private void UpdateText()
    {
        if (textSet)
        {
            text.text = ElapsedTimeFormated;
        }
    }
}
