package RetappFragments;

import android.app.Fragment;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import huevosenterprise.retappv2.R;

/**
 * Created by raquelvicedo on 07/03/2016.
 */
public class ContactanosFragment extends Fragment {

    @Nullable
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {

        View rootView = inflater.inflate(R.layout.fragment_contactanos,container,false);

        return rootView;
    }
}
