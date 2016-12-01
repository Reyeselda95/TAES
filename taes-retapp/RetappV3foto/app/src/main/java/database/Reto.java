package database;

import java.util.Date;

/**
 * Created by Xuplus on 26/04/2016.
 */
public class Reto {
    private static String nombre, descripcion;
    private static Date fechafin;
    private static boolean active;
    private static int id;

    public static String getNombre() {
        return nombre;
    }

    public static void setNombre(String nombre) {
        Reto.nombre = nombre;
    }

    public static String getDescripcion() {
        return descripcion;
    }

    public static void setDescripcion(String descripcion) {
        Reto.descripcion = descripcion;
    }

    public static Date getFechafin() {
        return fechafin;
    }

    public static void setFechafin(Date fechafin) {
        Reto.fechafin = fechafin;
    }

    public static int getId() {
        return id;
    }

    public static void setId(int id) {
        Reto.id = id;
    }

    public static boolean isActive() {
        return active;
    }

    public static void setActive(boolean active) {
        Reto.active = active;
    }
}
