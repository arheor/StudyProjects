title RuchkaLab7
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
x db 00101011b
n dd 4
.code
main proc far
xor eax, eax
xor ebx, ebx

xor edx,edx
mov ecx,n
mov al,x
shr x, 1
adc dl,0
add bl,dl

iteration: 
xor edx,edx  
mov al,x
shr x, 1
shr x, 1
adc dl,0
add bl,dl ; колличество установленных бит в нечетных позициях  в bl
loop iteration
 
quit:
mov EAX, 0
invoke ExitProcess, EAX
main endp
; Конец программы
end main
