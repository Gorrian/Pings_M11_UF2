# Pings_M11_UF2
El programa puede hacer un simple ping a una sola direccion o a una lista de direcciones
que puede indicar el usuario, estos modos son:

- File

- IP

Para usar uno u el otro solo hay que especificarlo en los argumentos al ejecutar el ejecutable
en output, para testing, hay una linia en main donde se puede descomentar un args donde pueden
rellenar desde el codigo los argumentos que el programa recibe.

## Modo File
El argumento a utilizar es el siguiente

- Pings_M11_UF2.exe File [Ubicacion del archivo]

El programa revisara cada linia e intentara hacer un ping a cada uno de los nombres
y direcciones que encuentre siempre que la linia no este en blanco

## Modo IP
El argumento a utilizar es el siguiente

- Pings_M11_UF2.exe IP [IP a hacer ping].

El programa no admitira mas de una IP y simplemente hara un ping a la direccion
especificada
