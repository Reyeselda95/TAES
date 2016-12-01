var express = require('express');
var usuarios = express.Router();
module.exports = usuarios;

var mysql      = require('mysql');
var connection = mysql.createConnection({
  host     : 'sql8.freesqldatabase.com',
  user     : 'sql8117950',
  password : 'dZPKpXUxMN',
  database : 'sql8117950'
});
connection.connect();

usuarios.get('/',function(req,res){
  var login = req.params.id;

  connection.query('SELECT * from Usuario', function(err, rows, fields) {
    if (rows ==null){
      res.status(404).send('Usuario no encontrado');
    }else{
      res.status(200).send(rows);
    }
  });

});

usuarios.get('/:id',function(req,res){
  var login = req.params.id;

  connection.query('SELECT * from Usuario u where u.usuario=\''+login+'\'', function(err, rows, fields) {
    if (rows ==null){
      res.status(404).send('Usuario no encontrado');
    }else{
      res.status(200).send(rows[0]);
    }
  });
});

usuarios.post('/',function(req,res){
  var Nombre = null;
  var Usuario = req.body.Usuario;
  var Pass = req.body.Pass;
  var Correo = req.body.Correo;
  var Ciudad =null;
  var Pais = null;
  var Edad = null;
  var Altura = null;
  var Peso = null;
  var Imagen = null;
  connection.query('insert into `Usuario` values(\''+Nombre+'\',\''+Usuario+'\',\''+Pass+'\',\''+Correo+'\',\''+Ciudad+'\',\''+Pais+'\','+Edad+','+Altura+','+Peso+','+Imagen+');', function(err, rows, fields) {
    if (err){
      res.status(500).send('Usuario no insertado');
    }else{
      res.status(200).send('Usuario Insertado');
    }
  });
});

/*
usuarios.put('/:id',function(req,res){
  var login = req.params.id;
  var Nombre = req.body.Nombre;
  var Usuario = req.body.Usuario;
  var Pass = req.body.Pass;
  var Correo = req.body.Correo;
  var Ciudad = req.body.Ciudad;
  var Pais = req.body.Pais;
  var Edad = req.body.Edad;
  var Altura = req.body.Altura;
  var Peso = req.body.Peso;
  var Imagen = req.body.Imagen;
  connection.query('insert into `Usuario` values(\''+Nombre+'\',\''+Usuario+'\',\''+Pass+'\',\''+Correo+'\',\''+Ciudad+'\',\''+Pais+'\','+Edad+','+Altura+','+Peso+','+Imagen+');', function(err, rows, fields) {
    if (err){
      res.status(404).send('Usuario no insertado');
    }else{
      res.status(200).send('Usuario Insertado');
    }
  });
});*/
