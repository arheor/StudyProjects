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
x dw 10h
y dw 02h
z dw 03h
; ������� ����
.code
main:
; ���������� f (x, y, z) = x - y * z
mov AX, [y]
mov BX, [z]  
mul BX ;AX*BX => y*z = 6
aam
mov BX, [x]
sub AX, BX ; x-y*z
aas
; ����� �� ���������
quit:
mov eax, 0
invoke ExitProcess, eax
end main