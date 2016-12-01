package huevosenterprise.retappv2;

import android.app.Activity;
import android.content.Intent;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.net.Uri;
import android.os.AsyncTask;
import android.os.Bundle;
import android.os.Environment;
import android.provider.MediaStore;
import android.util.Base64;
import android.util.DisplayMetrics;
import android.view.View;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.TextView;

import com.android.volley.AuthFailureError;
import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.StringRequest;
import com.android.volley.toolbox.Volley;

import java.io.ByteArrayOutputStream;
import java.io.File;
import java.util.HashMap;
import java.util.Map;

import database.Campana;
import database.DataHolder;
import soap.Caller;
import soap.ImageURL;

/**
 * Created by Antonio on 28/04/2016.
 */
public class PopCampana extends Activity {

    private Button subida;
    private String encoded_string, image_name;
    private Bitmap bitmap;
    private File file;
    private Uri file_uri;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        setContentView(R.layout.fragment_campanya);
        DisplayMetrics dm = new DisplayMetrics();
        getWindowManager().getDefaultDisplay().getMetrics(dm);

        int width = dm.widthPixels;
        int height = dm.heightPixels;

        getWindow().setLayout((int)(width*0.8),(int)(height*0.8));

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


        TextView Titulo = (TextView)findViewById(R.id.textView7);
        TextView Compania = (TextView)findViewById(R.id.textView22);
        TextView Premios = (TextView)findViewById(R.id.textViewPremios);
        TextView Descripcion = (TextView)findViewById(R.id.textView24);


        ImageView imagen = (ImageView)findViewById(R.id.imageView2);
        String url = Campana.getImagen();
        Bitmap bm = new ImageURL().getImageBitmap(url);
        imagen.setImageBitmap(bm);
        Titulo.setText(Campana.getFraseCaracteristica());
        Compania.setText(Campana.getCompania());
        Premios.setText(Campana.getPremios());
        Descripcion.setText(Campana.getCuerpo());


        subida = (Button) findViewById(R.id.bsubirimagen);
        subida.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent i = new Intent(MediaStore.ACTION_IMAGE_CAPTURE);

                getFileUri();

                i.putExtra(MediaStore.EXTRA_OUTPUT,file_uri);

                startActivityForResult(i,10);

            }
        });
    }

    private  void getFileUri(){
        image_name = "testing123.jpg";

        file = new File(Environment.getExternalStoragePublicDirectory(Environment.DIRECTORY_PICTURES)
                + file.separator + image_name);

        file_uri = Uri.fromFile(file);
    }

    @Override
    public void onActivityResult(int requestCode,int resultCode,Intent data){

        if(requestCode == 10 && resultCode == Activity.RESULT_OK){
            new Encode_image().execute();
        }

    }

    private class Encode_image extends AsyncTask<Void,Void,Void> {
        @Override
        protected Void doInBackground(Void... voids) {
            bitmap = BitmapFactory.decodeFile(file_uri.getPath());
            ByteArrayOutputStream stream = new ByteArrayOutputStream();
            bitmap.compress(Bitmap.CompressFormat.JPEG, 100, stream);

            byte[] array = stream.toByteArray();
            encoded_string = Base64.encodeToString(array, 0);
            return null;
        }

        @Override
        protected void onPostExecute(Void aVoid) {
            makeRequest();
        }
    }

    private void makeRequest() {
        RequestQueue requestQueue = Volley.newRequestQueue(getApplicationContext());
        StringRequest request = new StringRequest(Request.Method.POST, "http://192.168.1.70:89/tutorial3/connection.php",
                new Response.Listener<String>() {
                    @Override
                    public void onResponse(String response) {

                    }
                }, new Response.ErrorListener() {
            @Override
            public void onErrorResponse(VolleyError error) {

            }
        }) {
            @Override
            protected Map<String, String> getParams() throws AuthFailureError {
                HashMap<String,String> map = new HashMap<>();
                map.put("encoded_string",encoded_string);
                map.put("image_name",image_name);

                return map;
            }
        };
        requestQueue.add(request);
    }
}
