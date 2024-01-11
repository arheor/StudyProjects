export function selectionSort(array) {
	for (let i; i < array.length; i++) {
		let indexMin = i;
		for (let j = i + 1; j < array.length; j++) {
			if (array[indexMin] > array[j]) {
				indexMin = array[j];
			}
			let temp = array[i];
			array[i] = array[indexMin];
			array[indexMin] = temp;
		}
	}
	return array;
}
