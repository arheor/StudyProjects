﻿% Copyright

implement main
    open core, console, string

%задача 32.1--------------------------------------------------------
%
class facts
    автомобиль : (string).
    цвет : (string).

clauses
    автомобиль("КАМАЗ").
    автомобиль("Toyota").
    автомобиль("BMW").
    цвет("зеленый").
    цвет("красный").

    run() :-
        автомобиль(Авто), цвет(Цвет),
        write(Цвет, " - ", Авто),
        nl,
        fail
        or
        write("Конец перебора"),
        _ = readchar().

%задача 32.2--------------------------------------------------------
%
%class facts
%    автомобиль : (string).
%
%clauses
%    автомобиль("КАМАЗ").
%    автомобиль("Toyota").
%    автомобиль("BMW").
%
%    run() :-
%        автомобиль(Авто),
%        автомобиль(Авто2),
%        Авто > Авто2,
%        write(Авто, " - ", Авто2),
%        nl,
%        fail
%        or
%        write("Конец перебора"),
%        _ = readchar().

%        задача 32.3------------------------------------------------
%
%class facts
%    point : (integer X, integer Y).
%
%clauses
%    point(1, 1).
%    point(1, 2).
%    point(1, 4).
%    point(2, 1).
%    point(2, 2).
%    point(2, 4).
%    point(3, 2).
%    point(4, 1).
%    point(4, 3).
%
%    run() :-
%        write("Координаты точек: "),
%        nl,
%        point(X, Y),
%        writef("(%, %)", X, Y),
%        nl,
%        fail
%        or
%        _ = readchar().

%        задание 32.4-------------------------------------------------------------
%
%class facts
%    point : (integer X, integer Y).
%
%clauses
%    point(1, 1).
%    point(1, 2).
%    point(1, 4).
%    point(2, 1).
%    point(2, 2).
%    point(2, 4).
%    point(3, 2).
%    point(4, 1).
%    point(4, 3).
%
%    run() :-
%        write("Точки, где Х + У = 5:"),
%        nl,
%        point(X, Y),
%        X + Y = 5,
%        writef("(%, %)", X, Y),
%        nl,
%        fail
%        or
%        _ = readChar().

%    задача 32.13--------------------------------------------------------
%
%class facts
%    месяц : (string Имя_Месяца, unsigned Номер_по_порядку, unsigned Количество_дней).
%
%clauses
%    месяц("Январь", 1, 31).
%    месяц("Февраль", 2, 28).
%    месяц("Март", 3, 31).
%    месяц("Апрель", 4, 30).
%    месяц("Май", 5, 31).
%    месяц("Июнь", 6, 30).
%    месяц("Июль", 7, 31).
%    месяц("Август", 8, 31).
%    месяц("Сентябрь", 9, 30).
%    месяц("Октябрь", 10, 31).
%    месяц("Ноябрь", 11, 30).
%    месяц("Декабрь", 12, 31).
%
%    run() :-
%        месяц(X, Y, _),
%        Y mod 2 = 0,
%        write(X),
%        nl,
%        fail
%        or
%        _ = readChar().

%     Задача 32.14------------------------------------------------------
%
%class facts
%    месяц : (string Имя_Месяца, unsigned Номер_по_порядку, unsigned Количество_дней).
%
%clauses
%    месяц("Январь", 1, 31).
%    месяц("Февраль", 2, 28).
%    месяц("Март", 3, 31).
%    месяц("Апрель", 4, 30).
%    месяц("Май", 5, 31).
%    месяц("Июнь", 6, 30).
%    месяц("Июль", 7, 31).
%    месяц("Август", 8, 31).
%    месяц("Сентябрь", 9, 30).
%    месяц("Октябрь", 10, 31).
%    месяц("Ноябрь", 11, 30).
%    месяц("Декабрь", 12, 31).
%
%    run() :-
%        write("Месяцы, где количество дней = 31:"), nl,
%        месяц(X, _, 31),
%        write(X),
%        nl,
%        fail
%        or
%        _ = readChar().

%    задача 32.19-------------------------------------------------------
%
%clauses
%    run() :-
%        write("Введите строку:"), nl,
%        X = readLine(),
%        isLowerCase(X), !,
%        write("Строка содержит только строчные символы"), _ = readChar();
%        write("В строке не только строчные символы"), _ = readChar().

%    задача 32.20-------------------------------------------------------
%
%clauses
%    run() :-
%        write("Введите строку: "), nl,
%        X = readLine(),
%        (hasAlpha(X),
%        write("Строка состоит из букв"),
%        _= readChar(), !;
%        hasDecimalDigits(X),
%        write("Строка состоит из цифр"),
%        _= readChar(), !;
%        write("Строка cодержит произвольные символы"),
%        _= readChar()).

end implement main

goal
    console::run(main::run).
