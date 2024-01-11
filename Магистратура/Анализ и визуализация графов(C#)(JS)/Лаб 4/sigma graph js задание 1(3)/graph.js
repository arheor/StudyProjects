var i,
  s,
  L = 2,
  N = 20,
  E = 20,
  g = {
    nodes: [],
    edges: [],
  };

// Generate a random graph:
for (i = 0; i < N; i++)
  g.nodes.push({
    id: 'n' + i,
    label: 'Node ' + i,
    x: Math.random(),
    y: Math.random(),
    size: 1,
    color: '#00BFFF',
  });

for (i = 0; i < E; i++)
  g.edges.push({
    id: 'e' + i,
    label: "" + Math.floor(Math.random() * (11 - 1) + 1),
    source: 'n' + ((Math.random() * N) | 0),
    target: 'n' + ((Math.random() * N) | 0),
    //size: Math.floor(Math.random() * (11 - 1) + 1),
    color: '#ccc',
    type: 'line'
  });

  // Initialise sigma:
var s = new sigma({
  renderer: {
    container: document.getElementById('sigma-container'),
    type: 'canvas',
  },
  settings: {
    defaultEdgeLabelSize: 14,
    edgeLabelSize: "proportional",
    edgeLabelThreshold: 0,
  },
});

// помечаем вершины
var uniqArr = [];
var max = 0;
var uniqueSet;

// поиск макс кол-ва
function maxVal(array) {
  array.forEach((element) => {
    if (max < element.count) {
      max = element.count;
    }
    else if (max < element.sum) {
      max = element.sum;
    }
  });
}

var edges = [];
//подсчет кол-ва ребер
g.nodes.forEach((element) => {
  var arr = [];
  g.edges.forEach((value) => {
    if (
      value.target != value.source && value.source == element.id
    ) {
      arr.push({source: value.source, target: value.target, size: value.label})
    }
    if (
      value.target != value.source && value.target == element.id
    ) {
      arr.push({source: value.target, target: value.source, size: value.label})
    }
  });
  edges.push(arr);
  // убираем повторы
  var uniq = {}
  arr = arr.filter(obj => !uniq[obj.target] && (uniq[obj.target] = true));
  uniqArr.push(arr);
});
//считаем кол-во ребер
var count = [];
uniqArr.forEach((val) => {
  if (val.length != 0) {
    count.push({ id: val[0].source, count: val.length });
  }
})

//console.log(edges)

//Критерий важности узла – наибольшее количество путей, проходящих через узел--------------------------
// ищем макс кол-во

maxVal(count);

//помечаем вершины по кол-ву вершин
g.nodes.forEach((element) => {
  count.forEach((val) => {
    if (element.id == val.id && val.count == max) {
      element.color = '#FF0000';
    }
  });
});
//----------------------------------------------------------------------------------------------------

//Критерий важности узла – сумма весов, входных и выходных дуг.---------------------------------------
// var sumEdges = [];
// var sum;
// edges.forEach((val) => {
//   if (val.length != 0) {
//     sum = 0;
//     val.forEach((element) => {
//       sum += +element.size;
//     })
//     sumEdges.push({ id: val[0].source, sum: sum });
//   }
// })

// // массив с суммой всех весов дуг
// console.log(sumEdges)

// //макс сумма дуг
// maxVal(sumEdges);
// //console.log(max)

// //помечаем вершины
// g.nodes.forEach((element) => {
//   sumEdges.forEach((val) => {
//     if (element.id == val.id && val.sum == max) {
//       element.color = '#FF0000';
//     }
//   });
// });
//-----------------------------------------------------------------------------------------------------


// Load the graph in sigma
s.graph.read(g);
// Ask sigma to draw it
s.refresh();

//drug & drop
var dragListener = sigma.plugins.dragNodes(s, s.renderers[0]);

dragListener.bind('startdrag', function (event) {
  console.log(event);
});
dragListener.bind('drag', function (event) {
  console.log(event);
});
dragListener.bind('drop', function (event) {
  console.log(event);
});
dragListener.bind('dragend', function (event) {
  console.log(event);
});

console.log(g)

//reingold
function reingold() {
  sigma.layouts.fruchtermanReingold.configure(s, {
    easing: 'quadraticOut',
    duration: 12000,
    speed: 0.0009,
  });
  sigma.layouts.fruchtermanReingold.start(s);
}
setTimeout(reingold, 2000);

