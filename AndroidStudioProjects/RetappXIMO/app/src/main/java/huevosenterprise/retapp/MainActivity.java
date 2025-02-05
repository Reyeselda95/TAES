package huevosenterprise.retapp;

import android.content.res.Configuration;
import android.support.v4.app.ActionBarDrawerToggle;
import android.support.v4.widget.DrawerLayout;
import android.support.v7.app.ActionBarActivity;
import android.os.Bundle;
import android.view.MenuItem;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.ListView;
import android.widget.Toast;


public class MainActivity extends ActionBarActivity {

        //El drawerLayout esn el que se desplega y
        //contiene dentro el menú, normalmente un listview
        private DrawerLayout mDrawerLayout;
        //Declaremos el ListView
        private ListView mDrawerList;
        //ActionBarDrawerToggle es donde aparecerá el boton
        //para desplegar el menú
        private ActionBarDrawerToggle mDrawerToggle;

        @Override
        protected void onCreate(Bundle savedInstanceState) {
            super.onCreate(savedInstanceState);
            setContentView(R.layout.activity_main);

            //relacionamos ocn el XML
            mDrawerLayout = (DrawerLayout) findViewById(R.id.drawer_layout);
            mDrawerList = (ListView) findViewById(R.id.left_drawer);
            //Configuramos el Boton que desplegará el menú
            mDrawerToggle = new ActionBarDrawerToggle(
                    this,                 //la actividad
                    mDrawerLayout,         //el drawerLayout que desplegará
                    R.mipmap.ic_launcher, //el icono que mostraremos
                    R.string.app_name,  //descripción al abrir
                    R.string.app_name  //descripción al cerrar
            ) {     };

            //Creamos nuestro menú
            final String[] opciones = {"Perfil", "Votar", "Ranking", "Contactanos"};
            //rellenamos la List view
            mDrawerList.setAdapter(new ArrayAdapter<String>(this,
                    android.R.layout.simple_list_item_1,
                    android.R.id.text1, opciones));

            //Añadimos la acción que haga en cada fila del
            //list view. en este caso solo mostraremos un Toast con un mensaje
            mDrawerList.setOnItemClickListener(new AdapterView.OnItemClickListener() {
                @Override
                public void onItemClick(AdapterView<?> arg0, View arg1,
                                        int arg2, long arg3) {
                    Toast.makeText(MainActivity.this, "id: " + opciones[arg2],
                            Toast.LENGTH_SHORT).show();
                    //Se cierra el menú
                    mDrawerLayout.closeDrawers();
                }
            });

            //Mostramos el botón en la barra de la aplicación
            getSupportActionBar().setDisplayHomeAsUpEnabled(true);
            //Activamso el click en el icono de la aplicación
            getSupportActionBar().setHomeButtonEnabled(true);

        }

        //Que el botón de desplegar siempre este sincronizado
        @Override
        protected void onPostCreate(Bundle savedInstanceState) {
            super.onPostCreate(savedInstanceState);
            mDrawerToggle.syncState();
        }
        //Igual con la configuración
        @Override
        public void onConfigurationChanged(Configuration newConfig) {
            super.onConfigurationChanged(newConfig);
            mDrawerToggle.onConfigurationChanged(newConfig);
        }
        //Activamos el click paradesplegar
        @Override
        public boolean onOptionsItemSelected(MenuItem item) {
            if (mDrawerToggle.onOptionsItemSelected(item)) {
                return true;
            }
            return super.onOptionsItemSelected(item);
        }
}
