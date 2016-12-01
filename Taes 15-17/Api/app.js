
var bodyParser = require('body-parser');
//API REST
var express = require('express');
var app = express();
app.use(bodyParser());


var usuarios = require('./routes/Usuarios');
app.use('/usuarios',usuarios);

var mysql      = require('mysql');
var connection = mysql.createConnection({
  host     : 'sql8.freesqldatabase.com',
  user     : 'sql8117950',
  password : 'dZPKpXUxMN',
  database : 'sql8117950'
});
connection.connect();

app.post('/login',function(req,res){
  var login = req.body.login;
  var password = req.body.password

  connection.query("SELECT pass from Usuario u where u.usuario=\''+login+'\'", function(rows, fields) {
      if(password==rows[0].pass){
        res.status(200).send();
      }else{
        res.status(400).send();
      }
  });
});

app.listen(process.env.PORT || 3000, function(){
    console.log('Express en el puerto 3000');
})
