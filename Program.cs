using EspacioPedido;

Cadeteria negocio = new Cadeteria();

negocio.CrearCadete(1, "Majo", "san juan", "1234");
negocio.AltaPedido(1, 1, "hola", "Vani", "tafi", "12345", "hola2");
negocio.AltaPedido(1, 2, "como", "cele", "tafi", "12345", "porton");
negocio.Mostrar();