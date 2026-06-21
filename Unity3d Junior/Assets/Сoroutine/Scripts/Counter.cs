using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _startCount = 0f;
    [SerializeField] private float _delay = 0.5f;
    [SerializeField] private float _endCount = 10f;

    private float _sumCount = 0f;
    private Coroutine _countdownCoroutine;
    private bool _isCounting = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (!_isCounting)
            {             
                _countdownCoroutine = StartCoroutine(Countdown());
                _isCounting = true;
            }
            else
            {               
                if (_countdownCoroutine != null)
                {
                    StopCoroutine(_countdownCoroutine);
                    _countdownCoroutine = null;
                }
                _isCounting = false;
            }
        }
    }

    private IEnumerator Countdown()
    {        
        for (float i = _startCount; i <= _endCount; i+=_delay)
        {
            _sumCount += i;
            Debug.Log($"счётчик - {_sumCount}");
            yield return new WaitForSeconds(_delay);
        }
        Debug.Log($"Сумма - {_sumCount}");

        _isCounting = false;
        _countdownCoroutine = null;
    }
}



//Задание
//Счетчик
//Реализуйте счетчик, который каждые 0.5 сек. увеличивается на единицу. ++
//При нажатии на кнопку мыши счетчик начинает увеличиваться, при повторном нажатии останавливается. 
//Значения счетчика не обнуляются, каждый раз продолжается со значения, на котором остановился.
//Для отображения значений счетчика используйте Debug.Log или можете использовать элемент UI, а именно Text.

//Для решения задачи используйте корутину.

//Сдача как проект на Git + видео демонстрация.