// Initialise sigma:
var s = new sigma(
  {
    renderer: {
      container: document.getElementById('sigma-container'),
      type: 'canvas'
    },
    settings: {}
  }
);

var i,
    s,
    o,
    L = 2,
    N = 10,
    E = 20,
    g = {
      nodes: [],
      edges: []
    };

// Generate a random graph:
for (i = 0; i < N; i++) {
  o = {
    id: 'n' + i,
    label: 'Node ' + i,
    x: i % L,
    y: Math.floor(i / L),
    size: 1,
    color: '#00BFFF'
  };
  g.nodes.push(o);
}

for (i = 0; i < E; i++)
  g.edges.push({
    id: 'e' + i,
    source: 'n' + (Math.random() * N | 0),
    target: 'n' + (Math.random() * N | 0),
    color: "#abcd"
  });


// Load the graph in sigma
s.graph.read(g);
// Ask sigma to draw it
s.refresh();


sigma.layouts.fruchtermanReingold.configure(s, { 
  easing: 'quadraticOut',
  duration: 12000,
});
sigma.layouts.fruchtermanReingold.start(s)