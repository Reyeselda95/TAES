package RetappFragments;

import android.app.Fragment;
import android.content.Intent;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.TextView;

import com.squareup.picasso.Picasso;

import huevosenterprise.retappv2.R;


public class PerfilFragment extends Fragment {

    @Nullable
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {

        View rootView = inflater.inflate(R.layout.fragment_perfil, container, false);

        Bundle args = getArguments();

        if(args != null) {

            String nomb  = args.getString("nombre");
            String foto = args.getString("url");

            TextView mMenuNameTextView = (TextView) rootView.findViewById(R.id.textView16);//era getview no getactivity
            mMenuNameTextView.setText(nomb); //peta aqui

            ImageView mImageView = (ImageView) rootView.findViewById(R.id.imageView3);//era getview no getactivity
            Picasso.with(getActivity().getApplicationContext()).load(foto).resize(192, 192).centerInside().into(mImageView);
        }

        return rootView;
    }
}