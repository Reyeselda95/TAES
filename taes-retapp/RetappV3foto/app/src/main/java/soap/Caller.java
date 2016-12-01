package soap;

/**
 * Created by Antonio on 23/04/2016.
 */
public class Caller extends Thread{
    public SerWeb cs;
    public String resp = "nada";
    public String login = "nada";
    public int[] listaidsconcursos = null;
    public int[] listaidsretos = null;
    public String registrarse = "nada";
    public String usuarioperfil = "nada";
    public String inscribirse = "nada";
    public String votar = "nada";
    public String nombrecampanya = "nada";
    public boolean getconcurso = false;
    public int idconcurso = 0;
    public int idreto = 0;
    public int tlf = 000000000;
    public String username, password, nombre, direccion, codpo;
    public String tipo;
    public String ranking = "nada";

    public void run(){
        switch (tipo) {
            case "login":
                try {
                    cs = new SerWeb();
                    cs.SOAP_ACTION+="Login";
                    cs.OPERATION_NAME = "Login";
                    login = cs.login(username, password);
                } catch (Exception ex) {
                    login = ex.toString();
                }
                break;
            case "ListaIdsConcursos":
                try{
                    cs = new SerWeb();
                    cs.SOAP_ACTION+="ListaIdsConcursos";
                    cs.OPERATION_NAME = "ListaIdsConcursos";
                    listaidsconcursos = cs.listaidsconcursos();
                }catch(Exception ex){
                    resp = ex.toString();
                }
                break;
            case "NombreCampanya":
                try{
                    cs = new SerWeb();
                    cs.SOAP_ACTION+="NombreCampanya";
                    cs.OPERATION_NAME = "NombreCampanya";
                    nombrecampanya = cs.nombrecampanya(idconcurso);

                }catch(Exception ex){
                    resp = ex.toString();
                }
                break;
            case "Registrarse":
                try{
                    cs = new SerWeb();
                    cs.SOAP_ACTION+="Registrarse";
                    cs.OPERATION_NAME = "Registrarse";
                    registrarse = cs.registrarse(username,password,tlf,nombre,direccion,codpo);
                }catch (Exception ex){

                }

                break;

            case "getIdsRetos":
                try{
                    cs = new SerWeb();
                    cs.SOAP_ACTION+="getIdsRetos";
                    cs.OPERATION_NAME = "getIdsRetos";
                    listaidsretos = cs.getidsretos(username);

                }catch (Exception ex){

                }
                break;
            case "getReto":
                try{
                    cs = new SerWeb();
                    cs.SOAP_ACTION+="getReto";
                    cs.OPERATION_NAME = "getReto";
                    resp = cs.getreto(idreto);
                }catch (Exception ex){

                }
                break;
            case "ranking":
                try{
                    cs = new SerWeb();
                    cs.SOAP_ACTION+="ranking";
                    cs.OPERATION_NAME = "ranking";
                    ranking = cs.ranking(username);
                }catch (Exception ex){
                    ranking = ex.toString();
                }
            case "UsuarioPerfil":

                break;
            case "Inscribirse":

                break;
            case "votar":

                break;
            case "getConcurso":
                try{
                    cs = new SerWeb();
                    cs.SOAP_ACTION+="getConcurso";
                    cs.OPERATION_NAME = "getConcurso";
                    getconcurso = cs.getconcurso(idconcurso);
                    resp = "true?";
                }catch (Exception ex){
                    resp = ex.toString();
                }
                break;
            //more
        }
    }
    public String getResp(){ return resp; }
}
