﻿% Copyright

implement main
    open core, console

class facts
    месяц : (string Имя_Месяца, unsigned Номер_по_порядку, unsigned Количество_дней).

clauses
    месяц("Январь", 1, 31).
    месяц("Февраль", 2, 28).
    месяц("Март", 3, 31).
    месяц("Апрель", 4, 30).
    месяц("Май", 5, 31).
    месяц("Июнь", 6, 30).
    месяц("Июль", 7, 31).
    месяц("Август", 8, 31).
    месяц("Сентябрь", 9, 30).
    месяц("Октябрь", 10, 31).
    месяц("Ноябрь", 11, 30).
    месяц("Декабрь", 12, 31).

    run() :-

%    Задача 1

%        месяц(X, Y, _),
%        Y mod 2 = 0,
%        write(X),
%        nl,
%        fail
%        or
%        _ = readChar().

%     Задача 2

%        месяц(X, _, Z),
%        Z = 31,
%        write(X),
%        nl,
%        fail
%        or
%        _ = readChar().

end implement main

goal
    console::run(main::run).
