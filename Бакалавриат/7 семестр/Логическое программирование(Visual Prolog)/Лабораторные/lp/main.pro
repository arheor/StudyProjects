% Copyright

implement main
    open core, console, string, math, file

clauses
    run() :-
%    задача 1
%    setConsoleTitle("Определение значения хеш-функции для строки"),
%    Str = readLine(), nl,
%    write(hash(Str)),
%    clearInput(),
%    _ = readchar().

%    задача 2
%    setConsoleTitle("Разделения строки на две равные по длине части"),
%    Str = readLine(), nl,
%    Dlina = length(Str) div 2,
%    front(Str, Dlina, First, Last),
%    write(First, " ", Last),
%    clearInput(),
%    _ = readchar().

%    задача 3
%    setConsoleTitle("Определения значения выражения"),
%    write("Введите число А = "),
%    A = read(),
%    write("Введите число В = "),
%    B = read(),
%    write("Введите число С = "),
%    C = read(),
%    Result = max(A,B,C) - min(B,C),
%    write("max(A,B,C) - min(B,C) = ", Result),
%    clearInput(),
%    _ = readchar().

%    задача 4
%    setConsoleTitle("Определения суммы чисел"),
%    A = random(10),
%    write("Число А = ", A), nl,
%    write("Введите число В, В = "),
%    B = read(), nl,
%    write("Ответ: A + В = ", A + B),
%    clearInput(),
%    _ = readChar().

%    задача 5
%    setConsoleTitle("Определения суммы чисел"),
%    write("Введите число А = "),
%    A = read(),
%    write("Введите число В = "),
%    B = read(),
%    write("Введите число С = "),
%    C = read(),
%    Result = max(A,B,C) - min(B,C),
%    write("max(A,B,C) - min(B,C) = ", Result),
%    File = write("Число А = ", A, "\nЧисло В = ", B, "\nЧисло С = ", C, "\nmax(A,B,C) - min(B,C) = ", Result ),
%    writeString("ansi.txt", File , false),
%    clearInput(),
%    _ = readchar().

    setConsoleTitle("Определение системной информации"),
    ComputerName = systemInformation_api::getComputerName(),
    write("\nИмя компьютера: ",ComputerName),
    UserName = systemInformation_api::getUserName(),
    write("\nИмя пользователя: ",UserName),
    CodePage = console_native::getConsoleCP(),
    write("\nКодовая страница: ",CodePage),
    Software = registry::getSubKeys(registry::currentUser(),"Software"),
    write("\n\nПрограммное обеспечение:\n", Software),nl,
    Hardware = registry::getAllValues(registry::localMachine(),
    "Hardware\\Description\\System"),
    write("\n\nАппаратное обеспечение:\n", Hardware),
    writeString("ansi.txt", write("\nИмя компьютера: ", ComputerName, "\nИмя пользователя: ", UserName, "\nКодовая страница: ",CodePage, "\n\nПрограммное обеспечение:\n", Software, "\n\nАппаратное обеспечение:\n", Hardware), false),
    _ = readchar().

end implement main

goal
    console::run(main::run).