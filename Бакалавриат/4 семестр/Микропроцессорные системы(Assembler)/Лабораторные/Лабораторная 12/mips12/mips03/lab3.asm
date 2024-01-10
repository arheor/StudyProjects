title RuchkaLab34
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
x dw 3257h ; 12887d
y dw 20A5h ; 8357d
z dw 3405h ; 13317d
r dw 0
; Сегмент кода
.code
main:
; Вычисление f (x, y, z) = x - y * z
xor EAX, EAX ; очищаем регистры
xor EBX, EBX
xor EDX, EDX
xor ECX, ECX
xor ESI, ESI
xor EDI, EDI
mov al, byte ptr [y] ; al = A5h
mov ah, byte ptr [z] ; ah = 05h
mul ah ; al*ah -> ax = 339h
mov bx,ax ; bx = 339h
mov al, byte ptr[y + 1] ; al = 20h
mov ah, byte ptr[z] ; ah = 05h
mul ah ; ax = A0h
mov cx, ax ; cx = A0h
mov al, byte ptr[y] ; al = A5h
mov ah, byte ptr[z + 1] ; ah = 34h
mul ah ; ax = 2184h
mov si,ax ; si = 2184h
mov al, byte ptr[y + 1] ; al = 20h
mov ah, byte ptr[z + 1] ; ah = 34h
mul ah ; ax = 680h
mov di, ax ; di = 680h
add word ptr[r + 0],bx ;
adc word ptr[r + 1], cx ;
adc word ptr[r + 1], si ;
adc word ptr[r + 2], di ;
mov cx, r ; cx = 2739h


mov al, byte ptr[x] ; al = 57h
mov ah, byte ptr[r] ; ah = 39h
sub al,ah ; al = 1Eh
mov bl, al
mov al, byte ptr[x + 1] ; al = 32h
mov ah, byte ptr[r + 1] ; ah = 27h
sbb al,ah ;  al = 0Bh                
mov bh, al ; bx = 0B1Eh  - otvet

;proveryaem
xor EAX, EAX
xor EBX, EBX
xor EDX, EDX
mov AX, [y]
mov BX, [z]
mul BX ;
mov bx, x
sub bx, ax ; bx = 0B1Eh  - otvet

; Выход из программы
quit:
mov eax, 0
invoke ExitProcess, eax
end main