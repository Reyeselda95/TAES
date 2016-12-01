package RetappFragments;

import android.app.Fragment;
import android.app.FragmentManager;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.TextView;
import java.util.Random;

import com.squareup.picasso.Picasso;

import huevosenterprise.retappv2.R;

/**
 * Created by raquelvicedo on 07/03/2016.
 */
public class VotarFragment extends Fragment implements View.OnClickListener{
    private Button superado,nosuperado;
    String url1 = "http://89.29.188.229:52353/fotos/cocacola.jpg";
    String url2 = "http://89.29.188.229:52353/fotos/galletas.jpg";
    String descri1 = "Bebe una cocacola boca abajo";
    String descri2 = "Comete una XipsAjoy de la manera mas original";
    final int min = 1;
    final int max = 2;
    Random ran = new Random();
    final int random = ran.nextInt((max - min) + 1) + min;


    @Nullable
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {

        View rootView = inflater.inflate(R.layout.fragment_votar,container,false);

        ImageView mImageView = (ImageView) rootView.findViewById(R.id.imageView4);//imagen
        TextView mMenuNameTextView = (TextView) rootView.findViewById(R.id.textView20);//descripcion

        superado = (Button) rootView.findViewById(R.id.button);
        nosuperado = (Button) rootView.findViewById(R.id.button2);

        superado.setOnClickListener(this);
        nosuperado.setOnClickListener(this);

        if(random == 1){
            mMenuNameTextView.setText(descri1);
            Picasso.with(getActivity().getApplicationContext()).load(url1).resize(192, 192).centerInside().into(mImageView);
        }else
        {
            mMenuNameTextView.setText(descri2);
            Picasso.with(getActivity().getApplicationContext()).load(url2).resize(192, 192).centerInside().into(mImageView);
        }
        return rootView;
    }

    public void onClick(View v) {
        FragmentManager fn = getFragmentManager();
        switch (v.getId()) {
            case R.id.button:
                //incrementar los superados
                fn.beginTransaction().replace(R.id.content_frame, new VotarFragment()).commit();
                break;

            case R.id.button2:
                //incrementar los no superados
                fn.beginTransaction().replace(R.id.content_frame, new VotarFragment()).commit();
                break;
        }
    }
}