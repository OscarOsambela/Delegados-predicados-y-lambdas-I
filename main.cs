using System;
using System.Collections.Generic;

//se usan para llamar a eventos
//se reduce significativamente elcodigo a manejar diferentes escenarios
//codigo muy reutilizable

//Un delegado es un objeto que contiene una referencia a un método.
//A pesar de que el comportamiento de delegado se puede emular con una interfaz, éstos tienen una característica adicional llamada
// multicasting que significa que una sola instancia puede hacer referencia a más de un método, por ejemplo:

//MiDelegado d = Metodo1;
//d += Metodo2;  Añade un nuevo método a la lista del delegado
class MainClass {
  public static void Main (string[] args) {
    //creacion del objeto delegado apuntando a mensaje bienvenida
    ObjetoDelegado obj = new ObjetoDelegado(MensajeBienvenida.SaludoBienvenida);
    //llamada de delegado para llamar al metodo saludobienvenida
    obj("Llamada de bienvenida");

    obj = new ObjetoDelegado(MensajeDespedida.SaludoDespedida);
    obj("LLamada de despedida");

    
    List<int>listaNumeros = new List<int>();
    //agregamos un rango de valores
    listaNumeros.AddRange(new int[]{1,2,3,4,5,6,7,8,9,10});
    //delegado predicado
    Predicate<int> predicado = new Predicate<int>(DamePares); 
  }
}

//definicion del objeto delegado
delegate void ObjetoDelegado(string msj);

  class MensajeBienvenida{
    public static void SaludoBienvenida(string msj){
      Console.WriteLine("Mensaje de bienvenida = {0}", msj);
    }
  }
  class MensajeDespedida{
    public static void SaludoDespedida(string msj){
      Console.WriteLine("Mensaje de despedida = {0}", msj);
    }


  //Delegados predicados
  //devuelven solo true o false
  //muy utilizados para filtrar lista de valores comprobando si una condicion es cierta para un valor dado  
  static bool DamePares(int num){
    if(num % 2 == 0) return true;
    else return false; 
  }
}