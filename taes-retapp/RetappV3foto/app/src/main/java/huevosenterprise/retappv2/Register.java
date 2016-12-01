package huevosenterprise.retappv2;

import android.app.AlertDialog;
import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;

import soap.Caller;

public class Register extends AppCompatActivity implements View.OnClickListener{

    Button bRegister,buttoncancel;
    EditText etName,etPassword,dir,tlf,name, codpo;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_register);

        etName = (EditText) findViewById(R.id.etName);//user name
        etPassword = (EditText) findViewById(R.id.etPassword);//password
        dir = (EditText) findViewById(R.id.etDir);//direccion
        tlf = (EditText) findViewById(R.id.etTlf);//tlf
        name = (EditText) findViewById(R.id.etNombre);//full name
        codpo = (EditText) findViewById(R.id.etCodpos);//codigo postal

        bRegister = (Button) findViewById(R.id.bRegister);
        buttoncancel = (Button) findViewById(R.id.buttoncancel);

        bRegister.setOnClickListener(this);
        buttoncancel.setOnClickListener(this);
    }

    @Override
    public void onClick(View v) {

        switch (v.getId()){
            case R.id.bRegister:
                try{
                    Caller c = new Caller();
                    c.tipo = "Registrarse";
                    c.username = etName.getText().toString();
                    c.password = etPassword.getText().toString();
                    c.tlf = Integer.parseInt(tlf.getText().toString());
                    c.nombre = name.getText().toString();
                    c.direccion = dir.getText().toString();
                    c.codpo = codpo.getText().toString();
                    c.join();
                    c.start();
                    while (c.registrarse.equals("nada")){
                        Thread.sleep(10);
                    }
                    if (c.registrarse.contains("true")){
                        startActivity(new Intent(this, logingoogle.class));
                    } else {
                        AlertDialog ad = new AlertDialog.Builder(this).create();
                        ad.setTitle("Error en el registro");
                        //if (c.registrarse.contains("existe"))
                            //ad.setMessage("El usuario ya existe");
                        /*else*/ ad.setMessage(c.registrarse);
                        ad.show();
                    }
                }catch (Exception ex){
                    AlertDialog ad = new AlertDialog.Builder(this).create();
                    ad.setTitle("Error");
                    ad.setMessage(ex.toString());
                    ad.show();
                }

                break;
            case R.id.buttoncancel:
                startActivity(new Intent(this, logingoogle.class));
                break;
        }
    }
}
