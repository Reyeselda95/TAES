package RetappFragments;

import android.app.ActivityManager;
import android.app.Fragment;
import android.app.FragmentManager;
import android.content.Intent;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;

import huevosenterprise.retappv2.Login;
import huevosenterprise.retappv2.MainActivity;
import huevosenterprise.retappv2.R;
import huevosenterprise.retappv2.Register;

/**
 * Created by raquelvicedo on 06/03/2016.
 */
public class Mainfragment extends Fragment implements View.OnClickListener{

    Button cocabutton;
    Button chipsbutton;

    @Nullable
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {

        View rootView = inflater.inflate(R.layout.fragment_main,container,false);

        cocabutton = (Button)rootView.findViewById(R.id.cocabutton);
        cocabutton.setOnClickListener(this);

        chipsbutton = (Button)rootView.findViewById(R.id.chipsbutton);
        chipsbutton.setOnClickListener(this);

        return rootView;
    }

    @Override
    public void onClick(View v) {

        FragmentManager fn = getFragmentManager();

        switch (v.getId()) {
            case R.id.cocabutton:
                fn.beginTransaction().replace(R.id.content_frame, new CampanyaFragment()).commit();
                /*Intent intent1 = new Intent(Mainfragment.this.getActivity(),CampanyaFragment.class);
                startActivity(intent1);*/
                break;
            case R.id.chipsbutton:
                fn.beginTransaction().replace(R.id.content_frame, new CampanyaFragment()).commit();
                /*Intent intent2 = new Intent(Mainfragment.this.getActivity(),CampanyaFragment.class);
                startActivity(intent2);*/
                break;
        }
    }
}
