using RoleplayGame;

namespace RoleplayGameTests
{
    public class ElfoTests
    {

        Elfo _curador = new Elfo("pepe");

        Enano enano = new Enano("rancio");
        
        MagoOscuro magoOscuro = new MagoOscuro("Maguito");
        
        IAtaque espada = Items.Espada;
        IDefensa escudo = Items.Escudo;
        

        [SetUp]
        public void Setup()
        {

            _curador = new Elfo("Legolas");
           
            enano = new Enano("Gimli"); 
        }

        [Test]
        public void TestInicializacionElfo()
        {

            _curador = new Elfo("Legolas");
            Assert.AreEqual("Legolas", _curador.Nombre);
            Assert.AreEqual(200, _curador.Vida);
            Assert.AreEqual(20, _curador.Ataque);
            Assert.AreEqual(100, _curador.Mana);
        }

        [Test]
        public void TestCargarManaCorrectamente()
        {

            _curador.Mana = 50;
            var resultado = _curador.CargarMana(50);
            
            Assert.AreEqual("Se cargo 50", resultado);
            Assert.AreEqual(100, _curador.Mana);

           
        }

        [Test]
        public void TestCargarMasManaDelPosible()
        {
            _curador.Mana = 50;

            var resultado = _curador.CargarMana(50);
            resultado = _curador.CargarMana(200);
            Assert.AreEqual("No se puede cargar mas mana del que el personaje posee", resultado);
        }

        [Test]
        public void TestAgregarItem()
        {

            _curador.AgregarItemAtaque(espada);
            _curador.AgregarItemDefensa(escudo);
            Assert.AreEqual(2, _curador.ItemsCount); 

        }

        [Test]
        public void TestCurar()
        {
            _curador.Vida = 180;

            _curador.Curar(15, enano);
            Assert.AreEqual(200, enano.Vida);

            _curador.Curar(25, _curador);  

            Assert.AreEqual(180, _curador.Vida); 
        }

        [Test]
        public void TestValorAtaqueConItem()
        {

            _curador.AgregarItemAtaque(espada); 
            int valorAtaque = _curador.ValorAtaque();


            Assert.AreEqual(50, valorAtaque); 
        }

        [Test]
        public void TestRecibirAtaqueSinDefensa()
        {

            _curador.RecibirAtaque(magoOscuro);
            Assert.That(_curador.Vida, Is.EqualTo(192)); 

        }

        [Test]
        public void TestRecibirAtaqueConDefensa()
        {

            _curador.AgregarItemDefensa(escudo);  
            _curador.RecibirAtaque(magoOscuro);
            


            Assert.AreEqual(197, _curador.Vida);
        }
    }
}