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
x dd 0.005 ;
z dt 0.0 ; z:=0h
a dt 1.0
; Сегмент кода
.code
main proc
; х**2+log2(10)
fld x    ; ST(0)=x
fld x    ; ST(0)=x, st(1)=x
fmul     ; st(0) = x**2
FLDL2T   ; st(0) = log2(10)
faddp     ; s(0)+st(1)
fbstp z  ; z = st(0)
; x**2+x
fld x    ; ST(0)=x
fld x	 ; ST(0)=x
fmulp	 ; st(0) = x**2
fld x	 ; ST(0)=x
faddp     ; st(0)+st(1) = x**2 + x
fbstp z  ;z = st(0)
; (-x**2)/log10(2)
fld x    ; ST(0)=x
fchs ; st(0) = -x
fld x	 ;ST(0)=x
fchs ; st(0) = -x
fmulp ; st(0)*st(1) = -x**2
FLDLG2 ; st(0) = log10(2)
fdivp ; st(1)/st(0) = (-x**2)/log10(2)
fbstp z ;z = st(0)
; log2(10)+X**3
FLDL2T   ;st(0) = log2(10)
fld x    ; ST(0)=x
fld x	 ;  ST(0)=x
fld x ; ST(0)=x
fmulp ; st(0)*st(1) = x**2
fmulp ; st(0)*st(1) = x**3
faddp ; log2(10)+X**3
fbstp z ;z = st(0)
; cos(1/X)
fld a ;st(0) = 1
fld x ;st(0) = x
fdivp st(1), st(0) ; 1/x
fcos ; cos(1/x)
fbstp z ;z = st(0)
quit:
mov eax, 0
invoke ExitProcess, eax
main endp
end main