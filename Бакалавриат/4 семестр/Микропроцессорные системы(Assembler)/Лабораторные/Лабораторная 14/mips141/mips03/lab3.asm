title RuchkaLab14
.686
.xmm
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

xdata label dword
dd -888.55854
dd 154.56454
dd 84.2154
dd 0.0007

ydata label dword
dd 2.568448
dd -21.55014
dd 7774.7808
dd 1.88089

zdata label dword
dd 2.568448
dd 154.56454
dd 1.88089
dd 0.0007

fdata label dword
dd 4 dup (?)

;fx dd 0380h ; q8 fx = 3.5
;fy dd 00C0h ; q8 fy = 0.75
;fz dd 0080h ; q8 fz = 0.5

; Сегмент кода
.code
main proc far
;f (x, y, z) = x*z - y/z + z
movups xmm0, [xdata]
movups xmm1, [ydata]
movups xmm2, [zdata]

mulps xmm0, xmm2 ; x*z(1)
divps xmm1, xmm2 ; y/z(2)
subps xmm0, xmm1 ; (1) - (2) (3)
addps xmm0, xmm1 ; (3) + z
quit:
mov eax, 0
invoke ExitProcess, eax
main endp
end main