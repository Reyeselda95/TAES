/*package database;
import android.content.ContentValues;
import android.content.Context;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;

/**
 * Created by Antonio on 24/04/2016.
 */
/*public class MyDBHandler extends SQLiteOpenHelper {

    private static final int DATABASE_VERSION = 1;
    private static final String DATABASE_NAME = "campanaDB.db";
    private static final String TABLE_CAMPANAS = "campanas";

    private static final String COLUMN_ID = "_id";
    private static final String COLUMN_APROBADO = "aprobado";
    private static final String COLUMN_FINALIZADO = "finalizado";
    private static final String COLUMN_CAMPANYA = "campanya";
    private static final String COLUMN_CUERPO = "cuerpo";
    private static final String COLUMN_PREMIOS = "premios";
    private static final String COLUMN_RETO = "reto";
    private static final String COLUMN_POS = "pos";
    private static final String COLUMN_FECHAFIN = "fechaFin";
    private static final String COLUMN_FECHAINICIO = "fechaInicio";

    public MyDBHandler(Context context,String name, SQLiteDatabase.CursorFactory factory, int version){
        super(context, DATABASE_NAME, factory, DATABASE_VERSION );
    }
    @Override
    public void onCreate(SQLiteDatabase db) {
        String CREATE_CAMPANAS_TABLE = "CREATE TABLE" + TABLE_CAMPANAS + "(" + COLUMN_ID +
                " INTEGER PRIMARY KEY," + COLUMN_APROBADO + " BOOLEAN," + COLUMN_FINALIZADO +
                " BOOLEAN," + COLUMN_CAMPANYA + " TEXT," + COLUMN_CUERPO + " TEXT," + COLUMN_PREMIOS +
                " TEXT," + COLUMN_RETO + " TEXT," + COLUMN_POS + " INTEGER," + COLUMN_FECHAFIN +
                " DATE," + COLUMN_FECHAINICIO + " DATE" + ")";
        db.execSQL(CREATE_CAMPANAS_TABLE);
    }

    @Override
    public void onUpgrade(SQLiteDatabase db, int oldVersion,
                          int newVersion) {
        db.execSQL("DROP TABLE IF EXISTS " + TABLE_CAMPANAS);
        onCreate(db);
    }

    public void addCampana(Campana campana){
        ContentValues values = new ContentValues();
        values.put(COLUMN_APROBADO, campana.aprobado);
        values.put(COLUMN_CAMPANYA, campana.campanya);
        values.put(COLUMN_CUERPO, campana.cuerpo);
        values.put(COLUMN_FECHAFIN, campana.fechaFin.toString());
        values.put(COLUMN_FECHAINICIO, campana.fechaInicio.toString());
        values.put(COLUMN_FINALIZADO, campana.finalizado);
        values.put(COLUMN_POS, campana.pos);
        values.put(COLUMN_PREMIOS, campana.premios);
        values.put(COLUMN_RETO,campana.reto);
    }
}*/