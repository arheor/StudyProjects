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
x dd 10
y dd 3
z dd 5
; ������� ����
.code
main:
; ���������� f (x, y, z) = x*z - y + z
mov EBX, [x]
mov ECX, [y] 
mov EAX, [z] 
mul EBX 
sub ECX, EAX
add EAX, [z]
cdq
; ����� �� ���������
quit:
mov eax, 0
invoke ExitProcess, eax
end main