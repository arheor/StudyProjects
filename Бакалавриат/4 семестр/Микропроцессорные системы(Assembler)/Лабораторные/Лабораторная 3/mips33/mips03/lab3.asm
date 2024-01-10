title RuchkaLab31
.586
.model flat, stdcall
option casemap :none ; case sensitive
; Раздел подключения библиотек
include \masm32\include\windows.inc
include \masm32\include\kernel32.inc
include \masm32\include\user32.inc
includelib \masm32\lib\kernel32.lib
includelib \masm32\lib\user32.lib
; Сегмент данных
.data
x dd 10
y dd 3
z dd ?
; Сегмент кода
.code
main:
; Вычисление z = y**2 + xy + x/y
mov EBX, [y] ; y -> EBX ( EBX = 3 = 0Ah )
mov EAX, EBX ; y -> EAX ( EAX = 3 = 0Ah )
mul EAX ; EAX = y**2 ( EAX = 9 = 64h )
; Сохраним промежуточные результаты в ECX
mov ECX, EAX ; x**2 -> ECX ( ECX = 100 = 64h )
; Вычисляем x*y
mov EAX, [x]
mul EBX ; EAX = x*y ( EAX = 30 = 1Eh )
; складываем первое и второе
add EAX, ECX ; 
; помещаем в есх результат сложения
mov ECX, EAX ; 
mov EAX, [x]
mov EBX, [y]
; Обнулим старшую часть делимого (см. работу команды деления)
mov EDX, 0 ; 0 -> EDX ( EDX = 0 = 00h )
div EBX ; EAX = EAX / EBX 
add EAX, ECX ;
mov z, EAX 
; Выход из программы
quit:
mov eax, 0
invoke ExitProcess, eax
end main