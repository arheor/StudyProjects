% Copyright

implement main
    open core, console

class facts
    point : (integer X, integer Y).

clauses
    point(1, 1).
    point(1, 2).
    point(1, 4).
    point(2, 1).
    point(2, 2).
    point(2, 4).
    point(3, 2).
    point(4, 1).
    point(4, 3).
    run() :-
        write("Координаты точек: "),
        nl, point(X, Y),
        write("(", X, ", ", Y, ")"), nl, fail; _ = readChar().

end implement main

goal
    console::run(main::run).
