import { quickSort } from './quick_Sort.js';
import { countingSort } from './counting_Sort.js';

let arr = [
	'(',
	'&',
	'#',
	'0',
	'A',
	'O',
	'S',
	'<',
	'G',
	'D',
	'7',
	'A',
	'7',
	'e',
	'a',
	'^',
	's',
	'a',
	'&',
];
let res = [];

for (let i = 0; i < arr.length; i++) {
	res.push(arr[i].charCodeAt());
}

res = quickSort(res);
for (let i = 0; i < arr.length; i++) {
	res[i] = String.fromCharCode(res[i]);
}
console.log(res);

res = [];
for (let i = 0; i < arr.length; i++) {
	res.push(arr[i].charCodeAt());
}
console.log(res);

res = countingSort(res);
for (let i = 0; i < res.length; i++) {
	res[i] = String.fromCharCode(arr[i]);
}
console.log(res);
