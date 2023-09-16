using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using EspacioPedido;

namespace LectorCSV;

    public class HelperCsv{
        public  List<string[]> LeerCsv(string rutaArchivo, string nombreArchivo, char caracter){ //caracter vendria a ser la separacion tipo ","
            FileStream MiArchivo = new FileStream(rutaArchivo+nombreArchivo, FileMode.Open);
            StreamReader StrReader = new StreamReader(MiArchivo);
            string Linea = "";
            List<string[]> LecturaDelArchivo = new List<string[]>();
            
            while ((Linea = StrReader.ReadLine()) != null)
            {
                string[] Fila = Linea.Split(caracter);
                LecturaDelArchivo.Add(Fila);
            }

            return LecturaDelArchivo;
        }
        public List<Cadete> ConversorDeCadete(List<string[]> Filas){
            List<Cadete> MisCadetes = new List<Cadete>();
            foreach (string[] filas in Filas)
            {
                Cadete cad = new Cadete(int.Parse(filas[0]), filas[1], filas[2], filas[3]);
                MisCadetes.Add(cad);
            }
            return MisCadetes;
        }
    }