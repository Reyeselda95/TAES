package RetappFragments;


import android.app.Fragment;
import android.graphics.Bitmap;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.TextView;

import com.squareup.picasso.Picasso;

import database.Campana;
import database.DataHolder;
import huevosenterprise.retappv2.R;
import soap.Caller;
import soap.ImageURL;

/**
 * Created by raquelvicedo on 16/03/2016.
 */
public class CampanyaFragment extends Fragment{

    @Nullable
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {

        View rootView = inflater.inflate(R.layout.fragment_campanya,container,false);

        Button inscribir = (Button)rootView.findViewById(R.id.bInscribir);

        inscribir.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

            }
        });


        try {
            Caller c = new Caller();
            c.tipo = "getConcurso";
            c.idconcurso = DataHolder.getCampanya();
            c.join();
            c.start();
            while(c.resp.equals("nada")){
                try{
                    Thread.sleep(10);
                }catch (Exception ex){

                }
            }
            if (c.getconcurso){
                /*AlertDialog ad = new AlertDialog.Builder(super.getActivity()).create();
                ad.setTitle("Funciona?");
                ad.setMessage(Campana.getFraseCaracteristica());
                ad.show();*/
            }
        }catch (Exception ex){
                    /*ad.setTitle("Errores");
                    ad.setMessage(ex.toString());
                    ad.show();*/
        }


        TextView Titulo = (TextView)rootView.findViewById(R.id.textView7);
        TextView Compania = (TextView)rootView.findViewById(R.id.textView22);
        TextView Premios = (TextView)rootView.findViewById(R.id.textViewPremios);
        TextView Descripcion = (TextView)rootView.findViewById(R.id.textView24);


        ImageView imagen = (ImageView)rootView.findViewById(R.id.imageView2);
        String url = Campana.getImagen();
        Picasso.with(getActivity().getApplicationContext()).load(url).resize(192, 192).centerInside().into(imagen);
        Titulo.setText(Campana.getFraseCaracteristica());
        Compania.setText(Campana.getCompania());
        Premios.setText(Campana.getPremios());
        Descripcion.setText(Campana.getCuerpo());

        return rootView;
    }
}

