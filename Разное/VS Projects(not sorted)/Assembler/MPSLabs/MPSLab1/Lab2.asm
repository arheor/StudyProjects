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
; Вычисление z = (x*y+1)/x**2
; Вычисляем x**2
mov EBX, [x] ; x -> EBX ( EBX = 10 = 0Ah )
mov EAX, EBX ; x -> EAX ( EAX = 10 = 0Ah )
mul EAX ; EAX = x**2 ( EAX = 100 = 64h )
; Сохраним промежуточные результаты в ECX
mov ECX, EAX ; x**2 -> ECX ( ECX = 100 = 64h )
; Вычисляем x*y
mov EAX, EBX ; x (уже хранимый в EBX) -> EAX ( EAX = 10 = 0Ah )
mov EBX, [y] ; y -> EBX ( EBX = 3 = 03h )
mul EBX ; EAX = x*y ( EAX = 30 = 1Eh )
; Прибавляем 1 к полученному произведению
add EAX, 1 ; EAX = x*у + 1 ( EAX = 31 = 1Ch )
; Приступаем к делению. Поместим знаменатель в EBX
mov EBX, ECX ; (y+1)**3 -> EBX ( EBX = 64 = 40h )
; Обнулим старшую часть делимого (см. работу команды деления)
mov EDX, 0 ; 0 -> EDX ( EDX = 0 = 00h )
div EBX ; EAX = EAX / EBX 
mov z, EAX ; EAX -> Z
; Выход из программы
quit:
mov eax, 0
invoke ExitProcess, eax
end main