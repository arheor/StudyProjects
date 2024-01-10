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
a dw 2
b dw 0
cc dw 3
x dw 4
; Сегмент кода
.code
;ax**2-bx+c     x<3 and b!=0
;(x-a)/(x-c)    x>3 and b=0
;x/c   
main:
xor EAX, EAX
xor EBX, EBX
xor ECX, ECX
xor EDX, EDX

mov AX, x ; ax = x
mov BX, 3 ; bx = 3
cmp AX, BX ; sravnenie
jnge one

mov AX, x ; ax = x
mov BX, 3 ; bx = 3
cmp AX, BX ; sravnenie
jg two

jmp three


one:
xor EAX, EAX
xor EBX, EBX

mov AX, b ; ax = b
mov BX, 0 ; bx = 0
cmp AX, BX ; sravneie
jne one_one
jmp three

one_one:
xor eax, eax
xor ebx, ebx
mov ax, x ; ax = b
mov bx, a ; bx = a
mul ax ; x**2
mul bx ;ax**2
mov cx, ax ; cx = ax**2
mov ax, b ; ax = b
mov bx, x ; bx = x
mul bx ; ax = b*x
sub cx, ax ; cx = ax**2 - b*x
mov ax, [cc] ; ax = c
add cx, ax ; cx = ax**2 - b*x + c
ret


two:
xor eax,eax
xor ebx,ebx
mov AX, b ; ax = b
mov BX, 0 ; bx = 0
cmp AX, BX ; sravnenie
je two_two
jmp three

two_two:
xor eax,eax
xor ebx,ebx
mov ax, x ; ax = x
mov bx, a ; bx = a
sub ax, bx ; ax = x - a
mov bx, x ; bx = x
mov cx, [cc] ; cx = c
sub bx, cx ; bx = x - c
;; mov dx, ax ; dx = x - a 
div bx ; ax = x - a / x - c
ret


three:
xor eax,eax
xor ebx,ebx
mov ax, x ; ax = x
mov bx, [cc] ; bx = c
div bx ; ax = x/c
ret


; Выход из программы
quit:
mov eax, 0
invoke ExitProcess, eax
end main