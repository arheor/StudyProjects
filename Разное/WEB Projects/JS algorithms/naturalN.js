let arr = [];
let n = 1000000;
for (let i = 2; i < n; i++) {
	arr[i] = true;
}

let p = 2;
let i = 0;
do {
	for (i = p * p; i < n; i += p) {
		arr[i] = false;
	}

	for (i = p + 1; i < n; i++) {
		if (arr[i]) break;
	}
	p = i;
} while (p * p < n);

let k = 0;
for (i = 0; i < arr.length; i++) {
	if (arr[i]) {
		k++;
	}
}
console.log(k);
