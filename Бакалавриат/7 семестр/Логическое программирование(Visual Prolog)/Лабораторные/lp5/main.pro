% Copyright

implement main
    open core, console, list

class predicates
    last:(integer)-> integer List.

clauses

%Задание 35.1. Написать функцию Elem=nth(N,Elem*), возвращающую значение
%N-го элемента Elem списка Elem*.

%Написать детерминированную функцию
%Elem=last(Elem*), возвращающую последний элемент Elem списка Elem*.
    last([_])=succeed.
    last(Elem*)=[_|last(Elem*)] :- Elem*=[_], !.

    run() :-
        Elem=last([2,4,3,1,9,4]),
        write(Elem),
        _= readLine().

end implement main

goal
    console::runUtf8(main::run).