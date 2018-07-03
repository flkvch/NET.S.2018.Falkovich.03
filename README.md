# Day 3

**Deadline 30.06.2018**   
* Правки по выполненнымранее задачам [Day 1](https://github.com/flkvch/NET.S.2018.Falkovich.01), [Day 2](https://github.com/flkvch/NET.S.2018.Falkovich.02)
* Тест методов сортировки на массивах большой размерности [Day 1](https://github.com/flkvch/NET.S.2018.Falkovich.01/blob/master/SortingAlgorithms.Tests/AlgorithmsTests.cs) 
* Реализовать [алгоритм FindNthRoot](https://github.com/flkvch/NET.S.2018.Falkovich.03/blob/12a20a28fb66cbfc14bdcacab20ca3a380e5b353/MathOperations/Operations.cs#L32) позволяющий вычислять корень n-ой степени ( n ∈ N ) из вещественного числа а методом Ньютона с заданной точностью. Разработаны модульные тесты ([NUnit](https://github.com/flkvch/NET.S.2018.Falkovich.03/blob/12a20a28fb66cbfc14bdcacab20ca3a380e5b353/MathOperations.Tests/OperationsTests.cs#L9)) для тестирования метода.


**Deadline 02.07.2018** 
* Внесены все изменения, согласно замечаниям в Deadline 30.06.2018 и в [Day 1](https://github.com/flkvch/NET.S.2018.Falkovich.01)
* Реализовать [метод FindNextBiggerNumber](https://github.com/flkvch/NET.S.2018.Falkovich.03/blob/45ffe21b6e939badbb2421494b27dcda308adb98/MathOperations/Operations.cs#L53), который принимает положительное целое число и возвращает ближайшее наибольшее целое, 
состоящее из цифр исходного числа, и null (или -1), если такого числа не существует.
Разработать модульные тесты [(NUnit)](https://github.com/flkvch/NET.S.2018.Falkovich.03/blob/45ffe21b6e939badbb2421494b27dcda308adb98/MathOperations.Tests/OperationsTests.cs#L28) для тестирования метода. 
Добавить к методу FindNextBiggerNumber возможность вернуть время нахождения заданного числа, рассмотрев различные языковые возможности. Разработать модульные тесты (NUnit или MS Unit Test) для тестирования метода.
* Добавлен сравнительный анализ скорости вычислений для реализаций алгоритмов с использованием строк и операции целочисленного деления для задачи #6 на [массивах большой размерности с большим количеством элементов](https://github.com/flkvch/NET.S.2018.Falkovich.02/blob/c67e5d693742a52f64884bac83dc6810e870620f/ArrayStringsAlgorithms.NUnitTests/AlgorithmTests.cs#L39) порядка int.MaxValue, a также [тест времени выполнения методов в linqpad](https://github.com/flkvch/NET.S.2018.Falkovich.02/blob/c67e5d693742a52f64884bac83dc6810e870620f/FilterDigit.linq#L4) на одном и том же случайно сгенерированном массиве.
* Разработать [класс](https://github.com/flkvch/NET.S.2018.Falkovich.03/blob/b787a01946808451fd3f00e2b8f14e542e9f95ea/MathOperations/GCD.cs#L9), позволяющий выполнять вычисления НОД по алгоритму Евклида для двух, трех и т.д. целых чисел. Методы класса помимо вычисления НОД должны предоставлять [дополнительную возможность определения значение времени](https://github.com/flkvch/NET.S.2018.Falkovich.03/blob/b787a01946808451fd3f00e2b8f14e542e9f95ea/MathOperations/GCD.cs#L89), необходимое для выполнения расчета. Добавить к разработанному классу методы, реализующие алгоритм Стейна (бинарный алгоритм Евклида) для расчета НОД двух, трех и т.д. целых чисел, а также методы, предоставляющие дополнительную возможность определения значение времени, необходимое для выполнения расчета. Рассмотреть различные возможности реализации методов, возвращающих время вычисления НОД. Разработать [модульные тесты](https://github.com/flkvch/NET.S.2018.Falkovich.03/blob/45ffe21b6e939badbb2421494b27dcda308adb98/MathOperations.Tests/GCDTests.cs#L10).
