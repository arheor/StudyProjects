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
dd 1.000
dd 0.000
dd 1.402
dd 0.000

ydata label dword
dd 1.000
dd -0.344
dd -0.714
dd 0.000

zdata label dword
dd 1.000
dd 1.772
dd 0.000
dd 0.000

YPPdata label dword
dd 0FF995511h
dd 0FF112266h 
dd 0FF112266h 
dd 0FFFF0000h

result label dword
dd 4 dup (?)

; Сегмент кода
.code
main proc far
movups xmm0, [xdata]
movups xmm1, [ydata]
movups xmm2, [zdata]
movups xmm3, [YPPdata]

mulps xmm0, xmm3 ;
mulps xmm1, xmm3 ;
mulps xmm2, xmm3 ;

addps xmm0, xmm1
addps xmm0, xmm2

movups result, xmm0
quit:
mov eax, 0
invoke ExitProcess, eax
main endp
end main