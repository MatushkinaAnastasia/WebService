var express = require('express');
var bodyParser = require('body-parser');
var config = require('./config.json');

console.dir(config);

var app = express();

console.log(config.host + ":" + config.port)

app.set('view engine', 'ejs'); 

app.listen(config.port);

console.log("Локальный сервер: http://" + config.host + ":" + config.port);

app.use('/public', express.static('public'));

app.get('/', function(req, res){
    res.sendFile(__dirname + "/index.html");
});


var urlencodedParser = bodyParser.urlencoded({ extended: false })

const PROTO_PATH = __dirname + '/gradeCalculation.proto';

const grpc = require('grpc');
const protoLoader = require('@grpc/proto-loader');
const { getType } = require('mime');

const packageDefinition = protoLoader.loadSync(
  PROTO_PATH,
  {
    keepCase: true,
    longs: String,
    enums: String,
    defaults: true,
    oneofs: true
  });
const gradeCalculation_proto = grpc.loadPackageDefinition(packageDefinition);

const client = new gradeCalculation_proto.GradeCalculation(config.adress, grpc.credentials.createInsecure());

app.post('/index', urlencodedParser, function (req, res) {
    if (!req.body) return res.sendStatus(400);

    var student = {
        fio: req.body.fio,
        gradeMathOne: parseInt(req.body.gradeOne),
        gradeMathTwo: parseInt(req.body.gradeTwo),
        gradeMathThree: parseInt(req.body.gradeThree)
    }

    let s;
     client.CalculateGrade(
        student,
        function(err, response) {
          if (err) console.log('error ', err);
          else
          s = response.finalMathGrade;
          console.log('For: ', student.fio, " Grade: ", response.finalMathGrade);
          return res.render('index', {finalGrade : response.finalMathGrade, fio: student.fio});
        }
    )
    
});