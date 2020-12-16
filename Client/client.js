const PROTO_PATH = __dirname + '/gradeCalculation.proto';

const grpc = require('grpc');
const protoLoader = require('@grpc/proto-loader');

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

const client = new gradeCalculation_proto.GradeCalculation('192.168.1.51:5001', grpc.credentials.createInsecure());

const students = [
  {
    fio: 'Матушкина А.А.',
    gradeMathOne: 81,
    gradeMathTwo: 61,
    gradeMathThree: 100,
  },
  {
    fio: 'Иванов И.И.',
    gradeMathOne: 81,
    gradeMathTwo: 88,
    gradeMathThree: 85,
  },
  {
    fio: 'Сидоров С.С.',
    gradeMathOne: 12,
    gradeMathTwo: 32,
    gradeMathThree: 100,
  },
  {
    fio: 'Андреев А.А.',
    gradeMathOne: 65,
    gradeMathTwo: 55,
    gradeMathThree: 85,
  },
];

function start(students) {
students.forEach(student =>
  client.CalculateGrade(
    student,
    function(err, response) {
      if (err) console.log('error ', err);
      else
      console.log('For: ', student.fio, " Grade: ", response.finalMathGrade);
    }
  )
);
  }

let x  = 100;
start(students);