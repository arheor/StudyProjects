export function binarySearch(array, key) {
	let first = 0;
	let last = array.length;
	let middle;
	let found = false;

	while (found === false && first <= last) {
		middle = Math.floor((first + last) / 2);
		if (array[middle] === key) {
			found = true;
			return middle;
		}
		if (key < middle) {
			last = middle - 1;
		} else first = middle + 1;
	}
	if (found === false) return 'Элемент не найден!';
}
