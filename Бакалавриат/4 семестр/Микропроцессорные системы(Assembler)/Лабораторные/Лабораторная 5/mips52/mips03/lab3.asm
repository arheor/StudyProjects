title RuchkaLab34
.586
.model flat, stdcall
option casemap :none ; case sensitive
; ������ ����������� ���������
include \masm32\include\windows.inc
include \masm32\include\kernel32.inc
include \masm32\include\user32.inc
includelib \masm32\lib\kernel32.lib
includelib \masm32\lib\user32.lib
; ������� ������
.data
x dw 0FFFFh ; true
y dw 00000h ; false
; ������� ����
.code
main:
mov ax, [x] ; ax = x
mov bx, [y] ; bx = y
and ax, bx ; ax = x and y
not ax ; ax = not (x and y)
mov bx, [x] ; bx = x
mov cx, [y] ; cx = y
xor bx, cx ; bx = x xor y
or ax, bx ; (not(x and y)) or (x xor y)
; ����� �� ���������
quit:
mov eax, 0
invoke ExitProcess, eax
end main