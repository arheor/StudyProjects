title RuchkaLab8
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
pstr1 db 4, 'ABCD'
pstr2 db 4, 'ABCD'
; ������� ����
.code

equal:
mov ax, 1
ret

main proc
xor eax,eax ;��������� ���������
xor ebx,ebx
xor ecx,ecx
xor edi,edi
xor esi,esi
cld ; ����������� ���� df
mov ecx, 5 ;������ �������
lea esi, pstr1 ; 
lea edi, pstr2 ;
repe cmpsb
je equal ; �������, ���� ������ ��������� 

notequal:
mov ax, 0
quit:
mov eax, 0
invoke ExitProcess, eax
main endp
end main