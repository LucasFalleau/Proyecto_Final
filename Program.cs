namespace DesafioEntregable
{
    public class DesafioEntregable
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenido...");
            Login();

            ProductoHandler productoHandler = new ProductoHandler();
            var productos = productoHandler.GetProductos();

            ProductoVendidoHandler productovendidoHandler = new ProductoVendidoHandler();
            var productosvendidos = productovendidoHandler.GetProductosVendidos();

            VentaHandler ventaHandler = new VentaHandler();
            var ventas = ventaHandler.GetVentas();


            void Login()
            {
                bool loginExistoso = false;
                int numeroDeIntentos = 0;
                do
                {
                    Console.WriteLine("Ingrese su nombre de usuario");
                    string nombreUsuario = Console.ReadLine();

                    Console.WriteLine("Ingrese su nombre de contraseña");
                    string contraseña = Console.ReadLine();

                    UsuarioHandler usuarioHandler = new UsuarioHandler();

                    var usuarioLogueado = usuarioHandler.GetUsuarios(nombreUsuario, contraseña);

                    if (usuarioLogueado.AsEnumerable().Any())
                    {
                        loginExistoso = true;
                    }
                    else
                    {
                        Console.WriteLine("Nombre de Usuario/Contraseña incorrecta");
                        numeroDeIntentos++;
                    }

                    if(numeroDeIntentos == 3)
                    {
                        Console.WriteLine("Ha alcanzado la cantidad maxima de intentos su cuenta ha sido bloqueada");
                        return;
                    }
                }
                while (loginExistoso is false);
                Console.WriteLine("Ha ingresado correctamente");
            }






        }
    }
}
