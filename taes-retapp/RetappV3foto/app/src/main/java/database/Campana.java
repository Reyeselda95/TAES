package database;

import java.util.Date;

/**
 * Created by Antonio on 24/04/2016.
 */
public class Campana {
    private static int idConcurso;
    private static boolean aprobado, finalizado;
    private static String fraseCaracteristica, compania, cuerpo, premios, imagen;
    private static int pos;
    private static Date fechaFin, fechaInicio;
    public static void setIdConcurso(int idConcurso){ Campana.idConcurso = idConcurso;}
    public static void setAprobado(boolean aprobado){ Campana.aprobado = aprobado;}
    public static void setFinalizado(boolean finalizado){Campana.finalizado = finalizado;}
    public static void setFraseCaracteristica(String fraseCaracteristica){Campana.fraseCaracteristica = fraseCaracteristica;}
    public static void setCompania(String compania){Campana.compania = compania;}
    public static void setCuerpo(String cuerpo){Campana.cuerpo = cuerpo;}
    public static void setPremios(String premios){Campana.premios = premios;}
    public static void setImagen(String imagen){Campana.imagen = imagen;}
    public static void setPos(int pos){Campana.pos = pos;}
    public static void setFechaFin(Date fechaFin){Campana.fechaFin = fechaFin;}
    public static void setFechaInicio(Date fechaInicio){Campana.fechaInicio = fechaInicio;}
    public static int getIdConcurso(){return idConcurso;}
    public static boolean getAprobado(){return  aprobado;}
    public static boolean getFinalizado(){return  finalizado;}

    public static String getFraseCaracteristica() {
        return fraseCaracteristica;
    }

    public static String getCompania(){return  compania;}
    public static String getCuerpo(){return cuerpo;}
    public static String getPremios(){return premios;}
    public static String getImagen(){return imagen;}
    public static int getPos(){return  pos;}
    public static Date getFechaFin(){return fechaFin;}
    public static Date getFechaInicio(){return  fechaInicio;}
}
