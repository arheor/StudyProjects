title RuchkaLab32
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
; ���������� z = (x-y)/(xy+1);
;x*y
mov EAX, [x] ; x -> EBX ( EAX = 10 )
mov EBX, [y] ; y -> EAX ( EBX = 3 )
sub EAX, EBX ; x-y
; �������� ������������� ���������� � ECX
mov ECX, EAX ; x-y -> ECX ( ECX = 7 )
; ��������� x*y
mov EAX, [y]
mul EBX ; x * y = 30
add EAX, 1; x*y+1
; ���������� � �������. �������� ����������� � EBX
mov EBX, EAX ; 
;�������� ��������� � EAX
mov EAX, ECX;  
; ������� ������� ����� �������� (��. ������ ������� �������)
mov EDX, 0 ; 0 -> EDX ( EDX = 0 = 00h )
div EBX ; EAX = EAX / EBX 
mov z, EAX ; EAX -> Z
; ����� �� ���������
quit:
mov eax, 0
invoke ExitProcess, eax
end main