

function mayorDeEdad(edad) {

    if (edad >= 18) {
        console.log("Eres mayor de edad");
    }else {
        console.log("Eres menor de edad");
    }

}

function numeroPrimo(num) {
    if (num > 1) {
        for (let i= 2; i < num ; i++) {
            if (num%i == 0) {
                return "El numero no es primo";    
            }
        }
        return "El numero es primo";
    }else {
        console.log("Introduzca un numero positivo mayor que 1 para hacer la prueba");
    }
}




function calcPrimerosPrimos() {
    let aux = 2;
    let primo = false;
    let arrayPrimos = [];

    while (arrayPrimos.length < 10) {
        primo = false;
        for (let i= 2; i < aux ; i++) {
            if (aux%i == 0) {
                primo = true;
            }
        }

        if (!primo) {
            arrayPrimos.push(aux);
        }
        aux++;
    }
    console.log("Los 10 numeros primos son: " + arrayPrimos);

}




    function calcNumMasGrande() {
        let array = [-2,3,7,-2,30,15];
        let num  = 0;
        for (let i = 0; i < array.length; i++) {
            if (i == 0) {
                num = array[i];
            } else {
                if (num < array[i]) {
                    num = array[i];
                }
            }
        }
        console.log("El numero mas grande es: " + num);
    }



   function palMasLarga (frase) {
    let espacios = frase.split(" ");
    let palabraMasLarga = "";
    for (let i = 0; i < espacios.length; i++) {
        if (espacios[i].length > palabraMasLarga.length) {
            palabraMasLarga = espacios[i];
        }
    }
    console.log("La palabra mas larga es: " + palabraMasLarga);
   }




   function doblar (arrayEjemplo) {
    for (let i = 0; i < arrayEjemplo.length; i++) {
        arrayEjemplo[i] = arrayEjemplo[i] * 2;
    }
    return arrayEjemplo;
    
   }



   function promedioMayores (arrayEdades) {
    let arrayAdultos = [];
    let suma = 0;
    for (let i = 0; i < arrayEdades.length; i++) {
        if (arrayEdades[i] >= 18) {
            arrayAdultos.push(arrayEdades[i]);
            suma = suma + arrayEdades[i];
        }
    }
    //console.log(arrayAdultos);
    console.log("El promedio de los mayores de edad: " + suma/arrayAdultos.length);
   } 



mayorDeEdad(18);
console.log(numeroPrimo(71));
calcPrimerosPrimos();
calcNumMasGrande();
palMasLarga("Hola buenas tardes popoojipoipoipoipo");
console.log("El array doblado es: " + doblar([3,5,6,7,8,9]));
promedioMayores([2,45,23,68,12,45,21,75,62,16,35,62,18]);