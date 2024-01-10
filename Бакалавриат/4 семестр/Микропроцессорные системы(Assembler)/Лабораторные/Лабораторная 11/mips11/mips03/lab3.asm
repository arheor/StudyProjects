title RuchkaLab11
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

fx dd 0380h ; q8 fx = 3.5
fy dd 00C0h ; q8 fy = 0.75
fz dd 0080h ; q8 fz = 0.5

; Сегмент кода
.code
main proc
;f (x, y, z) = x*z - y/z + z
xor eax,eax
xor ebx,ebx
xor ecx,ecx

mov eax, fx
mov ebx, fz
mul ebx
shr eax, 8
mov ecx, eax
mov eax, fy
shl eax, 8
mov ebx, fz
div ebx
xchg eax, ecx ; eax = 01C0h = 1.75   ebx = 0180h = 1.5
sub eax, ecx
mov ebx, fz
add eax, ebx ; otvet eax = 00C0h = 0.75

quit:
mov eax, 0
invoke ExitProcess, eax
main endp
end main