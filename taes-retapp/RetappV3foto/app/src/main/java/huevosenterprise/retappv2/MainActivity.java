package huevosenterprise.retappv2;

import android.app.Fragment;
import android.app.FragmentManager;
import android.content.Intent;
import android.os.Bundle;
import android.support.design.widget.NavigationView;
import android.support.v4.view.GravityCompat;
import android.support.v4.widget.DrawerLayout;
import android.support.v7.app.ActionBarDrawerToggle;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.ImageView;
import android.widget.TextView;

import RetappFragments.ContactanosFragment;
import RetappFragments.Mainfragment;
import RetappFragments.PerfilFragment;
import RetappFragments.RankingFragment;
import RetappFragments.RetoFragment;
import RetappFragments.VotarFragment;

import com.squareup.picasso.Picasso;

public class MainActivity extends AppCompatActivity
        implements NavigationView.OnNavigationItemSelectedListener{

    String googlenombre = null; //variables para el fragment de perfil
    String googleurl  = null;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);

        DrawerLayout drawer = (DrawerLayout) findViewById(R.id.drawer_layout);
        ActionBarDrawerToggle toggle = new ActionBarDrawerToggle(
                this, drawer, toolbar, R.string.navigation_drawer_open, R.string.navigation_drawer_close);
        drawer.setDrawerListener(toggle);
        toggle.syncState();

        NavigationView navigationView = (NavigationView) findViewById(R.id.nav_view);
        navigationView.setNavigationItemSelectedListener(this);
///////////////////////////////////////////////////////////////////

            View cambiable = navigationView.getHeaderView(0);

            Intent in = getIntent();
            Bundle extras = in.getExtras();

        if(extras != null) { //ponemos esto para evitar que login pete con google+

            TextView mMenuMailTextView = (TextView) cambiable.findViewById(R.id.menuMail);
            TextView mMenuNameTextView = (TextView) cambiable.findViewById(R.id.menuName);
            ImageView mImageView = (ImageView) cambiable.findViewById(R.id.imageView);

            mMenuMailTextView.setText(extras.getString("email"));
            mMenuNameTextView.setText(extras.getString("nombre"));

            googlenombre = extras.getString("nombre");
            googleurl = extras.getString("url");

            Picasso.with(getApplicationContext()).load(extras.getString("url")).resize(192, 192).centerInside().into(mImageView);
        }
///////////////////////////////////////////////////////////////////
        FragmentManager fn = getFragmentManager();
        fn.beginTransaction().replace(R.id.content_frame, new Mainfragment()).commit();

    }


    @Override
    public void onBackPressed() {
        DrawerLayout drawer = (DrawerLayout) findViewById(R.id.drawer_layout);
        if (drawer.isDrawerOpen(GravityCompat.START)) {
            drawer.closeDrawer(GravityCompat.START);
        } else {
            super.onBackPressed();
        }
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.main, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.
        int id = item.getItemId();

        //noinspection SimplifiableIfStatement
        if (id == R.id.action_settings) {
            return true;
        }

        return super.onOptionsItemSelected(item);
    }

    @SuppressWarnings("StatementWithEmptyBody")
    @Override
    public boolean onNavigationItemSelected(MenuItem item) {

        FragmentManager fn = getFragmentManager();

        int id = item.getItemId();

        if (id == R.id.nav_contactanos) {
            fn.beginTransaction().replace(R.id.content_frame, new ContactanosFragment()).commit();
        } else if (id == R.id.nav_principal) {
            startActivity(new Intent(this, MainActivity.class));
        }else if (id == R.id.nav_reto){
            fn.beginTransaction().replace(R.id.content_frame, new RetoFragment()).commit();
        } else if (id == R.id.nav_perfil) {
            if(googlenombre != null){
                Bundle bundle = new Bundle();
                bundle.putString("nombre", googlenombre);
                bundle.putString("url", googleurl);
                PerfilFragment fragInfo = new PerfilFragment();
                fragInfo.setArguments(bundle);
                fn.beginTransaction().replace(R.id.content_frame, fragInfo).commit();
            }else{
                fn.beginTransaction().replace(R.id.content_frame, new PerfilFragment()).commit();
            }
        } else if (id == R.id.nav_votar) {
            fn.beginTransaction().replace(R.id.content_frame, new VotarFragment()).commit();
        } else if (id == R.id.nav_ranking) {
            fn.beginTransaction().replace(R.id.content_frame, new RankingFragment()).commit();
        } else if (id == R.id.nav_logout) {
            startActivity(new Intent(this, logingoogle.class));
        }

        DrawerLayout drawer = (DrawerLayout) findViewById(R.id.drawer_layout);
        drawer.closeDrawer(GravityCompat.START);
        return true;
    }


    /*public void replaceFragments(Class fragmentClass) {
        Fragment fragment = null;
        try {
            fragment = (Fragment) fragmentClass.newInstance();
        } catch (Exception e) {
            e.printStackTrace();
        } // Insert the fragment by replacing any existing fragment
        FragmentManager fragmentManager = getSupportFragmentManager();
        fragmentManager.beginTransaction().replace(R.id.flContent, fragment).commit();
    }*/
}
