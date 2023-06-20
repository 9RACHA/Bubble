# BubbleColors

### Coroutinas
Las corutinas en Unity son utilizadas para realizar tareas asincrónicas y ejecutar acciones en un lapso de tiempo específico. Para spawnear objetos usando una corutina, puedes seguir los siguientes pasos:

Dentro del script, define un método que actuará como corutina. Este método debe tener un tipo de retorno de IEnumerator.
Dentro del método de la corutina, utiliza un bucle o una condición para controlar el comportamiento de spawn. Puedes utilizar la función yield return new WaitForSeconds() para esperar un cierto tiempo antes de realizar cada spawn.
Dentro del bucle o condición, utiliza la función Instantiate() para crear una instancia del objeto que deseas spawnear.
Después de instanciar el objeto, puedes realizar cualquier configuración adicional que necesites, como asignarle una posición o rotación.
Repite el bucle o condición según tus necesidades, o utiliza una condición de finalización para determinar cuándo detener el spawning de objetos.

public class ObjectSpawner : MonoBehaviour {


    public GameObject objectToSpawn;
    public float spawnInterval = 1f;

    private void Start()
    {
        StartCoroutine(SpawnObjects());
    }

    IEnumerator SpawnObjects()
    {
        while (true)
        {
            Instantiate(objectToSpawn, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}

## Spawn
Para realizar el spawning (creación) de objetos en Unity, puedes utilizar la función Instantiate(). Esta función te permite crear una instancia de un objeto en la escena:

public class ObjectSpawner : MonoBehaviour {

    public GameObject objectToSpawn;

    void Start()
    {
        SpawnObject();
    }

    void SpawnObject()
    {
        Instantiate(objectToSpawn, transform.position, Quaternion.identity);
    }
}

## Destroy
La función Destroy() en Unity se utiliza para destruir un objeto o componente en la escena. Puedes usar esta función para eliminar objetos que ya no sean necesarios durante la ejecución del juego:

public class ObjectDestroyer : MonoBehaviour {

    public GameObject objectToDestroy;

    void Start()
    {
        Destroy(objectToDestroy);
    }
}

// RETRASO
public class DelayedObjectDestroyer : MonoBehaviour {


    public GameObject objectToDestroy;
    public float delay = 2f;

    void Start()
    {
        Destroy(objectToDestroy, delay);
    }
}





