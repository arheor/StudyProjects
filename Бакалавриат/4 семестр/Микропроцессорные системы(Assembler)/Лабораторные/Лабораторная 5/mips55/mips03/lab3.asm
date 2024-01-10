title RuchkaLab34
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
x dw 0FFFFh ; true
y dw 00000h ; false
; Сегмент кода
.code
main:
mov ax, [x] ; ax = x
mov bx, [y] ; bx = y
not ax ; not x
and bx, ax ; y and (not x)
mov ax, [x] ; ax = x
mov cx, [y] ; cx = y
xor ax,cx ; x xor y
not ax ; not(x xor y)
or bx, ax ; y and (not x) or (not(x xor y))
; Выход из программы
quit:
mov eax, 0
invoke ExitProcess, eax
end main