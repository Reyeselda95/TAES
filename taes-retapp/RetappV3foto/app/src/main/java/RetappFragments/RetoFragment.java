package RetappFragments;

import android.app.AlertDialog;
import android.app.Fragment;
import android.content.Intent;
import android.graphics.Bitmap;
import android.net.Uri;
import android.os.Bundle;
import android.os.Environment;
import android.provider.MediaStore;
import android.support.annotation.Nullable;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;

import java.io.File;

import database.Campana;
import database.DataHolder;
import database.Reto;
import huevosenterprise.retappv2.R;
import soap.Caller;

public class RetoFragment extends Fragment implements View.OnClickListener {

    private Button subida,takephoto;
    private String email = "ximo.vasalo@gmail.com";
    private String subject = "prueba";
    private String message = "hola";
    private Uri file_uri;
    private Bitmap bitmap;
    private String encoded_string, image_name;
    private File file;

    @Nullable
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {

        View rootView = inflater.inflate(R.layout.fragment_reto,container,false);

        subida = (Button) rootView.findViewById(R.id.bsubirimagen);
        takephoto = (Button) rootView.findViewById(R.id.btakephoto);

        subida.setOnClickListener(this);
        takephoto.setOnClickListener(this);

        TextView titulo = (TextView) rootView.findViewById(R.id.tvTitulo);
        TextView cuerpo = (TextView) rootView.findViewById(R.id.tvCuerpo);
        ImageView imagen = (ImageView) rootView.findViewById(R.id.ivReto);



        //PEdir lista de ids de retos
        int[] lista = null;
        try{
            Caller c = new Caller();
            c.tipo = "getIdsRetos";
            c.username = DataHolder.getGaccount();
            c.join();
            c.start();
            while (c.listaidsretos == null){
                Thread.sleep(10);
            }
            lista = c.listaidsretos;
        }catch (Exception ex){
            AlertDialog ad = new AlertDialog.Builder(super.getActivity()).create();
            ad.setTitle("Error");
            ad.setMessage(Campana.getFraseCaracteristica());
            ad.show();
        }

        if (lista.length >= 1){
            //Coger info del primer reto
            int id = lista[0];
            try{
                Caller c = new Caller();
                c.tipo = "getReto";
                c.idreto = id;
                c.join();
                c.start();
                while (c.resp.equals("nada")){
                    Thread.sleep(10);
                }
                if (c.resp.equals("true")){
                    //todo correcto
                    titulo.setText(Reto.getNombre());
                    cuerpo.setText(Reto.getDescripcion());
                }
            }catch (Exception ex){

            }
        }else{

        }


        return rootView;
    }
    public void onClick(View v) {
        switch (v.getId()) {
            case R.id.bsubirimagen:

                try {
                    final Intent emailIntent = new Intent(Intent.ACTION_SEND);
                    emailIntent.setType("plain/text");
                    emailIntent.putExtra(Intent.EXTRA_EMAIL, new String[]{email});
                    emailIntent.putExtra(Intent.EXTRA_SUBJECT, subject);
                    emailIntent.putExtra(Intent.EXTRA_TEXT, message);

                    if(file_uri != null){
                        emailIntent.putExtra(Intent.EXTRA_STREAM,file_uri);
                    }

                    this.startActivity(Intent.createChooser(emailIntent, "Sending Email...."));
                }catch (Throwable t){
                    Toast.makeText(getActivity(), "fallo " + t.toString(), Toast.LENGTH_LONG).show();
                }

                break;

            case R.id.btakephoto:

                Intent i = new Intent(MediaStore.ACTION_IMAGE_CAPTURE);
                getFileUri();
                i.putExtra(MediaStore.EXTRA_OUTPUT, file_uri);
                startActivityForResult(i, 10);

                break;
        }
    }

    private void getFileUri() {
        image_name = "testing123.jpg";
        file = new File(Environment.getExternalStoragePublicDirectory(Environment.DIRECTORY_PICTURES)
                + File.separator + image_name
        );

        file_uri = Uri.fromFile(file);
    }
}