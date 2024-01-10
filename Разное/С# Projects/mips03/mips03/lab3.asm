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
; ���������� z = (x*y+1)/x**2
; ��������� x**2
mov EBX, [x] ; x -> EBX ( EBX = 10 = 0Ah )
mov EAX, EBX ; x -> EAX ( EAX = 10 = 0Ah )
mul EAX ; EAX = x**2 ( EAX = 100 = 64h )
; �������� ������������� ���������� � ECX
mov ECX, EAX ; x**2 -> ECX ( ECX = 100 = 64h )
; ��������� x*y
mov EAX, EBX ; x (��� �������� � EBX) -> EAX ( EAX = 10 = 0Ah )
mov EBX, [y] ; y -> EBX ( EBX = 3 = 03h )
mul EBX ; EAX = x*y ( EAX = 30 = 1Eh )
; ���������� 1 � ����������� ������������
add EAX, 1 ; EAX = x*� + 1 ( EAX = 31 = 1Ch )
; ���������� � �������. �������� ����������� � EBX
mov EBX, ECX ; (y+1)**3 -> EBX ( EBX = 64 = 40h )
; ������� ������� ����� �������� (��. ������ ������� �������)
mov EDX, 0 ; 0 -> EDX ( EDX = 0 = 00h )
div EBX ; EAX = EAX / EBX 
mov z, EAX ; EAX -> Z
; ����� �� ���������
quit:
mov eax, 0
invoke ExitProcess, eax
end main