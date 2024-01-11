import { bubbleSort } from './bubble_Sort.js';
import { binarySearch } from './binary_Search.js';
import { selectionSort } from './selection_Sort.js';
import { quickSort } from './quick_Sort.js';
import { shakerSort } from './shaker_Sort.js';

let array = [
	10, 14, 5, 7, 6, 45, 8, 6, 7, 53, 75, 93, 41, 0, 42, 10, 30, 70, 99, 55, 31,
	22, 21,
];
let sortArray = bubbleSort(array);
//отсортированный массив
console.log(sortArray);
//бинарный поиск
console.log(binarySearch(sortArray, 10));
//сортировка выбором
console.log(selectionSort(array));
//быстрая сортировка
console.log(quickSort(array));
//сортировка перемешиванием
console.log(shakerSort(array));
