;������� � ����� ������������ �� 8086
IDEAL
P386
model large
stack stk386
stk386 = 400h
stk0 = 200h
;������ ��� ������� (����������������)
macro debug
local j, tbl
jmp j
tbl db '0123456789ABCDEF'
j:
push ax
push bx
push cx
push dx
push ax
and ax, 0F000h
shr ax, 12
push ds
push cs
pop ds
mov bx, offset tbl
xlat
pop ds
mov [si], al
pop ax
push ax
and ax, 0F00h
shr ax, 8
inc si
push ds
push cs
pop ds
mov bx, offset tbl
xlat
pop ds
mov [si], al
pop ax
push ax
and ax, 0F0h
shr ax, 4
inc si
push ds
push cs
pop ds
mov bx, offset tbl
xlat
pop ds
mov [si], al
pop ax
push ax
and ax, 0Fh
inc si
push ds
push cs
pop ds
mov bx, offset tbl
xlat
pop ds
mov [si], al
pop ax
pop dx
pop cx
pop bx
pop ax
endm
;������ ��� ��������� ��������� � ������������ debug
macro aux data, offs, string
push ax
push si
mov ax, data
mov si, offset string+offs
debug
pop si
pop ax
endm
;������ ��� ���������� ��������������� ����� �����������
macro load_addr des, seg_addr
xor eax, eax
mov ax, seg_addr
shl eax, 4 
mov [(descr ptr des).base_l], ax
rol eax, 16
mov [(descr ptr des).base_m], al
endm
;������ ��� ������ �� ����� ����������� � ��������������� ���������
macro lineout line, pos, attr, len
local a, b
push ax
push cx
push si
push di
mov si, offset line
mov cx, len
mov di, [word ptr pos]
mov ah, attr
a:
lodsb
stosw
loop a
add [word ptr pos], 160
cmp [word ptr pos], 24*160
jb b
mov [word ptr pos], 0
b:
pop di
pop si
pop cx
pop ax
endm
struc descr
limit dw 0
base_l dw 0
base_m db 0
attr_1 db 0
attr_2 db 0
base_h db 0
ends descr
struc trap
offs_l dw 0
sel dw 16
rsrv db 0
attr db 8Fh
offs_h dw 0
ends trap
DATASEG
gdt_null descr <0,0,0,0,0,0> ; 00
gdt_data descr <data_size-1,0,0,92h,0,0> ; 08
gdt_code descr <code_size-1,0,0,9Ah,0,0> ; 16
gdt_stack descr <stk386-1,0,0,92h,0,0> ; 24
gdt_screen descr <4095,8000h,0Bh,092h,0,0> ; 32
gdt_tss_386 descr <103,0,0,89h,0,0> ; 40
gdt_tss_86 descr <103,0,0,8Bh,0,0> ; 48 (B - ������� 32-������ TSS)
gdt_size = $-gdt_null
idt trap <exc_0>
trap <exc_1>
trap <exc_2>
trap <exc_3>
trap <exc_4>
trap <exc_5>
trap <exc_6>
trap <exc_7>
trap <exc_8>
trap <exc_9>
trap <exc_0a>
trap <exc_0b>
trap <exc_0c>
trap <exc_0d>
trap <exc_0e>
trap <exc_0f>
trap <exc_10>
trap <exc_11>
trap <exc_12>
trap <exc_13>
trap <exc_14>
trap <exc_15>
trap <exc_16>
trap <exc_17>
trap <exc_18>
trap <exc_19>
trap <exc_1a>
trap <exc_1b>
trap <exc_1c>
trap <exc_1d>
trap <exc_1e>
trap <exc_1f>
trap 224 dup (<exc_xx>)
idt_size = $-idt
idtr_real dw 3FFh, 0, 0
pdescr dp 0
mes db 10,13,'Real mode','$'
string db '**** **** **** **** **** **** ****'
string_len = $-string
tss_386 dw 104 dup(0) ; TSS ������ 386
tss_86 dw 104 dup(0) ; TSS ������ V86
string_pos dw 160*10
home_sel dw home
dw 10h
data_size = $-gdt_null
ends
CODESEG
assume cs: @code, ds:@data
sttt equ $
proc exc_0 ;���������� ���������� 00h
mov ax, 8
mov ds, ax
mov ax, 32
mov es, ax
mov ax, 0
jmp [dword ptr home_sel]
endp
proc exc_1 ;���������� ���������� 01h
mov ax, 8
mov ds, ax
mov ax, 32
mov es, ax
mov ax, 1
jmp [dword ptr home_sel]
endp
proc exc_2 ;���������� ���������� 02h
mov ax, 8
mov ds, ax
mov ax, 32
mov es, ax
mov ax, 2
jmp [dword ptr home_sel]
endp
proc exc_3 ;���������� ���������� 03h
mov ax, 8
mov ds, ax
mov ax, 32
mov es, ax
mov ax, 3
jmp [dword ptr home_sel]
endp
proc exc_4 ;���������� ���������� 04h
mov ax, 8
mov ds, ax
mov ax, 32
mov es, ax
mov ax, 4
jmp [dword ptr home_sel]
endp
proc exc_5 ;���������� ���������� 05h
mov ax, 8
mov ds, ax
mov ax, 32
mov es, ax
mov ax, 5
jmp [dword ptr home_sel]
endp
proc exc_6 ;���������� ���������� 06h
mov ax, 8
mov ds, ax
mov ax, 32
mov es, ax
mov ax, 6
jmp [dword ptr home_sel]
endp
proc exc_7 ;���������� ���������� 07h
mov ax, 8
mov ds, ax
mov ax, 32
mov es, ax
mov ax, 7
jmp [dword ptr home_sel]
endp
proc exc_8 ;���������� ���������� 08h
mov ax, 8
mov ds, ax
mov ax, 32
mov es, ax
mov ax, 8
jmp [dword ptr home_sel]
endp
proc exc_9 ;���������� ���������� 09h
mov ax, 8
mov ds, ax
mov ax, 32
mov es, ax
mov ax, 9
jmp [dword ptr home_sel]
endp
proc exc_0a ;���������� ���������� 0Ah
mov ax, 8
mov ds, ax
mov ax, 32
mov es, ax
mov ax, 0Ah
jmp [dword ptr home_sel]
endp
proc exc_0b ;���������� ���������� 0Bh
mov ax, 8
mov ds, ax
mov ax, 32
mov es, ax
mov ax, 0Bh
jmp [dword ptr home_sel]
endp
proc exc_0c ;���������� ���������� 0Ch
mov ax, 8
mov ds, ax
mov ax, 32
mov es, ax
mov ax, 0Ch
jmp [dword ptr home_sel]
endp
proc exc_0d ;���������� ���������� 0Dh
mov ax, 8
mov ds, ax
mov ax, 32
mov es, ax
mov ax, 0Dh
jmp [dword ptr home_sel]
endp
proc exc_0e ;���������� ���������� 0Eh
mov ax, 8
mov ds, ax
mov ax, 32
mov es, ax
mov ax, 0Eh
jmp [dword ptr home_sel]
endp
proc exc_0f ;���������� ���������� 0Fh
mov ax, 8
mov ds, ax
mov ax, 32
mov es, ax
mov ax, 0Fh
jmp [dword ptr home_sel]
endp
proc exc_10 ;���������� ���������� 10h
mov ax, 8
mov ds, ax
mov ax, 32
mov es, ax
mov ax, 10h
jmp [dword ptr home_sel]
endp
proc exc_11 ;���������� ���������� 11h
mov ax, 8
mov ds, ax
mov ax, 32
mov es, ax
mov ax, 11h
jmp [dword ptr home_sel]
endp
proc exc_12 ;���������� ���������� 12h
mov ax, 8
mov ds, ax
mov ax, 32
mov es, ax
mov ax, 12h
jmp [dword ptr home_sel]
endp
proc exc_13 ;���������� ���������� 13h
mov ax, 8
mov ds, ax
mov ax, 32
mov es, ax
mov ax, 13h
jmp [dword ptr home_sel]
endp
proc exc_14 ;���������� ���������� 14h
mov ax, 8
mov ds, ax
mov ax, 32
mov es, ax
mov ax, 14h
jmp [dword ptr home_sel]
endp
proc exc_15 ;���������� ���������� 15h
mov ax, 8
mov ds, ax
mov ax, 32
mov es, ax
mov ax, 15h
jmp [dword ptr home_sel]
endp
proc exc_16 ;���������� ���������� 16h
mov ax, 8
mov ds, ax
mov ax, 32
mov es, ax
mov ax, 16h
jmp [dword ptr home_sel]
endp
proc exc_17 ;���������� ���������� 17h
mov ax, 8
mov ds, ax
mov ax, 32
mov es, ax
mov ax, 17h
jmp [dword ptr home_sel]
endp
proc exc_18 ;���������� ���������� 18h
mov ax, 8
mov ds, ax
mov ax, 32
mov es, ax
mov ax, 18h
jmp [dword ptr home_sel]
endp
proc exc_19 ;���������� ���������� 19h
mov ax, 8
mov ds, ax
mov ax, 32
mov es, ax
mov ax, 19h
jmp [dword ptr home_sel]
endp
proc exc_1a ;���������� ���������� 1Ah
mov ax, 8
mov ds, ax
mov ax, 32
mov es, ax
mov ax, 1Ah
jmp [dword ptr home_sel]
endp
proc exc_1b ;���������� ���������� 1Bh
mov ax, 8
mov ds, ax
mov ax, 32
mov es, ax
mov ax, 1Bh
jmp [dword ptr home_sel]
endp
proc exc_1c ;���������� ���������� 1Ch
mov ax, 8
mov ds, ax
mov ax, 32
mov es, ax
mov ax, 1Ch
jmp [dword ptr home_sel]
endp
proc exc_1d ;���������� ���������� 1Dh
mov ax, 8
mov ds, ax
mov ax, 32
mov es, ax
mov ax, 1Dh
jmp [dword ptr home_sel]
endp
proc exc_1e ;���������� ���������� 1Eh
mov ax, 8
mov ds, ax
mov ax, 32
mov es, ax
mov ax, 1Eh
jmp [dword ptr home_sel]
endp
proc exc_1f ;���������� ���������� 1Fh
mov ax, 8
mov ds, ax
mov ax, 32
mov es, ax
mov ax, 1Fh
jmp [dword ptr home_sel]
endp
proc exc_xx ;���������� ������ ����������
mov ax, 8
mov ds, ax
mov ax, 32
mov es, ax
mov ax, 1111h
jmp [dword ptr home_sel]
endp
start:
xor eax, eax
mov ax, @data
mov ds, ax
;���������� ����� ������������
load_addr gdt_data, ds
load_addr gdt_code, cs
load_addr gdt_stack, ss
load_addr gdt_tss_386, ds
add [(descr ptr gdt_tss_386).base_l], offset tss_386
load_addr gdt_tss_86, ds
add [(descr ptr gdt_tss_86).base_l], offset tss_86
;���������� � �������� GDTR
mov ax, @data
shl eax, 4
mov [dword ptr pdescr+2], eax
mov [word ptr pdescr], gdt_size-1
lgdt [pword ptr pdescr]
;��������� ����� ��������� ������ NT
pushf
pop ax
or ax, 4000h
push ax
popf
; �������� ���� TSS ������ 386 (tss_386)
mov [word ptr tss_386], 48 ; ���� �����
; �������� ���� TSS ������ V86 (tss_86)
mov [word ptr tss_86+4Ch], code_86 ; CS <- ���������� �����
mov [word ptr tss_86+20h], offset v86 ; IP
mov [word ptr tss_86+50h], stk_86 ; SS
mov [word ptr tss_86+38h], stk86 ; ESP
mov [word ptr tss_86+54h], data_86 ; DS
mov [word ptr tss_86+48h], 0B800h ; ES <- ����������
mov [dword ptr tss_86+24h], 20000h ; EFLAGS (VM=1, IOPL = 00b)
mov [word ptr tss_86+04h], stk0 ; ESP0
mov [word ptr tss_86+08h], 24 ; SS0
; ������ ���������� ���������� � NMI
cli
in al, 70h
or al, 80h
out 70h, al
;���������� � �������� IDTR
mov [word ptr pdescr], idt_size-1
xor eax, eax
mov ax, @data
shl eax, 4
mov dx, offset idt
add eax, edx
mov [dword ptr pdescr+2], eax
lidt [pword ptr pdescr]
mov eax, CR0
or eax, 1
mov CR0, eax
db 0EAh
dw offset continue
dw 16
continue:
mov ax, 8
mov ds, ax
mov ax, 24
mov ss, ax
mov ax, 32
mov es, ax
;��������� ������� ������ 386 � ������ ���������� "������������" V86
mov ax, 40
ltr ax
iret
go:
mov ax, 0FFFFh
home:
;����� ���������������� ���������
aux ax, 0, string
lineout string, string_pos, 74h, string_len
;������� � �������� �����
mov eax, CR0
and al, 0FEh
mov CR0, eax
db 0EAh
dw offset return
dw @code
return:
;����������� ������������ ����� ��������� ������
mov ax, @data
mov ds, ax
mov ax, @stack
mov ss, ax
mov sp, stk386
;����������� �������� IDTR ��� ������ � �������� ������
lidt [fword ptr idtr_real]
;�������� ���������� � ������������� ����������
sti
in al, 70h
and al, 07Fh
out 70h, al
mov ah, 09h
mov dx, offset mes
int 21h
mov ax, 4C00h
int 21h
ends
code_size=$-sttt ;������ �������� ���� 386
;������� ������ V86
segment data_86 'abc'
mes_86 db " Run in V86 "
mes_86_len = $-mes_86 mes_86_pos dw 160*12
string1_86 db '***** ****'
string1_86_len = $-string1_86
string1_86_pos dw 160*14
data_86_size = $-mes_86
ends
;������� ���� V86
segment code_86 'abc'
assume cs:code_86, ds:data_86
taskl = $
proc V86
lineout mes_86, mes_86_pos, 1Bh, mes_86_len
lineout string1_86, string1_86_pos, 2Ah, string1_86_len
; �������� ���������� #GP, ������� �������� ���������� �� �����
sti
endp
code_86_size = $-taskl
ends
stk86 = 300h
segment stk_86 'abc'
db stk86 dup(0)
ends
end start
end
