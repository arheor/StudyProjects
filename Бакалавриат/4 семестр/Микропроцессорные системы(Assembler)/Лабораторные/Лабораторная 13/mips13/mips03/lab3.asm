title ruchkalab
.686
.mmx
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
; Данные для обработки
; Обработка ведется векторно, сразу по 2 элемента
RGBdata label dword
dd 0FFFF0000h ; ARGB = Red (no opacity)
dd 0FF995511h ; ARGB
dd 0FF112266h ; ARGB
dd 0FF112266h ; ARGB
dd 0FFFF0000h ; ARGB = Red (no opacity)
db 0, 0, 255, 255 ; B, G, R, A = Red (no opacity)
; Массив для хранения обработанных данных
YUVdata label dword
dd 6 dup (?)
;dd 00FFFF00h ; CMYK = Red
;db 00, 255, 255, 0 ; K, Y, M, C
; Матрица коэффициентов
t_matrix_q7 label dword
; Из-за формата хранения записываем строку в обратном порядке
; 0.0722 0.7152 0.2126, 0
db 00001001b, 01011011b , 00011011b, 0
; 0.436 -0.33609 -0.09991 0
db 00110111b, 11010101b, 11110110b, 0
; -0.05669 -0.55861 0.615 0
db 11111001b, 10111001b, 01001110b, 0
; Матрица сдвигов (в обратном порядке)
shft_matrix label dword
; 0 Y U V
db 0, 0, 128, 128
; Сегмент кода
.code
main proc far
; Загружаем адреса обрабатываемы матриц
lea ESI, RGBdata
lea EDI, YUVdata
mov ECX, 6
data_processing:
; Сохраним текущее значение счетчика
push ECX
; Загрузим адрес матрицы коэффициентов
lea EBX, dword ptr [t_matrix_q7]
pxor mm0, mm0 ; Заполнить 0
xor EDX, EDX ; Итоговый результат YUV
; Загружаем матрицу сдвигов
movd mm4, dword ptr [shft_matrix]
; Распскуем матрицу сдвигов
punpcklbw mm4, mm0 ; [0A|0R|0G|0B]
; 1. Получаем Y
; Загружаем RGB
lodsd ;mov EAX, dword ptr [ESI]
movd mm1, EAX
; Распскуем RGB
punpcklbw mm1, mm0 ; [0A|0R|0G|0B]
; Загружаем целиком строку 1 [0XYZ] в q7
mov EAX, dword ptr [EBX]
movd mm7, EAX
; Распскуем строку 1
punpcklbw mm7, mm0 ; [00|0X|0Y|0Z]
; Добавим знаковое расширение старшего байта для отрицательных чисел
psllw mm7, 8 ; Получим знаковй байт
psraw mm7, 8 ; размножим его
; Вычисляем произведения A*0 + R*X | G*Y + B*Z
pmaddwd mm7, mm1

; Сложим младшее и старшее слово результата
movq mm6, mm7
psrlq mm6, 32
paddsw mm7, mm6 ; A*0 + R*X + G*Y + B*Z
psraw mm7, 7 ; q14 => q7
; Корректируем сдвиг и матрицу сдвига
psrlq mm4, 16 ; ([VUY0] => [0UVY])
paddw mm7, mm4
; Упаковываем результат с учетом переполнения
packuswb mm7, mm0
movd EAX, mm7 ; Результат Y
mov DL, AL ; Сохраняем Y в DL
; 2. Получаем U
; Загружаем целиком строку 2 [0XYZ] в q7
add EBX, 4
mov EAX, dword ptr [EBX]
movd mm7, EAX
; Распскуем строку 2
punpcklbw mm7, mm0 ; [00|0X|0Y|0Z]
; Добавим знаковое расширение старшего байта для отрицательных чисел
psllw mm7, 8 ; Получим знаковй байт
psraw mm7, 8 ; размножим его
; Вычисляем произведения A*0 + R*X | G*Y + B*Z
pmaddwd mm7, mm1
; Сложим младшее и старшее слово результата
movq mm6, mm7
psrlq mm6, 32
paddw mm7, mm6 ; A*0 + R*X + G*Y + B*Z
psraw mm7, 7 ; q14 => q7
; Корректируем сдвиг и матрицу сдвига
psrlq mm4, 16 ; ([0VUY] => [00UV])
paddsw mm7, mm4
; Упаковываем результат с учетом переполнения
packuswb mm7, mm0
movd EAX, mm7 ; Результат Y
shl EDX, 8 ; освобождаем место для результата
mov DL, AL ; Сохраняем Y в DL
; 3. Получаем V

; Загружаем целиком строку 3 [0XYZ] в q7
add EBX, 4
mov EAX, dword ptr [EBX]
movd mm7, EAX
; Распскуем строку 3
punpcklbw mm7, mm0 ; [00|0X|0Y|0Z]
; Добавим знаковое расширение старшего байта для отрицательных чисел
psllw mm7, 8 ; Получим знаковй байт
psraw mm7, 8 ; размножим его
; Вычисляем произведения A*0 + R*X | G*Y + B*Z
pmaddwd mm7, mm1
; Сложим младшее и старшее слово результата
movq mm6, mm7
psrlq mm6, 32
paddw mm7, mm6 ; A*0 + R*X + G*Y + B*Z
psraw mm7, 7 ; q14 => q7
; Корректируем сдвиг и матрицу сдвига
psrlq mm4, 16 ; ([00VU] => [000U])
paddsw mm7, mm4
; Упаковываем результат с учетом переполнения
packuswb mm7, mm0
movd EAX, mm7 ; Результат Y
shl EDX, 8 ; освобождаем место для результата
mov DL, AL ; Сохраняем Y в DL
; Сохраним YUV
mov EAX, EDX
stosd ;mov dword ptr [EDI], EAX
; К следующему элементу
add EDI, 4
add ESI, 4
pop ECX
; Код занимает более 128 байт, условынй переход не возможен
; Заменим его на переход на новую иетку и безусловный на начало цикл
loop jmp_to_data
; По окончании цикал выходим
jmp quit
jmp_to_data:
jmp data_processing
quit:
mov eax, 0
invoke ExitProcess, eax
main endp
end main
main endp