% Copyright

implement main
    open core, console

class facts
    автомобиль : (string).
    цвет : (string).

clauses
%    задание 1
    автомобиль("КАМАЗ").
    автомобиль("Toyota").
    автомобиль("BMW").
    цвет("зеленый").
    цвет("красный").

    run() :-
        цвет(Цвет),
        автомобиль(Авто),
        write(Цвет, " - ", Авто),
        nl,
        fail;
        write("Конец перебора"),
        _ = readchar().

%        задание 2




end implement main

goal
    console::run(main::run).
