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
pstr1 db 4, 'ABCD'
pstr2 db 4, 'ABCD'
; Сегмент кода
.code

equal:
mov ax, 1
ret

main proc
xor eax,eax ;обнуление регистров
xor ebx,ebx
xor ecx,ecx
xor edi,edi
xor esi,esi
cld ; переключает флаг df
mov ecx, 5 ;задает счетчик
lea esi, pstr1 ; 
lea edi, pstr2 ;
repe cmpsb
je equal ; Переход, если строки одинаковы 

notequal:
mov ax, 0
quit:
mov eax, 0
invoke ExitProcess, eax
main endp
end main