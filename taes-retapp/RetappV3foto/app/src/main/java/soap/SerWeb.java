package soap;
import org.ksoap2.SoapEnvelope;
import org.ksoap2.serialization.PropertyInfo;
import org.ksoap2.serialization.SoapObject;
import org.ksoap2.serialization.SoapSerializationEnvelope;
import org.ksoap2.transport.HttpTransportSE;
import org.xmlpull.v1.XmlPullParserException;

import java.io.IOException;
import java.text.SimpleDateFormat;
import java.util.Date;

import database.Campana;
import database.Reto;

/**
 * Created by Antonio on 23/04/2016.
 */
public class SerWeb {
    public String SOAP_ACTION = "http://retapp.org/";

    public String OPERATION_NAME = "";

    public String WSDL_TARGET_NAMESPACE = "http://retapp.org/";

    public String SOAP_ADDRESS = "http://89.29.188.229:52353/WebService2.asmx";
    public String login(String username, String password){
        SoapObject request = new SoapObject(WSDL_TARGET_NAMESPACE,OPERATION_NAME);
        PropertyInfo pi=new PropertyInfo();
        pi.setName("username");
        pi.setValue(username);
        pi.setType(Integer.class);
        request.addProperty(pi);
        pi=new PropertyInfo();
        pi.setName("password");
        pi.setValue(password);
        pi.setType(Integer.class);
        request.addProperty(pi);

        SoapSerializationEnvelope envelope = new SoapSerializationEnvelope(
                SoapEnvelope.VER11);
        envelope.dotNet = true;

        envelope.setOutputSoapObject(request);

        HttpTransportSE httpTransport = new HttpTransportSE(SOAP_ADDRESS);
        Object response=null;
        try
        {
            httpTransport.call(SOAP_ACTION, envelope);
            response = envelope.getResponse();
        }
        catch (Exception exception)
        {
            response=exception.toString();
        }
        return response.toString();
    }

    public int[] listaidsconcursos() {
        int[] lista = null;
        SoapObject request = new SoapObject(WSDL_TARGET_NAMESPACE,OPERATION_NAME);

        SoapSerializationEnvelope envelope = new SoapSerializationEnvelope(SoapEnvelope.VER11);
        envelope.dotNet = true;

        envelope.setOutputSoapObject(request);

        HttpTransportSE httpTransport = new HttpTransportSE(SOAP_ADDRESS);
        int[] response=null;
        try
        {
            httpTransport.call(SOAP_ACTION, envelope);
            SoapObject obj1 = (SoapObject) envelope.bodyIn;
            SoapObject obj2 = (SoapObject) obj1.getProperty(0);
            lista = new int[obj2.getPropertyCount()];
            int id1 = 99939;
            for (int i=0; i < obj2.getPropertyCount(); i++){
                id1 = Integer.parseInt(obj2.getProperty(i).toString());
                if(id1 != 99939){
                    lista[i] = id1;
                }
            }
            //response = (int[])envelope.getResponse();
        }
        catch (Exception exception)
        {
            //response=(int[])exception.toString();
        }
        return lista;
    }

    public boolean getconcurso(int id) throws IOException, XmlPullParserException {
        boolean sol = false;
        SoapObject request = new SoapObject(WSDL_TARGET_NAMESPACE,OPERATION_NAME);
        PropertyInfo pi=new PropertyInfo();
        pi.setName("id");
        pi.setValue(id);
        pi.setType(Integer.class);
        request.addProperty(pi);

        SoapSerializationEnvelope envelope = new SoapSerializationEnvelope(SoapEnvelope.VER11);
        envelope.dotNet = true;

        envelope.setOutputSoapObject(request);

        HttpTransportSE httpTransport = new HttpTransportSE(SOAP_ADDRESS);

        try
        {
            httpTransport.call(SOAP_ACTION, envelope);
            SoapObject obj1 = (SoapObject) envelope.bodyIn;
            SoapObject obj2 = (SoapObject) obj1.getProperty(0);
            Campana.setIdConcurso(Integer.parseInt(obj2.getProperty(0).toString()));
            String dt = obj2.getProperty(1).toString();
            SimpleDateFormat format = new SimpleDateFormat("yyyy-MM-dd'T'HH:mm:ss'Z'");
            try{
                Campana.setFechaFin(format.parse(dt));
            }catch (Exception ex){
                Campana.setFechaFin(new Date());
            }
            Campana.setAprobado(obj2.getProperty(2).toString().contains("True"));
            Campana.setFinalizado(obj2.getProperty(3).toString().contains("True"));
            Campana.setFraseCaracteristica(obj2.getProperty(4).toString());
            Campana.setCuerpo(obj2.getProperty(5).toString());
            Campana.setPremios(obj2.getProperty(6).toString());
            Campana.setPos(Integer.parseInt(obj2.getProperty(7).toString()));
            dt = obj2.getProperty(8).toString();
            try{
                Campana.setFechaInicio(format.parse(dt));
            }catch (Exception ex){
                Campana.setFechaInicio(new Date());
            }
            Campana.setImagen(obj2.getProperty(9).toString());
            Campana.setCompania(obj2.getProperty(10).toString());
            sol = true;
            //response = (int[])envelope.getResponse();
        }
        catch (Exception exception)
        {
            throw exception;
        }
        return sol;
    }

    public String nombrecampanya(int id) {
        String sol = "";
        SoapObject request = new SoapObject(WSDL_TARGET_NAMESPACE,OPERATION_NAME);
        PropertyInfo pi=new PropertyInfo();
        pi.setName("id");
        pi.setValue(id);
        pi.setType(Integer.class);
        request.addProperty(pi);

        SoapSerializationEnvelope envelope = new SoapSerializationEnvelope(SoapEnvelope.VER11);
        envelope.dotNet = true;

        envelope.setOutputSoapObject(request);

        HttpTransportSE httpTransport = new HttpTransportSE(SOAP_ADDRESS);
        Object response=null;
        try
        {
            httpTransport.call(SOAP_ACTION, envelope);
            response = envelope.getResponse();
        }
        catch (Exception exception)
        {
            response=exception.toString();
        }
        sol = response.toString();
        return sol;
    }

    public String registrarse(String username, String password, int tlf, String nombre, String direccion, String codpo) {
        String sol = "";
        SoapObject request = new SoapObject(WSDL_TARGET_NAMESPACE,OPERATION_NAME);
        PropertyInfo pi=new PropertyInfo();
        pi.setName("gaccount");
        pi.setValue(username);
        pi.setType(Integer.class);
        request.addProperty(pi);
        pi=new PropertyInfo();
        pi.setName("pass");
        pi.setValue(password);
        pi.setType(Integer.class);
        request.addProperty(pi);
        pi=new PropertyInfo();
        pi.setName("tlf");
        pi.setValue(tlf);
        pi.setType(Integer.class);
        request.addProperty(pi);
        pi=new PropertyInfo();
        pi.setName("nom");
        pi.setValue(nombre);
        pi.setType(Integer.class);
        request.addProperty(pi);
        pi=new PropertyInfo();
        pi.setName("direccion");
        pi.setValue(direccion);
        pi.setType(Integer.class);
        request.addProperty(pi);
        pi=new PropertyInfo();
        pi.setName("codpo");
        pi.setValue(codpo);
        pi.setType(Integer.class);
        request.addProperty(pi);

        SoapSerializationEnvelope envelope = new SoapSerializationEnvelope(SoapEnvelope.VER11);
        envelope.dotNet = true;

        envelope.setOutputSoapObject(request);

        HttpTransportSE httpTransport = new HttpTransportSE(SOAP_ADDRESS);
        Object response=null;
        try
        {
            httpTransport.call(SOAP_ACTION, envelope);
            response = envelope.getResponse();
        }
        catch (Exception exception)
        {
            response=exception.toString();
        }
        sol = response.toString();
        return sol;
    }

    public int[] getidsretos(String username) {
        int[] lista = null;
        SoapObject request = new SoapObject(WSDL_TARGET_NAMESPACE,OPERATION_NAME);
        PropertyInfo pi=new PropertyInfo();
        pi.setName("gaccount");
        pi.setValue(username);
        pi.setType(Integer.class);
        request.addProperty(pi);

        SoapSerializationEnvelope envelope = new SoapSerializationEnvelope(SoapEnvelope.VER11);
        envelope.dotNet = true;

        envelope.setOutputSoapObject(request);

        HttpTransportSE httpTransport = new HttpTransportSE(SOAP_ADDRESS);
        int[] response=null;
        try
        {
            httpTransport.call(SOAP_ACTION, envelope);
            SoapObject obj1 = (SoapObject) envelope.bodyIn;
            SoapObject obj2 = (SoapObject) obj1.getProperty(0);
            lista = new int[obj2.getPropertyCount()];
            int id1 = 99939;
            for (int i=0; i < obj2.getPropertyCount(); i++){
                id1 = Integer.parseInt(obj2.getProperty(i).toString());
                if(id1 != 99939){
                    lista[i] = id1;
                }
            }
            //response = (int[])envelope.getResponse();
        }
        catch (Exception exception)
        {
            //response=(int[])exception.toString();
        }
        return lista;
    }

    public String getreto(int idreto) {
        int[] lista = null;
        SoapObject request = new SoapObject(WSDL_TARGET_NAMESPACE,OPERATION_NAME);
        PropertyInfo pi=new PropertyInfo();
        pi.setName("id");
        pi.setValue(idreto);
        pi.setType(Integer.class);
        request.addProperty(pi);

        SoapSerializationEnvelope envelope = new SoapSerializationEnvelope(SoapEnvelope.VER11);
        envelope.dotNet = true;

        envelope.setOutputSoapObject(request);

        HttpTransportSE httpTransport = new HttpTransportSE(SOAP_ADDRESS);
        String resp = "mal";
        try
        {
            httpTransport.call(SOAP_ACTION, envelope);
            SoapObject obj1 = (SoapObject) envelope.bodyIn;
            SoapObject obj2 = (SoapObject) obj1.getProperty(0);
            Reto.setNombre(obj2.getProperty(0).toString());
            Reto.setDescripcion(obj2.getProperty(1).toString());
            String dt = obj2.getProperty(2).toString();
            SimpleDateFormat format = new SimpleDateFormat("yyyy-MM-dd'T'HH:mm:ss'Z'");
            try{
                Reto.setFechafin(format.parse(dt));
            }catch (Exception ex){
                Reto.setFechafin(new Date());
            }
            Reto.setActive(obj2.getProperty(3).toString().contains("rue"));
            resp = "true";
        }
        catch (Exception exception)
        {
            resp = exception.toString();
        }
        return resp;
    }

    public String ranking(String username) {
        SoapObject request = new SoapObject(WSDL_TARGET_NAMESPACE,OPERATION_NAME);
        PropertyInfo pi=new PropertyInfo();
        pi.setName("usuario");
        pi.setValue(username);
        pi.setType(Integer.class);
        request.addProperty(pi);

        SoapSerializationEnvelope envelope = new SoapSerializationEnvelope(
                SoapEnvelope.VER11);
        envelope.dotNet = true;

        envelope.setOutputSoapObject(request);

        HttpTransportSE httpTransport = new HttpTransportSE(SOAP_ADDRESS);
        Object response=null;
        try
        {
            httpTransport.call(SOAP_ACTION, envelope);
            response = envelope.getResponse();
        }
        catch (Exception exception)
        {
            response=exception.toString();
        }
        return response.toString();
    }
}
