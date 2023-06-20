# Bubble

### Coroutinas
Las corutinas en Unity son utilizadas para realizar tareas asincrónicas y ejecutar acciones en un lapso de tiempo específico. Para spawnear objetos usando una corutina, puedes seguir los siguientes pasos:

Crea un nuevo script en C# o abre uno existente en Unity.
Dentro del script, define un método que actuará como corutina. Este método debe tener un tipo de retorno de IEnumerator.
Dentro del método de la corutina, utiliza un bucle o una condición para controlar el comportamiento de spawn. Puedes utilizar la función yield return new WaitForSeconds() para esperar un cierto tiempo antes de realizar cada spawn.
Dentro del bucle o condición, utiliza la función Instantiate() para crear una instancia del objeto que deseas spawnear.
Después de instanciar el objeto, puedes realizar cualquier configuración adicional que necesites, como asignarle una posición o rotación.
Repite el bucle o condición según tus necesidades, o utiliza una condición de finalización para determinar cuándo detener el spawning de objetos.

