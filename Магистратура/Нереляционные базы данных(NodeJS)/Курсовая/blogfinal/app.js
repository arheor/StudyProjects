const express = require('express');
const bodyParser = require('body-parser');
const path = require('path');
const staticAsset = require('static-asset');
const mongoose = require('mongoose');
const session = require('express-session');

const redis = require('redis');
const RedisStore = require('connect-redis')(session);

const Influx = require('influx');
const http = require('http');
const os = require('os');

const config = require('./config');
const routes = require('./routes');

// mongodb
mongoose.Promise = global.Promise;
mongoose.set('debug', config.IS_PRODUCTION);
mongoose.connection
  .on('error', (error) => console.log(error))
  .on('close', () => console.log('MongoDB connection closed.'))
  .once('open', () => {
    const info = mongoose.connections[0];
    console.log(`Connected to ${info.host}:${info.port}/${info.name}`);
    //require('./mocks')();
  });
//--no - deprecation;
mongoose.connect(config.MONGO_URL, {
  useNewUrlParser: true,
  useUnifiedTopology: true,
});

// redis
const redisClient = redis.createClient(config.REDIS_PORT, config.REDIS_HOST);
redisClient.on('connect', function () {
  console.log('connected to redis');
});

//influx
const influx = new Influx.InfluxDB({
  host: config.INFLUXDB_HOST,
  database: 'express_response_db',
  schema: [
    {
      measurement: 'response_times',
      fields: {
        path: Influx.FieldType.STRING,
        duration: Influx.FieldType.INTEGER,
      },
      tags: ['host'],
    },
  ],
});

// express
const app = express();

// sessions
app.use(
  session({
    secret: config.SESSION_SECRET,
    resave: true,
    saveUninitialized: false,
    store: new RedisStore({
      client: redisClient,
    }),
  })
);

// sets and uses
app.set('view engine', 'ejs');
app.use(bodyParser.urlencoded({ extended: true }));
app.use(bodyParser.json());
app.use(staticAsset(path.join(__dirname, 'public')));
app.use(express.static(path.join(__dirname, 'public')));
app.use(
  '/javascripts',
  express.static(path.join(__dirname, 'node_modules', 'jquery', 'dist'))
);
influx
  .getDatabaseNames()
  .then((names) => {
    if (!names.includes('express_response_db')) {
      return influx.createDatabase('express_response_db');
    }
  })
  .then(() => {
    http.createServer(app).listen(3001, function () {
      console.log('Listening on port 3001');
    });
  })
  .catch((err) => {
    console.error(`Error creating Influx database!`);
  });

app.get('/times', function (req, res) {
  influx
    .query(
      `
    select * from response_times
    where host = ${Influx.escape.stringLit(os.hostname())}
    order by time desc
    limit 100
  `
    )
    .then((result) => {
      res.json(result);
    })
    .catch((err) => {
      res.status(500).send(err.stack);
    });
});

app.get('/times/max', function (req, res) {
  influx
    .query(
      `
      SELECT *,MAX("duration") FROM response_times where host = ${Influx.escape.stringLit(
        os.hostname()
      )} ORDER BY "time" DESC
  `
    )
    .then((result) => {
      res.json(result);
    })
    .catch((err) => {
      res.status(500).send(err.stack);
    });
});

app.use((req, res, next) => {
  const start = Date.now();

  res.on('finish', () => {
    const duration = Date.now() - start;
    console.log(`Request to ${req.path} took ${duration}ms`);

    influx
      .writePoints([
        {
          measurement: 'response_times',
          tags: { host: os.hostname() },
          fields: { duration, path: req.path },
        },
      ])
      .catch((err) => {
        console.error(`Error saving data to InfluxDB! ${err.stack}`);
      });
  });
  return next();
});

// routes
app.use('/', routes.archive);
app.use('/api/auth', routes.auth);
app.use('/post', routes.post);
app.use('/comment', routes.comment);
app.use('/upload', routes.upload);

// catch 404 and forward to error handler
app.use((req, res, next) => {
  const err = new Error('Not Found');
  err.status = 404;
  next(err);
});

// error handler
// eslint-disable-next-line no-unused-vars
app.use((error, req, res, next) => {
  res.status(error.status || 500);
  res.render('error', {
    message: error.message,
    error: !config.IS_PRODUCTION ? error : {},
  });
});

app.listen(config.PORT, () =>
  console.log(`Example app listening on port ${config.PORT}!`)
);
