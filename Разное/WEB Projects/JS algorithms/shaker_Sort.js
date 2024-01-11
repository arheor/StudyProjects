export function shakerSort(array) {
	let left = 0;
	let right = array.length - 1;
	while (left <= right) {
		for (let i = right; i > left; --i) {
			if (array[i - 1] > array[i]) {
				let tmp = array[i - 1];
				array[i - 1] = array[i];
				array[i] = tmp;
			}
		}
		++left;
		for (let i = left; i < right; ++i) {
			if (array[i] > array[i + 1]) {
				let tmp = array[i];
				array[i] = array[i + 1];
				array[i + 1] = tmp;
			}
		}
		--right;
	}
	return array;
}
