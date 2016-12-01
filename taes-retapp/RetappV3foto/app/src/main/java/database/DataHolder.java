package database;

/**
 * Created by Antonio on 25/04/2016.
 */
public class DataHolder {
    private static int campanya;
    private static int[] listaidsconcursos;
    private static String gaccount;
    public static int getCampanya() {return campanya;}
    public static void setCampanya(int data) {
        DataHolder.campanya = data;}
    public static int[] getListaidsconcursos() {return listaidsconcursos;}

    public static void setListaidsconcursos(int[] listaidsconcursos) {
        DataHolder.listaidsconcursos = listaidsconcursos;
    }

    public static String getGaccount() {
        return gaccount;
    }

    public static void setGaccount(String gaccount) {
        DataHolder.gaccount = gaccount;
    }
}
