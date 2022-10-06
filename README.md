# Интеграция сервиса для получения данных профиля пользователя.
Отчет по лабораторной работе #2 выполнила:
- Завьялова Екатерина Николаевна
- РИ300023
Отметка о выполнении заданий (заполняется студентом):

| Задание | Выполнение | Баллы |
| ------ | ------ | ------ |
| Задание 1 | # | 60 |
| Задание 2 | # | 20 |
| Задание 3 | # | 20 |

знак "*" - задание выполнено; знак "#" - задание не выполнено;

Работу проверили:
- к.т.н., доцент Денисов Д.В.
- к.э.н., доцент Панов М.А.
- ст. преп., Фадеев В.О.

[![N|Solid](https://cldup.com/dTxpPi9lDf.thumb.png)](https://nodesource.com/products/nsolid)

[![Build Status](https://travis-ci.org/joemccann/dillinger.svg?branch=master)](https://travis-ci.org/joemccann/dillinger)

Структура отчета

- Данные о работе: название работы, фио, группа, выполненные задания.
- Цель работы.
- Задание 1.
- Код реализации выполнения задания. Визуализация результатов выполнения.
- Задание 2.
- Код реализации выполнения задания. Визуализация результатов выполнения.
- Задание 3.
- Код реализации выполнения задания. Визуализация результатов выполнения.
- Выводы.

## Цель работы
создание интерактивного приложения и изучение принципов интеграции в него игровых сервисов.

## Задание 1
### По теме видео практических работ 1-5 повторить реализацию игры на Unity. Привести описание выполненных действий.
Ход работы:
1) Добавить графику и объекты.
В моем случае это восклицательный знак, вагонетка, золото и фон.

2) Добавить анимацию.
Я сделала простенькую анимацию вагонетки и спавнера золота (восклицательный знак).
![Видео](https://github.com/KatyaZav/GameDev-lab2/blob/main/Screens/1%20task/2.1.mp4)
![Видео](https://github.com/KatyaZav/GameDev-lab2/blob/main/Screens/1%20task/2.2.mp4)

3) Добавить перемещение вагонетки через кнопки клавиатуры.
Добавим кнопки в Input Manager, чтобы их указать в перемещении. Это нужно, чтобы в коде не было прямой привязки к кнопкам.
![Фото](https://github.com/KatyaZav/GameDev-lab2/blob/main/Screens/1%20task/3.1.jpg)

Движение реализовала в FixedUpdate с использованием transform. 
```py
private void Move()
    {
        float x = Input.GetAxis("Horizontal");
        var movement = new Vector2(x, 0);

        transform.Translate(movement * speed * Time.fixedDeltaTime);
    }
```
![Видео](https://github.com/KatyaZav/GameDev-lab2/blob/main/Screens/1%20task/3.2.mp4)
(И это оказалось ошибкой. Подробнее в пункте 5).

4) Сделать передвижение спавнера золота, добавить элемент случайности в его перемещение.
![Видео](https://github.com/KatyaZav/GameDev-lab2/blob/main/Screens/1%20task/4.mp4)

Я решила добавить хаотичности движения не только за счет движения в разные стороны, но и с разной скоростью. Сами показатели вероятностей настраиваются из инспектора unity.
```py
private IEnumerator Moving()
    {
        while (true)
        {
            yield return new WaitForFixedUpdate();

            //transform.Translate((new Vector2(movementDirection, 0)) * MaxSpeed * Time.fixedDeltaTime);
            _rb.AddForce((new Vector2(movementDirection, 0)) * speed * 2);

            if (Random.Range(1, 100) < ChanceChangeDirection)
            {
                movementDirection *= -1;

                if (Random.Range(0, 100) < 30)
                {
                    speed = Random.Range(0, MaxSpeed);
                }
                else if (Random.Range(0, 100) < 5)
                {
                    speed = MaxSpeed;
                }
            }

            if (Random.Range(0, 100) < ChanceChangeSpeed)
            {
                speed = Random.Range(0, MaxSpeed);
            }
        }
    }
```

5) Добавить границы карты.
На этом этапе пришлось вернуться к пункту 3 и 4, чтобы сделать перемещение физическим, то есть через AddForse. Без этого объекты проходили сквозь границы карты. Решить это можно было бы через код, но тогда всем сущностям пришлось бы прописывать вручную одно и тоже ограничение.
```py
private void Move()
    {
        float x = Input.GetAxis("Horizontal");
        var movement = new Vector2(x, 0);

        //Debug.Log(movement);
        _rb.AddForce(movement * speed);
        //transform.Translate(movement * speed * Time.fixedDeltaTime);
    }
```
![Видео](https://github.com/KatyaZav/GameDev-lab2/blob/main/Screens/1%20task/5.mp4)

6) Сделать создание золота из спавнера.
```py
private IEnumerator GenerateGold()
    {
        while (true)
        {
            yield return new WaitForSeconds(TimeBetweenGold);

            var golden = Instantiate(gold);
            golden.transform.position = transform.position;           
        }
    }
```
![Видео](https://github.com/KatyaZav/GameDev-lab2/blob/main/Screens/1%20task/6.mp4)

7) Сделать исчезновение золота при выходе за карту.
Я создала пустой объект с триггерным колайдером. На него навесила такой скрипт:
```py
private void OnTriggerEnter2D(Collider2D collision)
    {
        try
        {
            Debug.Log("Deleted " + collision.gameObject.ToString());
            ICollectable obj = collision.gameObject.GetComponent<ICollectable>();
            obj.Disapear();
        }
        catch(System.Exception e)
        {
            Debug.LogWarning("Fall something non ICollectible! " + e + " " + collision.gameObject.ToString());
            Destroy(collision.gameObject);
        }
    }
```
Он работает на интерфейсе, который используется в классе золота:
```py
public class Gold : MonoBehaviour, ICollectable
{
    [SerializeField] GameObject disapearEffectPrefab;

    public void Pick()
    {
        Debug.Log("Pick gold");
        Destroy(gameObject);
    }

    public void Disapear()
    {
        var explosion = Instantiate(disapearEffectPrefab);
        explosion.transform.position = transform.position;
        Destroy(gameObject);
    }
}
```
![Видео](https://github.com/KatyaZav/GameDev-lab2/blob/main/Screens/1%20task/6.mp4)

## Задание 2
### В проект, выполненный в предыдущем задании, добавить систему проверки того, что SDK подключен (доступен в режиме онлайн и отвечает на запросы);

Ход работы:

![Image alt](https://github.com/KatyaZav/DA-in-GameDev-lab1/blob/main/Screens/2.7.jpg)

## Задание 3
### Выполнить:
1 Произвести сравнительный анализ игровых сервисов Яндекс Игры и VK Game;
2 Дать сравнительную характеристику сервисов, описать функционал;
3 Описать их методы интеграции с Unity;
4 Произвести сравнение, сделать выводы;
5 Подготовить реферат по результатам выполнения пунктов 1-4
.
Ход работы:


```py

```


## Выводы
За лабораторную работу я столкнулась с несколькими проблемами и успешно их решила. 
Я поняла, что для передвижения лучше использовать физику, а не изменение координат вручную.
Я попрактиковалась в создании и использовании корутин и интерфейсов, поработала с эффектами. 

## Powered by

**BigDigital Team: Denisov | Fadeev | Panov**
