Cámara con Scroll enfocada a un Objeto invisible que persigue al personaje.

La cámara está enfocada en sala y muestra toda la sala

Cuando el personaje pasa a la siguiente sala, la cámara transiciona hacia la siguiente sala la con un suavizado de movimiento


La Cámara usa sistemas de colosiones de Unity con etiquetas, El Objeto de la Cámara es hijo de un objeto "Controlador de Cámara". Controlador de Cámara Depende del Movimiento del Jugador, Adaptar Estructura del Script al Script de Movimiento Final ( Por ahora)

La cámara se centra en una Pantalla colisionando con su Background. Si el Controlador de Cámara Colisiona con una Pantalla, la Cámara se fija en el Centro de la Pantalla, solo cuando el Controlador de Cámara Colisiona con el background de la Siguiente habitación con etiqueta de Cambio de Pantalla, la Cámara se fija en el Centro de la siguiente habitación, colisionando con el siguiente Background

--- A Futuro:: Que el Trigger de la Transición de cámara no dependa de la colisión de un Bakcgroumd

