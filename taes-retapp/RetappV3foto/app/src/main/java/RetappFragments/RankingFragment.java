package RetappFragments;

import android.app.AlertDialog;
import android.app.Fragment;
import android.os.Bundle;
import android.provider.ContactsContract;
import android.support.annotation.Nullable;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.TextView;

import database.DataHolder;
import huevosenterprise.retappv2.R;
import soap.Caller;

/**
 * Created by raquelvicedo on 07/03/2016.
 */
public class RankingFragment extends Fragment {



    @Nullable
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {

        View rootView = inflater.inflate(R.layout.fragment_ranking,container,false);

        TextView rank = (TextView)rootView.findViewById(R.id.tvRanking);
        String texto = "";
        try{
            Caller c = new Caller();
            c.tipo = "ranking";
            c.username = DataHolder.getGaccount();
            c.join();
            c.start();
            while (c.ranking.equals("nada")){
                Thread.sleep(10);
            }
            texto = c.ranking;
        }catch (Exception ex){
            AlertDialog ad = new AlertDialog.Builder(super.getActivity()).create();
            ad.setTitle("Funciona?");
            ad.setMessage(ex.toString());
            ad.show();
        }
        String[] fin = texto.split("#");
        /*AlertDialog ad = new AlertDialog.Builder(super.getActivity()).create();
        ad.setTitle("Funciona?");
        ad.setMessage(texto);
        ad.show();*/
        String paramostrar = "";
        for (int i=0; i < fin.length;i++){
            paramostrar += fin[i];
            paramostrar += "\n";
        }
        rank.setText(paramostrar);

        return rootView;
    }
}