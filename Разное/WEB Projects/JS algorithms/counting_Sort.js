export function countingSort(array) {
	let n = array.length;
	let count = [];
	let b = [];
	let res = [];

	for (let i = 0; i < n; i++) {
		count[i] = 0;
	}
	for (let i = 0; i < n - 1; i++) {
		for (let j = i + 1; j < n; j++) {
			if (res[i] < res[j]) count[j]++;
			else count[i]++;
		}
	}
	for (let i = 0; i < n; i++) {
		b[count[i]] = res[i];
	}

	return b;
}
