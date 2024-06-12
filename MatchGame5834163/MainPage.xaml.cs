namespace MatchGame5834163
{
    public partial class MainPage : ContentPage
    { 

        IDispatcherTimer timer;  //Creamos la variable timer con la interfaz de DispatcherTimer
        int milisegundos; // Creamos la variable milisegundo de tipo int
        int pares; //Creamos la variable pares de tipo int
        
        public MainPage()
        {
            timer = Dispatcher.CreateTimer(); //Definimos el valor de la variable timer
            InitializeComponent(); 
            timer.Interval = TimeSpan.FromSeconds(.1); //El intervalo de tiempo sera igual a segundo iniciando con .1
            timer.Tick += Timer_Tick;  //Se le define el metodo del tiempo a la variable timer
            SetUpGame(); //Metodo que muestra las emojis y da inicio al juego
            
        }

        private void Timer_Tick(object? sender, EventArgs e) //Se crea el metodo para crear lo del tiempo
        {
            milisegundos++; //La variable milisegundo ira incrementando 
            Tiempo.Text=(milisegundos/10F).ToString("0.0s");  //El label del tiemmpo ira mostrando el tiempo jugado en segundos
            if (pares == 8)  //Si los pares de animales son igual al 8(pares) dara inicio al if
            {
                timer.Stop();  //Si es igual a 8 el  tiempo se dentendra
                Tiempo.Text = Tiempo.Text + " - Jugar otra vez?"; // Una vez se detiene dara el mensaje en el label
                Reinicio.IsVisible = true; //Tambien hace visible el boton de Reinicio
            }
        }

        private void SetUpGame() //Creamos el metodo que dara inicio al juego
        {
            List<string> animalEmoji = new List<string>() //Crea la lista de los emojis 
            {
                "🐺","🐺",
                "🦊","🦊",
                "🐕","🐕",
                "🦁","🦁",
                "🐈","🐈",
                "🐒","🐒",
                "🐅","🐅",
                "🐆","🐆",

            };
            Random random = new Random(); // Hacemos una instancia de la clase random

            foreach (Button view in Grid1.Children) //Para cada boton del grid  
            {
                view.IsVisible = true; // Hace visible el boton
                int index = random.Next(animalEmoji.Count); // Se guarda en una varible index, un numero al azar que equivale a la posicion de un emoji en la lista
                string nextEmoji = animalEmoji[index]; // se guarda en la variable nextEmoji, un emoji de la lista que se selecciona con la variable index
                view.Text = nextEmoji; //el texto del boton equivale a la variable nextEmoji
                animalEmoji.RemoveAt(index); //Se elimina el emoji seleccionado de la lista
            }
            timer.Start(); //Hace iniciar el tiempo de nuevo
            milisegundos = 0; //Hace que los milisegundo se receteen 
            pares = 0; //Hace que el numero de pares de emojis se receteen
        }

        Button ultimoButtonClicked; //Se guarda en una variable el ultimo boton pulsado
        bool encontrandoMatch = false; //se guarda en una variable la accion de encontrar pares
        private void Button_Clicked(object sender, EventArgs e) 
        {
            Button button = ((Button)sender); //se guarda la informacion del boton clickeado
            if (encontrandoMatch == false) //si encontrando match es falso
            {
                button.IsVisible = false;  //el boton presionado se hace invisible
                ultimoButtonClicked = button;  //se guarda este boton en la variable
                encontrandoMatch = true;  //se vuelve verdadero
            }
            else if (button.Text == ultimoButtonClicked.Text)  //si el boton clickeado coincide con el boton guardado
            {
                pares++;  //se incrementa el par en 1
                button.IsVisible = false;  //se hace invisble el ultimo boton clickeado
                encontrandoMatch = false; //y este se vuelve falso
            }
            else
            {
                ultimoButtonClicked.IsVisible = true;  //el boton guardado se vuelve visible
                encontrandoMatch = false;  //se vuelve falso
            }
        }

        private void Reinicio_Clicked(object sender, EventArgs e)
        {
            if (pares == 8)  //Si los pares de animales son igual al 8(pares) dara inicio al if
            {
                SetUpGame();  //Metodo que muestra las emojis y da inicio al juego
                Reinicio.IsVisible = false;  //Hace que el boton Reinicio vuelva a ser invisible al volver a jugar
            }
        }
    }

}