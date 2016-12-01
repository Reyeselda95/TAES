package RetappFragments;

import android.app.AlertDialog;
import android.app.Fragment;
import android.app.FragmentManager;
import android.app.FragmentTransaction;
import android.content.Intent;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;

import database.DataHolder;
import huevosenterprise.retappv2.MainActivity;
import huevosenterprise.retappv2.PopCampana;
import huevosenterprise.retappv2.R;
import soap.Caller;

/**
 * Created by raquelvicedo on 06/03/2016.
 */
public class Mainfragment extends Fragment implements View.OnClickListener{

    Button b1,b2,b3,b4,b5,b6;
    private int[] lista;

    @Nullable
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {

        View rootView = inflater.inflate(R.layout.fragment_main, container, false);
        //String lista = DataHolder.getListaidsconcursos();
        lista = DataHolder.getListaidsconcursos();
        //String cosa = "";
        /*for (int i = 0; i < lista.length; i++){
            //cosa += lista[i];
            Button aux = (Button)rootView.findViewById(R.id.button1);
        }*/
        Button aux;
        int tamano = lista.length;
        if (tamano >= 1) {
            aux = (Button)rootView.findViewById(R.id.button1);
            aux.setVisibility(View.VISIBLE);
            aux.setEnabled(true);
            aux.setOnClickListener(this);
            String nombre = "";
            try {
                Caller c = new Caller();
                c.tipo="NombreCampanya";
                c.idconcurso = lista[0];
                c.join();
                c.start();
                while (c.nombrecampanya.equals("nada")){
                    Thread.sleep(10);
                }
                nombre = c.nombrecampanya;
            }catch (Exception ex){

            }

            aux.setText(nombre);
        }if (tamano >=2){
            aux = (Button)rootView.findViewById(R.id.button2);
            aux.setVisibility(View.VISIBLE);
            aux.setEnabled(true);
            aux.setOnClickListener(this);
            String nombre = "";
            try {
                Caller c = new Caller();
                c.tipo="NombreCampanya";
                c.idconcurso = lista[1];
                c.join();
                c.start();
                while (c.nombrecampanya.equals("nada")){
                    Thread.sleep(10);
                }
                nombre = c.nombrecampanya;
            }catch (Exception ex){

            }
            aux.setText(nombre);
        }if (tamano >=3){
            aux = (Button)rootView.findViewById(R.id.button3);
            aux.setVisibility(View.VISIBLE);
            aux.setEnabled(true);
            aux.setOnClickListener(this);
            String nombre = "";
            try {
                Caller c = new Caller();
                c.tipo="NombreCampanya";
                c.idconcurso = lista[2];
                c.join();
                c.start();
                while (c.nombrecampanya.equals("nada")){
                    Thread.sleep(10);
                }
                nombre = c.nombrecampanya;
            }catch (Exception ex){

            }
            aux.setText(nombre);
        }if (tamano >=4){
            aux = (Button)rootView.findViewById(R.id.button4);
            aux.setVisibility(View.VISIBLE);
            aux.setEnabled(true);
            aux.setOnClickListener(this);
            String nombre = "";
            try {
                Caller c = new Caller();
                c.tipo="NombreCampanya";
                c.idconcurso = lista[3];
                c.join();
                c.start();
                while (c.nombrecampanya.equals("nada")){
                    Thread.sleep(10);
                }
                nombre = c.nombrecampanya;
            }catch (Exception ex){

            }
            aux.setText(nombre);
        }if (tamano >=5){
            aux = (Button)rootView.findViewById(R.id.button5);
            aux.setVisibility(View.VISIBLE);
            aux.setEnabled(true);
            aux.setOnClickListener(this);
            String nombre = "";
            try {
                Caller c = new Caller();
                c.tipo="NombreCampanya";
                c.idconcurso = lista[4];
                c.join();
                c.start();
                while (c.nombrecampanya.equals("nada")){
                    Thread.sleep(10);
                }
                nombre = c.nombrecampanya;
            }catch (Exception ex){

            }
            aux.setText(nombre);
        }if (tamano >=6){
            aux = (Button)rootView.findViewById(R.id.button6);
            aux.setVisibility(View.VISIBLE);
            aux.setEnabled(true);
            aux.setOnClickListener(this);
            String nombre = "";
            try {
                Caller c = new Caller();
                c.tipo="NombreCampanya";
                c.idconcurso = lista[5];
                c.join();
                c.start();
                while (c.nombrecampanya.equals("nada")){
                    Thread.sleep(10);
                }
                nombre = c.nombrecampanya;
            }catch (Exception ex){

            }
            aux.setText(nombre);
        }


        /*cocabutton = (Button)rootView.findViewById(R.id.cocabutton);
        cocabutton.setOnClickListener(this);

        chipsbutton = (Button)rootView.findViewById(R.id.chipsbutton);
        chipsbutton.setOnClickListener(this);*/

        AlertDialog ad = new AlertDialog.Builder(super.getActivity()).create();
        /*ad.setTitle("Lista de ids de concursos");
        ad.setMessage(cosa);
        ad.show();*/

        return rootView;
    }

    @Override
    public void onClick(View v) {

        FragmentManager fn = getFragmentManager();

        switch (v.getId()) {
            case R.id.button1:
                /*try {
                    Caller c = new Caller();
                    c.tipo = "getConcurso";
                    c.idconcurso = 1;
                    c.join();
                    c.start();
                    while(c.resp.equals("nada")){
                        try{
                            Thread.sleep(10);
                        }catch (Exception ex){

                        }
                    }
                    if (c.getconcurso){
                        AlertDialog ad = new AlertDialog.Builder(super.getActivity()).create();
                        ad.setTitle("Funciona?");
                        ad.setMessage(Campana.getFraseCaracteristica());
                        //ad.show();
                        //fn.beginTransaction().replace(R.id.content_frame, new CampanyaFragment()).commit();
                    }
                }catch (Exception ex){
                    /*ad.setTitle("Errores");
                    ad.setMessage(ex.toString());
                    ad.show();*/
                //}
                //fn.beginTransaction().replace(R.id.content_frame, new CampanyaFragment()).commit();
                /*Intent intent1 = new Intent(Mainfragment.this.getActivity(),CampanyaFragment.class);
                startActivity(intent1);*/
                DataHolder.setCampanya(lista[0]);
                break;
            case R.id.button2:
                DataHolder.setCampanya(lista[1]);
                /*Intent intent2 = new Intent(Mainfragment.this.getActivity(),CampanyaFragment.class);
                startActivity(intent2);*/
                break;
            case R.id.button3:
                DataHolder.setCampanya(lista[2]);

                break;
            case R.id.button4:
                DataHolder.setCampanya(lista[3]);

                break;
            case R.id.button5:
                DataHolder.setCampanya(lista[4]);

                break;
            case R.id.button6:
                DataHolder.setCampanya(lista[5]);

                break;
        }
        try{
            fn.beginTransaction().replace(R.id.content_frame, new CampanyaFragment()).commit();
        }catch (Exception ex){
            AlertDialog ad = new AlertDialog.Builder(super.getActivity()).create();
            ad.setTitle("Error");
            ad.setMessage(ex.toString());
            ad.show();
        }
    }
}
