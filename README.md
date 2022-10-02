# Интеграция сервиса для получения данных
профиля пользователя.
Отчет по лабораторной работе #1 выполнила:
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
Ознакомиться с основными функциями Unity и взаимодействием с объектами внутри редактора.

## Задание 1
### В разделе «ход работы» пошагово выполнить каждый пункт с описанием и примера реализации задач по теме лабораторной работы.
Ход работы:
1)  Создать новый проект из шаблона 3D – Core;
![Image alt](https://github.com/KatyaZav/DA-in-GameDev-lab1/blob/main/Screens/1.jpg)

2)  Проверить, что настроена интеграция редактора Unity и Visual Studio Code (пункты 8-10 введения);

В моем случае это просто Visual Studio, мне более комфортно работать в этой программе.
![Image alt](https://github.com/KatyaZav/DA-in-GameDev-lab1/blob/main/Screens/2.jpg)

3)  Создать объект Plane;
![Image alt](https://github.com/KatyaZav/DA-in-GameDev-lab1/blob/main/Screens/3.jpg)

4)  Создать объект Cube;
![Image alt](https://github.com/KatyaZav/DA-in-GameDev-lab1/blob/main/Screens/4.jpg)

5)  Создать объект Sphere;
![Image alt](https://github.com/KatyaZav/DA-in-GameDev-lab1/blob/main/Screens/5.jpg)

6)  Установить компонент Sphere Collider для объекта Sphere;
![Image alt](https://github.com/KatyaZav/DA-in-GameDev-lab1/blob/main/Screens/6.jpg)

7)  Настроить Sphere Collider в роли триггера;

![Image alt](https://github.com/KatyaZav/DA-in-GameDev-lab1/blob/main/Screens/7.jpg)

8)  Объект куб перекрасить в красный цвет;
![Image alt](https://github.com/KatyaZav/DA-in-GameDev-lab1/blob/main/Screens/8.jpg)

9)  Добавить кубу симуляцию физики, при это куб не должен проваливаться под Plane;
Примечание: на предыдущем скрине видно, что объект висит над плато. На этом скрине сцена запущена в реальном времени, поэтому куб упал.
![Image alt](https://github.com/KatyaZav/DA-in-GameDev-lab1/blob/main/Screens/9.jpg)

10) Написать скрипт, который будет выводить в консоль сообщение о том, что объект Sphere столкнулся с объектом Cube;
![Image alt](https://github.com/KatyaZav/DA-in-GameDev-lab1/blob/main/Screens/10.jpg)
Реализовано так:
```py
private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered " + other.gameObject);
    }
```

11) При столкновении Cube должен менять свой цвет на зелёный, а при завершении столкновения обратно на красный.

Исходная сцена выглядит так.
![Image alt](https://github.com/KatyaZav/DA-in-GameDev-lab1/blob/main/Screens/11.jpg)
Реализовала это я так:
```py
private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
    }
```

После перемещения сферы цвет куба меняется, а в консоли появляется сообщение о столкновении.    
![Image alt](https://github.com/KatyaZav/DA-in-GameDev-lab1/blob/main/Screens/12.jpg)

Если переместить сферу повторно, то цвет куба поменяется обратно, а в консоли появится повторное сообщение.
![Image alt](https://github.com/KatyaZav/DA-in-GameDev-lab1/blob/main/Screens/13.jpg)

```py
private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit "+ other.gameObject);
        other.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
    }
```


## Задание 2
### Продемонстрируйте на сцене в Unity следующее:
- Что произойдёт с координатами объекта, если он перестанет быть дочерним?
- Создайте три различных примера работы компонента RigidBody?

Ход работы:
1) Перенести сферу в иерархию куба и сравнить координаты сферы.

Координаты, если сфера - дочерний элемент.
![Image alt](https://github.com/KatyaZav/DA-in-GameDev-lab1/blob/main/Screens/2.1.jpg)

Координаты, если сфера не дочерний элемент.
![Image alt](https://github.com/KatyaZav/DA-in-GameDev-lab1/blob/main/Screens/2.2.jpg)

Изменение происходит из-за того, что координаты дочернего элемента записываются относительно родительского.
2) Показать 3 различные настройки RigidBody.

Настройки сферы и куба не изменялись. Настроки цилиндра можно увидеть на скрине ниже.
![Image alt](https://github.com/KatyaZav/DA-in-GameDev-lab1/blob/main/Screens/2.3.jpg)

Так выглядит сцена до запуска.

![Image alt](https://github.com/KatyaZav/DA-in-GameDev-lab1/blob/main/Screens/2.4.jpg)

Так после.

![Image alt](https://github.com/KatyaZav/DA-in-GameDev-lab1/blob/main/Screens/2.5.jpg)

У сферы отключена гравитация, поэтому он не упал. У куба наоборот гравитация включена, поэтому он упал. Цилиндр - кинематический объект, поэтому никаие другие объекты не могут его сдвинуть.

Движние куба цилиндром возможно.

![Image alt](https://github.com/KatyaZav/DA-in-GameDev-lab1/blob/main/Screens/2.6.jpg)

Движение цилиндра кубом - нет.

![Image alt](https://github.com/KatyaZav/DA-in-GameDev-lab1/blob/main/Screens/2.7.jpg)

## Задание 3
### Реализуйте на сцене генерацию n кубиков. Число n вводится пользователем после старта сцены.

Ход работы:
1) Реализовать ввод данных
Был выбран элемент "InputField" и добавлен на канваз сцены.

![Image alt](https://github.com/KatyaZav/DA-in-GameDev-lab1/blob/main/Screens/3.1.jpg)

2) Добавить пустой объект, который будет служить генератором кубиков.


![Image alt](https://github.com/KatyaZav/DA-in-GameDev-lab1/blob/main/Screens/3.2.jpg)

3) Написать код считывания цифр с поля ввода.

```py
public void Generate(string count)
    {
        try
        {
            int _count = Int32.Parse(count);
            Debug.Log(_count.GetType());
            Debug.Log("Start generated " + _count);
            MakeCubes(_count);
        }
        catch (Exception e) { Debug.Log("Smth wrong :) " + e); }
    }
```
4) Написать функцию создания кубов.

```py
 void MakeCubes(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Instantiate(cube);
        }
        Debug.Log("Generated " + count);
    }
```
5) Создать префаб куба и перенести его в переменную cube.
Создадим префаб куба.

![Image alt](https://github.com/KatyaZav/DA-in-GameDev-lab1/blob/main/Screens/3.3.jpg)


Создадим переменную cube.
```py
public GameObject cube;
```

Через инспектор добавим префаб куба в переменную.

![Image alt](https://github.com/KatyaZav/DA-in-GameDev-lab1/blob/main/Screens/3.4.jpg)


6) Настроить InputField.
Добавим запуск функции в поле считывания.

![Image alt](https://github.com/KatyaZav/DA-in-GameDev-lab1/blob/main/Screens/3.5.jpg)

7) Запустить программу и проверить работоспособность программы.
Все работает.


![Image alt](https://github.com/KatyaZav/DA-in-GameDev-lab1/blob/main/Screens/3.6.jpg)

## Выводы
За лабораторную работу я научилась создавать 3D объекты, настраивать RigidBody и работать с полем данных InputField. 

Я поработала с различными 3D объектами, материалами. Посмотрела, как изменяется поле Transform при переносе в родительский элемент и что изменяют поля в RigidBody. Создала генирацию кубов того количества, которое ввел пользователь.

Самым сложным заданием для меня оказалось третье. Сложностью этого задания для меня было то, что ввод количества кубов происходит после старта сцены, а не до. как бы я реализовала "упрощенный" вариант: завела бы в пустом объекте переменную, отвечающую за количество генирирующихся кубов, и заполняла бы ее через инспектор до запуска сцены. Однако, это противоречило бы условию.

## Powered by

**BigDigital Team: Denisov | Fadeev | Panov**
