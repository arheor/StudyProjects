title ruchkalab
.686
.mmx
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
; ������ ��� ���������
; ��������� ������� ��������, ����� �� 2 ��������
RGBdata label dword
dd 0FFFF0000h ; ARGB = Red (no opacity)
dd 0FF995511h ; ARGB
dd 0FF112266h ; ARGB
dd 0FF112266h ; ARGB
dd 0FFFF0000h ; ARGB = Red (no opacity)
db 0, 0, 255, 255 ; B, G, R, A = Red (no opacity)
; ������ ��� �������� ������������ ������
YUVdata label dword
dd 6 dup (?)
;dd 00FFFF00h ; CMYK = Red
;db 00, 255, 255, 0 ; K, Y, M, C
; ������� �������������
t_matrix_q7 label dword
; ��-�� ������� �������� ���������� ������ � �������� �������
; 0.0722 0.7152 0.2126, 0
db 00001001b, 01011011b , 00011011b, 0
; 0.436 -0.33609 -0.09991 0
db 00110111b, 11010101b, 11110110b, 0
; -0.05669 -0.55861 0.615 0
db 11111001b, 10111001b, 01001110b, 0
; ������� ������� (� �������� �������)
shft_matrix label dword
; 0 Y U V
db 0, 0, 128, 128
; ������� ����
.code
main proc far
; ��������� ������ ������������� ������
lea ESI, RGBdata
lea EDI, YUVdata
mov ECX, 6
data_processing:
; �������� ������� �������� ��������
push ECX
; �������� ����� ������� �������������
lea EBX, dword ptr [t_matrix_q7]
pxor mm0, mm0 ; ��������� 0
xor EDX, EDX ; �������� ��������� YUV
; ��������� ������� �������
movd mm4, dword ptr [shft_matrix]
; ��������� ������� �������
punpcklbw mm4, mm0 ; [0A|0R|0G|0B]
; 1. �������� Y
; ��������� RGB
lodsd ;mov EAX, dword ptr [ESI]
movd mm1, EAX
; ��������� RGB
punpcklbw mm1, mm0 ; [0A|0R|0G|0B]
; ��������� ������� ������ 1 [0XYZ] � q7
mov EAX, dword ptr [EBX]
movd mm7, EAX
; ��������� ������ 1
punpcklbw mm7, mm0 ; [00|0X|0Y|0Z]
; ������� �������� ���������� �������� ����� ��� ������������� �����
psllw mm7, 8 ; ������� ������� ����
psraw mm7, 8 ; ��������� ���
; ��������� ������������ A*0 + R*X | G*Y + B*Z
pmaddwd mm7, mm1

; ������ ������� � ������� ����� ����������
movq mm6, mm7
psrlq mm6, 32
paddsw mm7, mm6 ; A*0 + R*X + G*Y + B*Z
psraw mm7, 7 ; q14 => q7
; ������������ ����� � ������� ������
psrlq mm4, 16 ; ([VUY0] => [0UVY])
paddw mm7, mm4
; ����������� ��������� � ������ ������������
packuswb mm7, mm0
movd EAX, mm7 ; ��������� Y
mov DL, AL ; ��������� Y � DL
; 2. �������� U
; ��������� ������� ������ 2 [0XYZ] � q7
add EBX, 4
mov EAX, dword ptr [EBX]
movd mm7, EAX
; ��������� ������ 2
punpcklbw mm7, mm0 ; [00|0X|0Y|0Z]
; ������� �������� ���������� �������� ����� ��� ������������� �����
psllw mm7, 8 ; ������� ������� ����
psraw mm7, 8 ; ��������� ���
; ��������� ������������ A*0 + R*X | G*Y + B*Z
pmaddwd mm7, mm1
; ������ ������� � ������� ����� ����������
movq mm6, mm7
psrlq mm6, 32
paddw mm7, mm6 ; A*0 + R*X + G*Y + B*Z
psraw mm7, 7 ; q14 => q7
; ������������ ����� � ������� ������
psrlq mm4, 16 ; ([0VUY] => [00UV])
paddsw mm7, mm4
; ����������� ��������� � ������ ������������
packuswb mm7, mm0
movd EAX, mm7 ; ��������� Y
shl EDX, 8 ; ����������� ����� ��� ����������
mov DL, AL ; ��������� Y � DL
; 3. �������� V

; ��������� ������� ������ 3 [0XYZ] � q7
add EBX, 4
mov EAX, dword ptr [EBX]
movd mm7, EAX
; ��������� ������ 3
punpcklbw mm7, mm0 ; [00|0X|0Y|0Z]
; ������� �������� ���������� �������� ����� ��� ������������� �����
psllw mm7, 8 ; ������� ������� ����
psraw mm7, 8 ; ��������� ���
; ��������� ������������ A*0 + R*X | G*Y + B*Z
pmaddwd mm7, mm1
; ������ ������� � ������� ����� ����������
movq mm6, mm7
psrlq mm6, 32
paddw mm7, mm6 ; A*0 + R*X + G*Y + B*Z
psraw mm7, 7 ; q14 => q7
; ������������ ����� � ������� ������
psrlq mm4, 16 ; ([00VU] => [000U])
paddsw mm7, mm4
; ����������� ��������� � ������ ������������
packuswb mm7, mm0
movd EAX, mm7 ; ��������� Y
shl EDX, 8 ; ����������� ����� ��� ����������
mov DL, AL ; ��������� Y � DL
; �������� YUV
mov EAX, EDX
stosd ;mov dword ptr [EDI], EAX
; � ���������� ��������
add EDI, 4
add ESI, 4
pop ECX
; ��� �������� ����� 128 ����, �������� ������� �� ��������
; ������� ��� �� ������� �� ����� ����� � ����������� �� ������ ����
loop jmp_to_data
; �� ��������� ����� �������
jmp quit
jmp_to_data:
jmp data_processing
quit:
mov eax, 0
invoke ExitProcess, eax
main endp
end main
main endp