using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Shrine : MonoBehaviour
{
	public static event Action OnProgressCompleted;
	
	[SerializeField] private Image progressBar;
	[SerializeField] private float progressPerSecond = 0.4f;
	[SerializeField] private float decayPerSecond = 0.3f;

	private float _currentProgress;
	private bool _playerInside;
	private Coroutine _progressRoutine;

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			Debug.Log("Entered shrine");
			_playerInside = true;
			StartProgressRoutine();
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			Debug.Log("Exited shrine");
			_playerInside = false;
		}
	}

	private void StartProgressRoutine()
	{
		_progressRoutine ??= StartCoroutine(ProgressRoutine());
	}

	private IEnumerator ProgressRoutine()
	{
		while (_playerInside || _currentProgress > 0f)
		{
			var delta = (_playerInside ? progressPerSecond : -decayPerSecond) * Time.deltaTime;
			_currentProgress = Mathf.Clamp(_currentProgress + delta, 0f, 1f);
			progressBar.fillAmount = _currentProgress;
			if (Mathf.Approximately(_currentProgress, 1f))
			{
				FinishProgressAndDisable();
				yield break;
			}
			yield return null;
		}
		_progressRoutine = null;
	}

	private void FinishProgressAndDisable()
	{
		OnProgressCompleted?.Invoke();
		progressBar.gameObject.SetActive(false);
	}
}