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
xor ax, bx ; x xor y
mov bx, [x] ; bx = x
mov cx, [y] ; cx = y
and bx, cx ; x and y
not bx ; not (x and y)
or ax,bx ; (x xor y) or (not(x and y))
; ����� �� ���������
quit:
mov eax, 0
invoke ExitProcess, eax
end main