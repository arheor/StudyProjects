title RuchkaLab31
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
z dd ?
; ������� ����
.code
main:
; ���������� z = y**2 + xy + x/y
mov EBX, [y] ; y -> EBX ( EBX = 3 = 0Ah )
mov EAX, EBX ; y -> EAX ( EAX = 3 = 0Ah )
mul EAX ; EAX = y**2 ( EAX = 9 = 64h )
; �������� ������������� ���������� � ECX
mov ECX, EAX ; x**2 -> ECX ( ECX = 100 = 64h )
; ��������� x*y
mov EAX, [x]
mul EBX ; EAX = x*y ( EAX = 30 = 1Eh )
; ���������� ������ � ������
add EAX, ECX ; 
; �������� � ��� ��������� ��������
mov ECX, EAX ; 
mov EAX, [x]
mov EBX, [y]
; ������� ������� ����� �������� (��. ������ ������� �������)
mov EDX, 0 ; 0 -> EDX ( EDX = 0 = 00h )
div EBX ; EAX = EAX / EBX 
add EAX, ECX ;
mov z, EAX 
; ����� �� ���������
quit:
mov eax, 0
invoke ExitProcess, eax
end main