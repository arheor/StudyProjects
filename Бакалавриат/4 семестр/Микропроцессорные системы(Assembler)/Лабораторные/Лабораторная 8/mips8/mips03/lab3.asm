title RuchkaLab8
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
x dd 3
n dd 3
; Сегмент кода
.code

stepen proc
addstepen:
shl eax, 1
loop addstepen
ret
stepen endp

main proc far
mov eax, [x]
mov ecx, [n]
call stepen

;call stepen
quit:
mov eax, 0
invoke ExitProcess, eax
main endp
end main